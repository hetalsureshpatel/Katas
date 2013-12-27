using System;

namespace LinkedList
{
    public class LinkedList<T>
    {
        public object Head { get; protected set; }

        public object Tail { get; protected set; }

        public void AddFirst(T value)
        {
            if (Head != null)
            {
                Tail = Head;
            }

            Head = value;
        }

        public void AddLast(T value)
        {
            if (Tail != null)
            {
                Head = Tail;
            }

            Tail = value;
        }
    }
}
