using List;
namespace Tree
{
    class Expression
    {
        private string _expression;

        public Expression(string exp) => this._expression = exp;

        private Queue<int> IndexesOperators(out string expr)
        {
            expr = this._expression;
            Queue<int> s = new Queue<int>();
            char[] op = { '*','/','+','-' };
            for (int i = 0; i < 4; i++)
            {
                int index = expr.IndexOf(op[i]);
                while(index != -1)
                {
                    s.Enqueue(index);

                    char[] arr = expr.ToCharArray();
                    arr[index] = '?';
                    expr = new string(arr);

                    index = expr.IndexOf(op[i]);
                }
            }
            return s;
        }

        public DoublyList<Node> Operands()
        {
            DoublyList<Node> list = new DoublyList<Node>();
            var expr = this._expression.ToCharArray();
            for(var i = 0; i < this._expression.Length; i++)
                list.Add(new Node(i,expr[i].ToString()));
            return list;
            /*
            var queue = this.IndexesOperators(out string str);
            while (!queue.IsEmpty())
            {
                System.Console.Write(queue.Peek().Value + " ");
                System.Console.WriteLine(list.Find(e => e.Value == queue.Peek().Value));
                queue.Dequeue();
            }
            System.Console.WriteLine(str);
            System.Console.WriteLine(this._expression);
            return list;
            */
        }

        public Tree CreateTree()
        {
            var list = this.Operands();
            var queue = this.IndexesOperators(out string str);
            while (!queue.IsEmpty())
            {
                System.Console.WriteLine(list);
                List.Node<Node> node = list.Find(e => e.Value == queue.Peek().Value);
                node.Value.Left = node.Previous.Value;
                node.Value.Rigth = node.Next.Value;
                list.DeletePrevious(node);
                list.DeleteNext(node);
                queue.Dequeue();
                System.Console.WriteLine(list);
            }
            Tree tree = new Tree();
            return null;
        }

    }
}