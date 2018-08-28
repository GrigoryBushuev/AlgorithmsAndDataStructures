namespace DataStructures.Linear
{
    public class LinkedListNode<T>
    {
        public LinkedListNode() { }

        public LinkedListNode(T value)
        {
            Value = value;
        }

        public T Value
        {
            private set;
            get;
        }

        public LinkedListNode<T> Next { get; set; }

        public LinkedListNode<T> Prev { get; set; }

        public void Invalidate()
        {
            Next = null;
            Prev = null;
        }
    }
}
