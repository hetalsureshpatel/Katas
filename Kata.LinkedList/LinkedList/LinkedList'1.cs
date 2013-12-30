using System;

namespace LinkedList
{
    public class LinkedList<T>
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
            Head = null;
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
    }
}
