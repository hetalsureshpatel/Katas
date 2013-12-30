using System;
using System.Collections;
using System.Collections.Generic;

namespace LinkedList
{
    public class LinkedList<T> : IEnumerable<T>
    {
        public Node<T> Head { get; protected set; }

        public Node<T> Tail
        {
            get
            {
                return Head != null ? Head.Prev : null;
            }
        }

        public int Count { get; protected set; }

        public LinkedList()
        {
            Reset();
        }

        public void AddFirst(T value)
        {
            var newNode = new Node<T>(value);

            if (Head == null)
            {
                InsertNodeToEmptyList(newNode);
            }
            else
            {
                InsertNodeBefore(Head, newNode);
                Head = newNode;
            }
        }

        public void AddLast(T value)
        {
            var newNode = new Node<T>(value);

            if (Head == null)
            {
                InsertNodeToEmptyList(newNode);
            }
            else
            {
                InsertNodeBefore(Head, newNode);
            }
        }

        public void AddBefore(Node<T> node, T value)
        {
            var newNode = new Node<T>(value);

            if (Head == null)
            {
                InsertNodeToEmptyList(newNode);
            }
            else
            {
                InsertNodeBefore(node, newNode);

                if (node == Head)
                {
                    Head = newNode;
                }
            }
        }

        public void Clear()
        {
            Reset();
        }

        public bool Remove(T value)
        {
            Node<T> nodeToRemove = null;
            bool isRemoved = false;

            if (Head != null)
            {
                nodeToRemove = Head;

                bool @continue;
                do
                {
                    if (!nodeToRemove.Value.Equals(value))
                    {
                        @continue = nodeToRemove.Next != Head;

                        if (@continue)
                        {
                            nodeToRemove = nodeToRemove.Next;
                        }
                    }
                    else
                    {
                        @continue = false;
                    }
                } while (@continue);
            }

            if (nodeToRemove != null)
            {
                var next = nodeToRemove.Next;
                var prev = nodeToRemove.Prev;

                prev.Next = next;
                next.Prev = prev;

                --Count;
                isRemoved = true;
            }

            return isRemoved;
        }

        private void InsertNodeBefore(Node<T> node, Node<T> newNode)
        {
            newNode.Next = node;
            newNode.Prev = node.Prev;
            node.Prev.Next = newNode;
            node.Prev = newNode;
            ++Count;
        }

        private void InsertNodeToEmptyList(Node<T> newNode)
        {
            Head = newNode;
            Head.Prev = newNode;
            ++Count;
        }

        private void Reset()
        {
            Head = null;
            Count = 0;
        }

        #region Implementation of IEnumerable

        /// <summary>
        /// Returns an enumerator that iterates through the collection.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.Collections.Generic.IEnumerator`1"/> that can be used to iterate through the collection.
        /// </returns>
        public IEnumerator<T> GetEnumerator()
        {
            return new Enumerator(this);
        }

        /// <summary>
        /// Returns an enumerator that iterates through a collection.
        /// </summary>
        /// <returns>
        /// An <see cref="T:System.Collections.IEnumerator"/> object that can be used to iterate through the collection.
        /// </returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        #endregion

        public struct Enumerator : IEnumerator<T>, IDisposable, IEnumerator
        {
            private readonly LinkedList<T> _list;
            private T _current;
            private Node<T> _node;

            internal Enumerator(LinkedList<T> list)
            {
                _list = list;
                _node = list.Head;
                _current = default(T);
            }

            #region Implementation of IDisposable

            /// <summary>
            /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
            /// </summary>
            public void Dispose()
            {
            }

            #endregion

            #region Implementation of IEnumerator

            /// <summary>
            /// Advances the enumerator to the next element of the collection.
            /// </summary>
            /// <returns>
            /// true if the enumerator was successfully advanced to the next element; false if the enumerator has passed the end of the collection.
            /// </returns>
            /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
            public bool MoveNext()
            {
                var canMoveNext = true;

                if (_node == null)
                {
                    canMoveNext = false;
                }
                else
                {
                    _current = _node.Value;
                    _node = _node.Next;

                    if (_node == _list.Head)
                    {
                        _node = null;
                    }
                }

                return canMoveNext;
            }

            /// <summary>
            /// Sets the enumerator to its initial position, which is before the first element in the collection.
            /// </summary>
            /// <exception cref="T:System.InvalidOperationException">The collection was modified after the enumerator was created. </exception>
            public void Reset()
            {
                _current = default(T);
                _node = _list.Head;
            }

            /// <summary>
            /// Gets the element in the collection at the current position of the enumerator.
            /// </summary>
            /// <returns>
            /// The element in the collection at the current position of the enumerator.
            /// </returns>
            public T Current
            {
                get { return _current; }
            }

            /// <summary>
            /// Gets the current element in the collection.
            /// </summary>
            /// <returns>
            /// The current element in the collection.
            /// </returns>
            object IEnumerator.Current
            {
                get
                {
                    return (object)_current;
                }
            }

            #endregion
        }
    }
}
