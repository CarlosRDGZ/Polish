namespace List
{
    class Stack<T>
    {
        private Node<T> _head = null;
        private Node<T> _tail = null;

        /* METHODS */
        public void Push(T t)
        {
            Node<T> node = new Node<T>(t);
            if (this._head != null)
            {    
                this._tail.Next = node;
                node.Previous = this._tail;
                this._tail = node;
            }
            else
                this._head = this._tail = node;
        }

        public Node<T> Pop()
        {
            if (this._head != null)
            {
                if (this._head != this._tail)
                {
                    Node<T> removed =  this._tail;
                    _tail.Previous.Next = null;
                    removed.Previous = null;
                    return removed;
                }
                else
                {
                    Node<T> removed = this._head;
                    this._head = this._tail = null;
                    return removed;
                }
            }
            return null;
        }

        public Node<T> Peek() => this._tail;

        public bool IsEmpty() => this._head == null;

        public override string ToString()
        {
            string str = "";
            Node<T> temp = _head;
            while (temp != null)
            {
                str += temp.ToString() + System.Environment.NewLine;
                temp = temp.Next;
            }
            return str;
        }
    }
}