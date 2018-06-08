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

        public string Inorder()
        {
            string str = "";
            string inorder (Node root, ref string str_)
            {
                if (root.Left != null)
                    inorder(root.Left, ref str_);
                str_ += root.Value + " ";
                if (root.Rigth != null)
                    inorder(root.Rigth, ref str_);
                return str_;
            }
            return inorder(this._root, ref str);
        }

        public string Preorder()
        {
            string str = "";
            string preorder (Node root, ref string str_)
            {
                str_ += root.Value + " ";
                if (root.Left != null)
                    preorder(root.Left, ref str_);
                if (root.Rigth != null)
                    preorder(root.Rigth, ref str_);
                return str_;
            }
            return preorder(this._root, ref str);
        }

        public string Postorder()
        {
            string str = "";
            string postorder (Node root, ref string str_)
            {
                if (root.Left != null)
                    postorder(root.Left, ref str_);
                if (root.Rigth != null)
                    postorder(root.Rigth, ref str_);
                str_ += root.Value + " ";
                return str_;
            }
            return postorder(this._root, ref str);
        }

        public override string ToString()
        {
            string str = "";
            string preorder (Node root, ref string str_)
            {
                str_ += root.ToString() + " ";
                if (root.Left != null)
                    preorder(root.Left, ref str_);
                if (root.Rigth != null)
                    preorder(root.Rigth, ref str_);
                return str_;
            }
            return preorder(this._root, ref str);
        }
    }
}