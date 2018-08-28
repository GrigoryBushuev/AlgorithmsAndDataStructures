using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Linear
{
    /// <summary>
    /// The Stack<T> implementation is based on LinkedList<T>
    /// </summary>
    public class LinkedStack<T> : IEnumerable<T>
    {
        private LinkedList<T> _linkedList = new LinkedList<T>();

        public void Push(T data)
        {
            _linkedList.AddFirst(data);
        }

        public T Peek()
        {
            if (_linkedList.IsEmpty)
                throw new InvalidOperationException();

            return _linkedList.First.Value;
        }

        public T Pop()
        {
            if (_linkedList.IsEmpty)
                throw new InvalidOperationException();

            return _linkedList.RemoveFirst().Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in _linkedList)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}