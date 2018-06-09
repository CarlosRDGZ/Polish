using System;
using System.Collections.Generic;

namespace List
{
    class DoublyList<T>
    {
        private Node<T> _head = null;
        private Node<T> _tail = null;

        /* METHODS */
        public void Add(T t)
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

        public Node<T> Find(Func<T, bool> filter)
        {
            var temp = this._head;
            while (temp != null)
            {
                if(filter(temp.Value))
                    return temp;
                temp = temp.Next;
            }
            return null;
        }
        public T FindValue(Func<T, bool> filter)
        {
            var temp = this._head;
            while (temp != null)
            {
                if(filter(temp.Value))
                    return temp.Value;
                temp = temp.Next;
            }
            return default(T);
        }

        public void DeletePrevious(Node<T> node)
        {
            if (node != null)
            {
                if (node.Previous != null)
                {
                    Node<T> previous = node.Previous;
                    if (previous.Previous != null)
                    {
                        previous.Previous.Next = node;
                        node.Previous = previous.Previous;
                    }
                    else
                    {
                        node.Previous = null;
                        this._head = node;
                    }
                }
            }
        }

        public void DeleteNext(Node<T> node)
        {
            if (node != null)
            {
                if (node.Next != null)
                {
                    Node<T> next = node.Next;
                    if (next.Next != null)
                    {
                        next.Next.Previous = node;
                        node.Next = next.Next;
                    }
                    else
                    {
                        node.Next = null;
                        this._tail = node;
                    }
                }
            }
        }

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