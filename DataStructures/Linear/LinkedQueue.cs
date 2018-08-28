using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures.Linear
{
    /// <summary>
    /// The Queue<T> implementation is based on LinkedList<T>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkedQueue<T> : IEnumerable<T>
    {
        private LinkedList<T> _linkedList = new LinkedList<T>();

        public void Enqueue(T data)
        {
            _linkedList.AddLast(data);
        }

        public T Peek()
        {
            if (_linkedList.IsEmpty)
                throw new InvalidOperationException();

            return _linkedList.First.Value;
        }

        public T Dequeue()
        {
            if (_linkedList.IsEmpty)
                throw new InvalidOperationException();

            return _linkedList.RemoveFirst().Value;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var node in _linkedList)
            {
                yield return node;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
