using System;

namespace LinkedList
{
    public class LinkedList<T>
    {
        public Node<T> Head { get; protected set; }

        public Node<T> Tail { get; protected set; }

        public LinkedList()
        {
            Head = null;
            Tail = null;
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
                InsertNodeBefore(Tail, newNode);
            }
        }

        public void AddBefore(object node, T value)
        {
            throw new NotImplementedException();
        }

        private void InsertNodeToEmptyList(Node<T> newNode)
        {
            newNode.Next = newNode;
            Head = newNode;
            Tail = newNode;
        }

        private void InsertNodeBefore(Node<T> node, Node<T> newNode)
        {
        }
    }
}
