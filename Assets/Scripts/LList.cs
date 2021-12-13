using System;
using System.Collections.Generic;
using System.Threading;
using System.Xml.Linq;

namespace ADT
{
    public class LList<T>
    {
        private ListNode<T> head;
        private ListNode<T> tail;
        private int count;

        public ListNode<T> Head { get => head; private set => head = value; }

        public ListNode<T> Tail { get => tail; private set => tail = value; }

        public int Count { get => count; private set => count = value; }

        public LList()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public void AddLast(T data)
        {
            ListNode<T> newNode = new ListNode<T>(data);


            if (count == 0)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Nextnode = newNode;
                tail = newNode;
            }

            count++;
        }

        public void AddFirst(T data)
        {
            ListNode<T> newNode = new ListNode<T>(data);

            if (count == 0)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                newNode.Nextnode = head;
                head = newNode;
            }

            count++;

        }

        public void AddAfter(T data, T addAfterthis)
        {
            ListNode<T> newNode = new ListNode<T>(data);

            if (count == 0)
            {
                head = newNode;
                tail = newNode;
            }
            

            ListNode<T> currentNode = head;

            while (currentNode != null)
            {
                if (currentNode.data.Equals(addAfterthis))
                {
                    ListNode<T> saveNode = currentNode.Nextnode;
                    currentNode.Nextnode = newNode;
                    newNode.Nextnode = saveNode;

                    if (currentNode.Equals(tail))
                    {
                        tail = newNode;
                    }
                }

                currentNode = currentNode.Nextnode;

            }

            count++;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        //public object Remove(T data)
        //{
        //    if (index < 0)
        //        throw new ArgumentOutOfRangeException("Index: " + index);
        //
        //    if (ListNode<T> == 0)
        //        return null;
        //
        //    if ()
        //    {
        //        
        //    }
        //}
    }
}