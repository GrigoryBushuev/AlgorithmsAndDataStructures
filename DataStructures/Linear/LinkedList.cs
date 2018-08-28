using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Linear
{
    public class LinkedList<T> : IEnumerable<T>
    {
        public LinkedList() { }

        public LinkedList(IEnumerable<T> data)
        {
            foreach (var node in data)
            {
                AddFirst(node);
            }
        }

        public LinkedListNode<T> First { get; private set; }

        public LinkedListNode<T> Last { get; private set; }

        public int Count { get; private set; }

        public bool IsEmpty
        {
            get { return Count == 0; }
        }

        public LinkedListNode<T> AddFirst(T data)
        {
            LinkedListNode<T> newNode = new LinkedListNode<T>(data);
            if (First is null)
            {
                First = Last = newNode;
            }
            else
            {
                First.Prev = newNode;
                newNode.Next = First;
                First = newNode;
            }
            Count++;
            return newNode;
        }

        public LinkedListNode<T> AddLast(T data)
        {
            var newNode = new LinkedListNode<T>(data);
            if (Last is null)
            {
                First = Last = newNode;
            }
            else
            {
                Last.Next = newNode;
                newNode.Prev = Last;
                Last = newNode;
            }
            Count++;
            return newNode;
        }

        public LinkedListNode<T> RemoveFirst()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            var result = First;
            First = First.Next;
            if (First != null)
                First.Prev = null;
            Count--;
            result.Invalidate();
            return result;
        }

        public LinkedListNode<T> RemoveLast()
        {
            if (IsEmpty)
                throw new InvalidOperationException();

            var result = Last;
            Last = Last.Prev;
            Last.Next = null;
            Count--;
            result.Invalidate();
            return result;
        }

        public void Clear()
        {
            LinkedListNode<T> curNode = First;
            while (curNode != null)
            {
                var tempNode = curNode.Next;
                curNode.Invalidate();
                curNode = null;
                curNode = tempNode;
            }
            First = null;
            Last = null;
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            LinkedListNode<T> curNode = First;
            while (curNode != null)
            {
                yield return curNode.Value;
                curNode = curNode.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
