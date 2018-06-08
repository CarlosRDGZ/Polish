namespace List
{
    class Node<T>
    {
        public Node<T> Next { get; set; }
        public Node<T> Previous { get; set; }
        public readonly T Value;

        public Node(T value) => this.Value = value;

        public override string ToString() =>
            "{ next: " + (this.Next != null ? "[Node node]" : "null") + ", " +
            " previous: " + (this.Previous != null ? "[Node node]" : "null") + ", " +
            " value: " + (this.Value) + " }";
    }
}