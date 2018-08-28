using System.Globalization;
using System.Linq;
using System.Threading;
using Xunit;

namespace DataStructures.Tests.Linear
{
    [Trait("Category", "LinkedList")]
    public class LinkedListTest
    {
        private readonly DataStructures.Linear.LinkedList<int> _linkedList;

        public LinkedListTest()
        {
            _linkedList = new DataStructures.Linear.LinkedList<int>();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        }

        [Theory]
        [InlineData(new[] { 0, 1, 2 })]
        public void AddFirst_OnValidParam_ContainsExpectedItems(int[] expectedItems)
        {
            foreach (var item in expectedItems)
            {
                _linkedList.AddFirst(item);
            }
            Assert.Contains(expectedItems, item => _linkedList.Contains(item));
        }

        [Theory]
        [InlineData(new[] { 0, 1, 2 })]
        public void AddLast_OnValidParam_ContainsExpectedItems(int[] expectedItems)
        {
            foreach (var item in expectedItems)
            {
                _linkedList.AddLast(item);
            }
            Assert.Contains(expectedItems, item => _linkedList.Contains(item));
        }

        [Theory]
        [InlineData(new[] { 0, 1, 2 }, 2)]
        public void RemoveFirst_OnValidParam_DoesNotContainRemovedFirstItem(int[] itemsToAdd, int removedItem)
        {
            foreach (var item in itemsToAdd)
            {
                _linkedList.AddFirst(item);
            }
            _linkedList.RemoveFirst();
            Assert.DoesNotContain(removedItem, _linkedList);
        }

        [Theory]
        [InlineData(new[] { 0, 1, 2 }, 2)]
        public void RemoveLast_OnValidParam_DoesNotContainRemovedLastItem(int[] itemsToAdd, int removedItem)
        {
            foreach (var item in itemsToAdd)
            {
                _linkedList.AddLast(item);
            }
            _linkedList.RemoveLast();
            Assert.DoesNotContain(removedItem, _linkedList);
        }

        [Theory]
        [InlineData(new[] { 0, 1, 2 }, 3)]
        [InlineData(new[] { 0, 1 }, 2)]
        [InlineData(new[] { 0 }, 1)]
        [InlineData(new int[] { }, 0)]
        public void Count_ReturnsExpectedResult(int[] itemsToAdd, int expectedResult)
        {
            foreach (var item in itemsToAdd)
            {
                _linkedList.AddLast(item);
            }
            var actualResult = _linkedList.Count;
            Assert.Equal(actualResult, expectedResult);
        }
    }
}