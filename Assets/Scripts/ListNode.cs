using System.Collections.Generic;
using System.Data.Common;
using System.Reflection.Emit;

    public class ListNode<T>
    {
        public T data;
        private ListNode<T> nextnode;

        public ListNode<T> Nextnode { get => nextnode; set => nextnode = value; }

        public T Data { get => data; private set => data = value; }

        public ListNode(T data)
        {
            this.data = data;
            nextnode = null;
        }
        
    }
