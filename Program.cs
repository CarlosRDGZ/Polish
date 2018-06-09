using List;
using System;
using System.Text.RegularExpressions;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestRegex();
            TestClassExpression();
        }

        static void TestRegex()
        {
            string pattern = @"^([0-9]{1}?([-|\+|*|\/]{1}[0-9]{1})*)+$";
            Regex r = new Regex(pattern);
            string[] test = { " aasd", "as", "1", "13", "1+1", "1+3+2", "1+2-3*4/5", "1+555", "1+*" };
            for (int i = 0; i < test.Length; i++)
            {
                Console.WriteLine(test[i] + ": " + r.IsMatch(test[i]));
            }
        }

        static void TestClassExpression()
        {
            // Expression exp = new Expression("1+3*7+1-9/8*6+0");
            Expression exp = Expression.Init("1+3*7+1-9/8*6+0");
            if (exp != null)
            {
                // exp.Operands();
                Tree tree = new Tree();
                tree.Add(exp.CreateTree());
                System.Console.WriteLine(" Preorder: " + tree.PreorderStr());
                System.Console.WriteLine("Postorder: " + tree.PostorderStr());
                // System.Console.WriteLine(tree.Preorder().ToString());
                // System.Console.WriteLine(tree.Preorder().Peek);
                System.Console.WriteLine("Result: " + exp.Resolve());
            }
            else
                System.Console.WriteLine("Not valid expression");
        }

        static void TestStack()
        {
            Stack<Node> stack = new Stack<Node>();
            for (int i = 0; i < 4; i++)
                stack.Push(new Node(i,"a"));
            Console.WriteLine(stack.ToString());
        }
        static void Operators()
        {   
            string exp = "1+3*7+1-9/8*6+0";
            Stack<int> indexes = new Stack<int>();
            char[] op = { '*','/','+','-' };
            for (int i = 0; i < 4; i++)
            {
                int index = exp.IndexOf(op[i]);
                while(index != -1)
                {
                    indexes.Push(index);
                    char[] c = exp.ToCharArray();
                    c[index] = '?';
                    exp = new string(c);
                    System.Console.WriteLine(exp);
                    index = exp.IndexOf(op[i]);
                }
            }
            System.Console.WriteLine(indexes.ToString());
        }
        static void TestTree()
        {
            int[] num = { 5,6,2,8,11,3,4,10,7,1,12 };
            Tree tree = new Tree();
            for(var i = 0; i < 11; i++)
                tree.Add(new Node(num[i],"node " + num[i].ToString()));
            Console.WriteLine(tree.PostorderStr());
            Console.WriteLine(tree.InorderStr());
            Console.WriteLine(tree.PreorderStr());
        }
    }
}
