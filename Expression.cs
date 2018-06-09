using List;
using System.Text.RegularExpressions;
namespace Tree
{
    class Expression
    {
        private string _expression;

        private Expression(string exp) => this._expression = exp;

        public static Expression Init(string exp)
        {
            string pattern = @"^([0-9]{1}?([-|\+|*|\/]{1}[0-9]{1})*)+$";
            Regex r = new Regex(pattern);
            if (r.IsMatch(exp))
                return new Expression(exp);
            return null;
        }

        private double Operation(double a, double b, string op)
        {
            switch(op)
            {
                case "+":
                    return a + b;
                case "-":
                    return a - b;
                case "*":
                    return a * b;
                case "/":
                    return a / b;
                default:
                    return -1.0;
            }
        }

        private int FirstIndexOperator(char a, char b, string expr)
        {
            int index1 = expr.IndexOf(a); // * | +
            int index2 = expr.IndexOf(b); // / | -
            if (index1 != index2)
            {
                if (index1 != -1 && index2 != -1)
                    return System.Math.Min(index1,index2);
                return System.Math.Max(index1,index2);
            }
            return -1;
        }

        private Queue<int> IndexesOperators()
        {
            string expr = this._expression;
            Queue<int> s = new Queue<int>();
            char[] op = { '*','/','+','-' };
            for (int i = 0; i < 4; i+=2)
            {
                int index = this.FirstIndexOperator(op[i],op[i + 1], expr);
                while(index != -1)
                {
                    s.Enqueue(index);
                    char[] arr = expr.ToCharArray();
                    arr[index] = '?';
                    expr = new string(arr);
                    index = this.FirstIndexOperator(op[i],op[i + 1], expr);
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
        }

        public Node CreateTree()
        {
            var list = this.Operands();
            var queue = this.IndexesOperators();
            while (!queue.IsEmpty())
            {
                List.Node<Node> node = list.Find(e => e.Value == queue.Peek().Value);
                node.Value.Left = node.Previous.Value;
                node.Value.Rigth = node.Next.Value;
                list.DeletePrevious(node);
                list.DeleteNext(node);
                queue.Dequeue();
            }
            return list.Head.Value;
        }

        public double Resolve()
        {
            Tree tree = new Tree();
            tree.Add(this.CreateTree());
            Stack<string> expr = tree.Preorder();
            Stack<double> nums = new Stack<double>();
            while (!expr.IsEmpty)
            {
                bool success = double.TryParse(expr.Peek.Value, out double res);
                if (success)
                    nums.Push(res);
                else
                {
                    double a = nums.Pop().Value;
                    double b = nums.Pop().Value;
                    nums.Push(this.Operation(a,b,expr.Peek.Value));
                }
                expr.Pop();
            }
            return nums.Peek.Value;
        }
    }
}