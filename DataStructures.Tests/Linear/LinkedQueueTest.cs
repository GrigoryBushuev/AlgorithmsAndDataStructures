using DataStructures.Linear;
using System.Globalization;
using System.Threading;
using Xunit;

namespace DataStructures.Tests.Linear
{
    [Trait("Category", "LinkedQueue<T>")]
    public class LinkedQueueTest
    {
        private readonly LinkedQueue<int> _queue;

        public LinkedQueueTest()
        {
            _queue = new LinkedQueue<int>();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        }

        [Theory]
        [InlineData(new[] { 0 })]
        [InlineData(new[] { 0, 1 })]
        [InlineData(new[] { 0, 1, 2 })]
        [InlineData(new[] { 0, 1, 2, 3 })]
        public void Enqueue_OnValidParam_ContainsEnqueuedItems(int[] expectedItems)
        {
            foreach (var item in expectedItems)
            {
                _queue.Enqueue(item);
            }
            Assert.Equal(expectedItems, _queue);
        }

        [Theory]
        [InlineData(new[] { 0 }, 0)]
        [InlineData(new[] { 0, 1 }, 0)]
        [InlineData(new[] { 0, 1, 2 }, 0)]
        [InlineData(new[] { 0, 1, 2, 3 }, 0)]
        public void Dequeue_ReturnsExpectedResult(int[] items, int expectedResult)
        {
            foreach (var item in items)
            {
                _queue.Enqueue(item);
            }
            var actualResult = _queue.Dequeue();
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(new[] { 0 }, 0)]
        [InlineData(new[] { 0, 1 }, 0)]
        [InlineData(new[] { 0, 1, 2 }, 0)]
        [InlineData(new[] { 0, 1, 2, 3 }, 0)]
        public void Dequeue_DoesNotContainDequeuedItem(int[] items, int expectedResult)
        {
            foreach (var item in items)
            {
                _queue.Enqueue(item);
            }
            _queue.Dequeue();
            Assert.DoesNotContain(expectedResult, _queue);
        }

        [Theory]
        [InlineData(new[] { 0 }, 0)]
        [InlineData(new[] { 0, 1 }, 0)]
        [InlineData(new[] { 0, 1, 2 }, 0)]
        [InlineData(new[] { 0, 1, 2, 3 }, 0)]
        public void Peek_ReturnsExpectedResult(int[] items, int expectedResult)
        {
            foreach (var item in items)
            {
                _queue.Enqueue(item);
            }
            var actualResult = _queue.Peek();
            Assert.Equal(expectedResult, actualResult);
        }
    }
}
