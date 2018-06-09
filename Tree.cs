using List;
namespace Tree
{
    class Tree
    {
        private Node _root = null;
        
        public void Add(Node node)
        {
            Node add(Node root, Node node_)
            {
                if (root == null)
                    root = node_;
                else if (node_.Value < root.Value)
                    root.Left = add(root.Left, node_);
                else
                    root.Rigth = add(root.Rigth, node_);
                return root;
            }
            this._root = add(this._root, node);
        }

        public Stack<string> Preorder()
        {
            Stack<string> stack = new Stack<string>();
            Stack<string> preorder (Node root, Stack<string> stack_)
            {
                if (root != null)
                {
                    stack_.Push(root.Operand);
                    if (root.Left != null)
                        preorder(root.Left, stack_);
                    if (root.Rigth != null)
                        preorder(root.Rigth, stack_);
                }
                return stack_;
            }
            return preorder(this._root, stack);
        }

        public string InorderStr()
        {
            string str = "";
            string inorder (Node root, ref string str_)
            {
                if (root != null)
                {
                    if (root.Left != null)
                        inorder(root.Left, ref str_);
                    str_ += root.Operand + " ";
                    if (root.Rigth != null)
                        inorder(root.Rigth, ref str_);
                }
                return str_;
            }
            return inorder(this._root, ref str);
        }

        public string PreorderStr()
        {
            string str = "";
            string preorder (Node root, ref string str_)
            {
                if (root != null)
                {
                    str_ += root.Operand + " ";
                    if (root.Left != null)
                        preorder(root.Left, ref str_);
                    if (root.Rigth != null)
                        preorder(root.Rigth, ref str_);
                }
                return str_;
            }
            return preorder(this._root, ref str);
        }

        public string PostorderStr()
        {
            string str = "";
            string postorder (Node root, ref string str_)
            {
                if (root != null)
                {
                    if (root.Left != null)
                        postorder(root.Left, ref str_);
                    if (root.Rigth != null)
                        postorder(root.Rigth, ref str_);
                    str_ += root.Operand + " ";
                }
                return str_;
            }
            return postorder(this._root, ref str);
        }

        public override string ToString() => this.PreorderStr();
    }
}