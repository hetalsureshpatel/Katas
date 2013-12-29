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
                newNode.Prev = Head.Prev;
                newNode.Next = Head;
                Head.Prev = newNode;
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
                Tail.Next = newNode;
                newNode.Prev = Tail;
                Head.Prev = newNode;
            }
        }

        public void AddBefore(Node<T> node, T value)
        {
            
        }

        private void InsertNodeToEmptyList(Node<T> newNode)
        {
            Head = newNode;
            Head.Prev = newNode;
        }
    }
}
