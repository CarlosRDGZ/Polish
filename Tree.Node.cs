namespace Tree
{
    class Node
    {
        public Node Left { get; set; }
        public Node Rigth { get; set; }
        public readonly int Value;
        public readonly string Operand;

        public Node(int value, string operand)
        {
            this.Value = value;
            this.Operand = operand;
        }

        public override string ToString() =>
            "{ left: " + (this.Left != null ? "[Node node]" : "null") + ", " +
            " rigth: " + (this.Rigth != null ? "[Node node]" : "null") + ", " +
            " operand: " + (this.Operand) + ", " +
            " value: " + (this.Value) + " }";
    }    
}