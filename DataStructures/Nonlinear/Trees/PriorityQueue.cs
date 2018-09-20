using System;
using System.Collections.Generic;
using Utils;

namespace DataStructures.Nonlinear.Trees
{
    //         7
    //       /   \
    //	    5     6
    //     / \   / \
    //    4   3 2   1
    //
    // 0 1 2 3 4 5 6 7
    // _ 7 5 6 4 3 2 1
    //
    // 0 1 2 3 4 5 6 7
    // _ 6
    //
    // 0 1 2 3 4 5 6 7
    // _ 6 5
    //
    // 0 1 2 3 4 5 6 7
    // _ 7 6 5
    //
    // 0 1 2 3 4 5 6 7
    // _ 7 6 5
    //
    // Enqueue
    // 1. Move a new item to the end 
    // 2. lastIndex++;
    // 3. Swim last index's item until it's priority is higher than (curIndex / 2) index's item.
    //
    // Dequeue
    // 1. Return top
    // 2. Move last index's item on top
    // 3. Sink top index's item until it's priority is lower than Max((curIndex * 2), (curIndex * 2 + 1)) index's item.

    public class PriorityQueue<T>
    {
        private T[] _heap;
        private readonly IComparer<T> _comparer;
        private int _lastIndex = 0;

        public PriorityQueue(IComparer<T> comparer, int initSize = 1)
        {
            _comparer = comparer;
            _heap = new T[initSize + 1];
        }

        public void Enqueue(T item)
        {
            if (_lastIndex == _heap.Length - 1)
                Array.Resize(ref _heap, _heap.Length << 1);
            _lastIndex++;
            Swim(item);
        }

        public T Dequeue()
        {
            if (_lastIndex == 0)
                throw new InvalidOperationException("The queue is empty");
            var item = _heap[1];
            Sink();
            _heap[_lastIndex] = default(T);
            _lastIndex--;
            if (_lastIndex < _heap.Length >> 1)
                Array.Resize(ref _heap, _heap.Length >> 1);
            return item;
        }

        public T Peek()
        {
            if (_lastIndex == 0)
                throw new InvalidOperationException("The queue is empty");

            return _heap[1];
        }

        private void Sink()
        {
            _heap[1] = _heap[_lastIndex];
            var item = _heap[1];
            var leftIndex = 1;
            var rightIndex = 2;

            while (rightIndex < _lastIndex && _comparer.Compare(_heap[leftIndex], _heap[rightIndex]) > 0)
            {
                if (_comparer.Compare(_heap[rightIndex], _heap[rightIndex + 1]) > 0)
                    rightIndex++;
                _heap.Swap(leftIndex, rightIndex);
                leftIndex = rightIndex;
                rightIndex <<= 1;
            }
        }

        private void Swim(T item)
        {
            _heap[_lastIndex] = item;
            var rightIndex = _lastIndex;
            var leftIndex = rightIndex >> 1;
            while (leftIndex > 0 && _comparer.Compare(item, _heap[leftIndex]) < 0)
            {
                _heap.Swap(leftIndex, rightIndex);
                rightIndex = leftIndex;
                leftIndex >>= 1;
            }
        }
    }
}