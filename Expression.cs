using List;
namespace Tree
{
    class Expression
    {
        private string _expression;

        public Expression(string exp) => this._expression = exp;

        private Stack<int> IndexesOperators(out string expr)
        {
            expr = this._expression;
            Stack<int> s = new Stack<int>();
            char[] op = { '*','/','+','-' };
            for (int i = 0; i < 4; i++)
            {
                int index = expr.IndexOf(op[i]);
                while(index != -1)
                {
                    s.Push(index);

                    char[] arr = expr.ToCharArray();
                    arr[index] = '?';
                    expr = new string(arr);

                    index = expr.IndexOf(op[i]);
                }
            }
            return s;
        }

        public void Operands()
        {
            DoublyList<Node> list = new DoublyList<Node>();
            var expr = this._expression.ToCharArray();
            System.Console.WriteLine(this._expression.Length);
            for(var i = 0; i < this._expression.Length; i++)
                list.Add(new Node(i,expr[i].ToString()));
            var stack = this.IndexesOperators(out string str);
            System.Console.WriteLine(stack.ToString());
            while (!stack.IsEmpty())
            {
                System.Console.WriteLine(stack.Peek().Value);
                System.Console.WriteLine(list.Find(e => e.Value == stack.Peek().Value));
                stack.Pop();
                System.Console.WriteLine(stack.Peek().Value);
            }
        }

    }
}