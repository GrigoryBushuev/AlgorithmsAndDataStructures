using DataStructures.Nonlinear.Trees;
using System;
using System.Collections.Generic;
using Xunit;

namespace DataStructures.Tests.Nonlinear
{
    [Trait("Category", "PriorityQueue")]
    public class PriorityQueueTest
    {
        private PriorityQueue<int> _priorityQueue;

        private class TestComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                return -x.CompareTo(y);
            }
        }

        public PriorityQueueTest()
        {
            _priorityQueue = new PriorityQueue<int>(new TestComparer());
        }

        [Fact]
        public void Constructor_ComparerIsNull_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>("comparer", () => new PriorityQueue<int>(null));
        }

        [Fact]
        public void Peek_OnEmptyQueue_ThrowsInvalidOperationException()
        {
            var pq = new PriorityQueue<int>(new TestComparer());
            Assert.Throws<InvalidOperationException>(() => pq.Peek());
        }

        [Fact]
        public void Size_OnEmptyQueue_ReturnsExpectedResult()
        {
            var pq = new PriorityQueue<int>(new TestComparer());
            Assert.Equal(0, pq.Size);
        }

        [Fact]
        public void Dequeue_OnEmptyQueue_ThrowsInvalidOperationException()
        {
            var pq = new PriorityQueue<int>(new TestComparer());
            Assert.Throws<InvalidOperationException>(() => pq.Dequeue());
        }

        [Theory]
        [InlineData(new[] { 0, 1, 2, 3, 4, 5, 6, 7 }, 7, 8)]
        [InlineData(new[] { 7, 6, 5, 4, 3, 2, 1, 0 }, 7, 8)]
        [InlineData(new[] { 4, 2, 5, 6, 7, 0, 1, 3 }, 7, 8)]
        public void Enqueue_ReturnsExpectedResult(int[] items, int expectedPeekValue, int expectedSize)
        {
            for (var i = 0; i < items.Length; i++)
            {
                _priorityQueue.Enqueue(items[i]);

            }
            Assert.Equal(expectedSize, _priorityQueue.Size);
            Assert.Equal(expectedPeekValue, _priorityQueue.Peek());
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 4, 5, 6, 7 }, new[] { 7, 6, 5, 4, 3, 2, 1 }, new[] { 6, 5, 4, 3, 2, 1 }, new[] { 6, 5, 4, 3, 2, 1, 0 })]
        [InlineData(new[] { 7, 6, 5, 4, 3, 2, 1, 0 }, new[] { 7, 6, 5, 4, 3, 2, 1, 0 }, new[] { 6, 5, 4, 3, 2, 1, 0 }, new[] { 7, 6, 5, 4, 3, 2, 1, 0 })]
        [InlineData(new[] { 4, 2, 5, 6, 7, 0, 1, 3 }, new[] { 7, 6, 5, 4, 3, 2, 1, 0 }, new[] { 6, 5, 4, 3, 2, 1, 0 }, new[] { 7, 6, 5, 4, 3, 2, 1, 0 })]
        public void Dequeue_ReturnsExpectedResult(int[] items, int[] expectedDequeueValues, int[] expectedPeekValues, int[] expectedSizes)
        {
            for (var i = 0; i < items.Length; i++)
            {
                _priorityQueue.Enqueue(items[i]);
            }

            for (var i = 0; i < items.Length; i++)
            {
                var actualDequeuedValue = _priorityQueue.Dequeue();
                Assert.Equal(expectedDequeueValues[i], actualDequeuedValue);
                Assert.Equal(expectedSizes[i], _priorityQueue.Size);
                if (i < items.Length - 1)
                    Assert.Equal(expectedPeekValues[i], _priorityQueue.Peek());
            }
        }

        [Theory]
        [InlineData(new[] { 1, 2, 3, 5 }, 5, 4, 5, 3, 3)]
        [InlineData(new[] { 7, 6, 3 }, 7, 3, 7, 6, 2)]
        [InlineData(new[] { 4, 2 }, 4, 2, 4, 2, 1)]
        public void Enqueue_Dequeue_ReturnsExpectedResult(int[] items, int expectedEnqueuedPeekValue, int expectedEnqueuedSize, int expectedDequeuedValue, int expectedDequeuedPeekValue, int expectedDequeuedSize)
        {
            foreach (var item in items)
            {
                _priorityQueue.Enqueue(item);
            }
            Assert.Equal(expectedEnqueuedPeekValue, _priorityQueue.Peek());
            Assert.Equal(expectedEnqueuedSize, _priorityQueue.Size);
            var actualDequeuedValue = _priorityQueue.Dequeue();
            Assert.Equal(expectedDequeuedValue, actualDequeuedValue);
            Assert.Equal(expectedDequeuedPeekValue, _priorityQueue.Peek());
            Assert.Equal(expectedDequeuedSize, _priorityQueue.Size);
        }
    }
}
