using System;
using List;

namespace Tree
{
    class Program
    {
        static void Main(string[] args)
        {
            TestClassExpression();
            // Expresion();
            // TestTree();
            // TestStack();
        }

        static void TestClassExpression()
        {
            Expression exp = new Expression("1+3*7+1-9/8*6+0");
            exp.Operands();
        }

        static void TestStack()
        {
            Stack<Node> stack = new Stack<Node>();
            for (int i = 0; i < 4; i++)
                stack.Push(new Node(i,"a"));
            Console.WriteLine(stack.ToString());
        }
        static void Expresion()
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
            Console.WriteLine(tree.Postorder());
            Console.WriteLine(tree.Inorder());
        }
    }
}
