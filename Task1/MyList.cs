using System.Collections;
using System.Collections.Generic;

namespace Task1
{
    public class ListNode<T>
    {
        public ListNode<T> next = null;
        public T data;

        public ListNode(T Data) {
            data = Data;
        }
    }
    public class MyList<T> : IEnumerable<T>
    {
        private ListNode<T> head = null;
        private ListNode<T> tail = null;
        private int count;
        public int Count {
            get { return count; }
        }

        public void Add(T data)
        {
            ListNode<T> node = new ListNode<T>(data);
            if (head == null)
                head = node;
            else
                tail.next = node;
            tail = node;
            ++count;
        }

        public void AppendFirst(T data)
        {
            ListNode<T> node = new ListNode<T>(data);
            node.next = head;
            head = node;
            if (count == 0) {
                tail = node;
            }
            ++count;
        }

        public bool Contains(T data)
        {
            ListNode<T> current = head;
            while (current != null)
            {
                if (current.data.Equals(data))
                    return true;
                current = current.next;
            }
            return false;
        }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }
        public bool Remove(T data)
        {
            ListNode<T> current = head;
            ListNode<T> previous = null;

            while (current != null)
            {
                if (current.data.Equals(data))
                {
                    if (previous != null)
                    {
                        previous.next = current.next;
                        if (current.next == null)
                            tail = previous;
                    }
                    else
                    {
                        head = head.next;
                        if (head == null)
                            tail = null;
                    }
                    count--;
                    return true;
                }
                previous = current;
                current = current.next;
            }
            return false;
        }

        public void Reverse()
        {
            ListNode<T> previous = null,
                    current = head,
                    nextNode = head.next;
            while (nextNode != null)
            {
                current.next = previous;
                previous = current;
                current = nextNode;
                nextNode = current.next;
            }
            current.next = previous;
            tail = head;
            head = current;
        }
        IEnumerator IEnumerable.GetEnumerator() {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            ListNode<T> current = head;
            while (current != null) {
                yield return current.data;
                current = current.next;
            }
        }
    }
}

