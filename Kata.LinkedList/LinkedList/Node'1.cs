namespace LinkedList
{
    public class Node<T>
    {
        public T Value { get; protected set; }

        internal Node<T> Next { get; set; }
        internal Node<T> Prev { get; set; }

        public Node(T value)
        {
            Value = value;
            Next = null;
            Prev = null;
        }
    }
}
