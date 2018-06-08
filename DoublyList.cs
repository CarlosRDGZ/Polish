using System;
using System.Linq;
using System.Linq.Expressions;

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

        public T Find(Func<T, bool> filter)
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
    }
}