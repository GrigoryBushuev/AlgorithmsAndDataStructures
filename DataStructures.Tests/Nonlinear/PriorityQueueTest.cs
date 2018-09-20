using DataStructures.Nonlinear.Trees;
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
        public void Size_OnEnqueue_ReturnsExpectedResult()
        {
            _priorityQueue.Enqueue(1);
            var actualResult = _priorityQueue.Size;
            Assert.Equal(1, actualResult);
            _priorityQueue.Enqueue(2);
            actualResult = _priorityQueue.Size;
            Assert.Equal(2, actualResult);
            _priorityQueue.Enqueue(3);
            actualResult = _priorityQueue.Size;
            Assert.Equal(3, actualResult);
        }
    }
}
