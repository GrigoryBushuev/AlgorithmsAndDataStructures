using DataStructures.Linear;
using System;
using System.Globalization;
using System.Threading;
using Xunit;

namespace DataStructures.Tests.Linear
{
    [Trait("Category", "List<T>")]
    public class ListTests
    {
        private List<int> _list = null;

        public ListTests()
        {
            _list = new List<int>();
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        }

        [Theory]
        [InlineData(new[] { 0 })]
        [InlineData(new[] { 0, 1 })]
        [InlineData(new[] { 0, 1, 2 })]
        [InlineData(new[] { 0, 1, 2, 3 })]
        public void Add_OnValidParam_ShouldAddElementToList(int[] items)
        {
            foreach (var item in items)
            {
                _list.Add(item);
            }
            Assert.Equal(items, _list);
        }

        [Theory]
        [InlineData(new[] { 0 }, 0, 0)]
        [InlineData(new[] { 0, 1 }, 1, 1)]
        [InlineData(new[] { 0, 1, 2 }, 2, 2)]
        [InlineData(new[] { 0, 1, 2, 3 }, 3, 3)]
        public void IndexerGet_ShouldReturnExpectedValueByIndex(int[] items, int index, int expectedResult)
        {
            foreach (var item in items)
            {
                _list.Add(item);
            }
            var actualResult = _list[index];
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(1)]
        public void IndexerGet_OnOutOfRangeIndex_ShouldThrowArgumentOutOfRangeException(int index)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                var res = _list[index];
            });
        }

        [Theory]
        [InlineData(new[] { 0 }, 0, 1)]
        [InlineData(new[] { 0, 1 }, 1, 2)]
        [InlineData(new[] { 0, 1, 2 }, 2, 3)]
        [InlineData(new[] { 0, 1, 2, 3 }, 3, 4)]
        public void IndexerSet_ShouldContainExpectedValueByIndex(int[] items, int index, int expectedResult)
        {
            foreach (var item in items)
            {
                _list.Add(item);
            }
            _list[index] = expectedResult;
            var actualResult = _list[index];
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(1)]
        public void IndexerSet_OnOutOfRangeIndex_ShouldThrowArgumentOutOfRangeException(int index)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                _list[index] = Int32.MaxValue;
            });
        }

        [Theory]
        [InlineData(new[] { 0 }, 1)]
        [InlineData(new[] { 0, 1 }, 2)]
        [InlineData(new[] { 0, 1, 2 }, 3)]
        [InlineData(new[] { 0, 1, 2, 3 }, 4)]
        public void Count_AfterAdd_ReturnsExpectedResult(int[] items, int expectedResult)
        {
            foreach (var item in items)
            {
                _list.Add(item);
            }
            var actualResult = _list.Count;
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(new[] { 0 })]
        [InlineData(new[] { 0, 1 })]
        [InlineData(new[] { 0, 1, 2 })]
        [InlineData(new[] { 0, 1, 2, 3 })]
        public void Clear_RemovesAllItemsFromList(int[] items)
        {
            foreach (var item in items)
            {
                _list.Add(item);
            }
            _list.Clear();
            Assert.Empty(_list);
        }

        [Theory]
        [InlineData(new[] { 0 }, 0, true)]
        [InlineData(new[] { 0, 1 }, 1, true)]
        [InlineData(new[] { 0, 1, 2 }, 2, true)]
        [InlineData(new[] { 0, 1, 2, 3 }, 4, false)]
        [InlineData(new[] { 0, 1, 2, 3 }, 6, false)]
        public void Contains_ReturnsExpectedResult(int[] items, int valueToFind, bool expectedResult)
        {
            foreach (var item in items)
            {
                _list.Add(item);
            }
            var actualResult = _list.Contains(valueToFind);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(new[] { 0 }, 0, 0)]
        [InlineData(new[] { 0, 1 }, 1, 1)]
        [InlineData(new[] { 0, 1, 2 }, 2, 2)]
        [InlineData(new[] { 0, 1, 2, 3 }, 4, -1)]
        [InlineData(new[] { 0, 1, 2, 3 }, 6, -1)]
        public void Index_ReturnsExpectedResult(int[] items, int valueToFind, int expectedResult)
        {
            foreach (var item in items)
            {
                _list.Add(item);
            }
            var actualResult = _list.IndexOf(valueToFind);
            Assert.Equal(expectedResult, actualResult);
        }


        [Fact]
        public void IsReadOnly_ReturnsFalse()
        {
            Assert.False(_list.IsReadOnly);
        }

        [Theory]
        [InlineData(new[] { 0 }, 0, new[] { 0 })]
        [InlineData(new[] { 0, 1 }, 1, new[] { 0, 0, 1 })]
        [InlineData(new[] { 0, 1, 2 }, 0, new[] { 0, 1, 2 })]
        [InlineData(new[] { 0, 1, 2, 3 }, 4, new[] { 0, 0, 0, 0, 0, 1, 2, 3 })]
        public void CopyTo_ContainsExpectedItems(int[] items, int index, int[] expectedItems)
        {
            foreach (var item in items)
            {
                _list.Add(item);
            }
            var actualResult = new int[expectedItems.Length];
            _list.CopyTo(actualResult, index);
            Assert.Equal(expectedItems, actualResult);
        }

        [Fact]
        public void CopyTo_OnNullArrayParam_ThorwsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => _list.CopyTo(null, 0));
        }

        [Theory]
        [InlineData(new[] { 0 }, 0, new int[] { })]
        [InlineData(new[] { 0, 1 }, 1, new[] { 0 })]
        [InlineData(new[] { 0, 1, 2 }, 0, new[] { 1, 2 })]
        [InlineData(new[] { 0, 1, 2, 3 }, 3, new[] { 0, 1, 2 })]
        public void RemoveAt_OnValidParams_RemovesExpectedItems(int[] items, int index, int[] expectedItems)
        {
            foreach (var item in items)
            {
                _list.Add(item);
            }
            _list.RemoveAt(index);
            Assert.Equal(expectedItems, _list);
        }

        [Theory]
        [InlineData(new int[] { }, 0)]
        [InlineData(new[] { 0 }, 1)]
        [InlineData(new[] { 0, 1 }, -1)]
        public void RemoveAt_OnInvalidIndex_ThrowsArgumentOutOfRangeException(int[] items, int index)
        {
            foreach (var item in items)
            {
                _list.Add(item);
            }
            Assert.Throws<ArgumentOutOfRangeException>(() => _list.RemoveAt(index));
        }

        [Theory]
        [InlineData(new int[] { }, 0, Int32.MaxValue)]
        [InlineData(new[] { 0 }, 1, Int32.MaxValue)]
        [InlineData(new[] { 0, 1 }, 1, Int32.MaxValue)]
        public void Insert_OnValidParams_ContainsExpectedItem(int[] items, int index, int expectedItem)
        {
            foreach (var item in items)
            {
                _list.Add(item);
            }
            _list.Insert(index, expectedItem);
            Assert.Equal(expectedItem, _list[index]);
            Assert.Contains(expectedItem, _list);
        }

        [Theory]
        [InlineData(new int[] { }, 1, Int32.MinValue)]
        [InlineData(new[] { 0 }, 5, Int32.MinValue)]
        [InlineData(new[] { 0, 1 }, -1, Int32.MinValue)]
        public void Insert_OnInvalidIndex_ThrowsArgumentOutOfRangeException(int[] items, int index, int itemValue)
        {
            foreach (var item in items)
            {
                _list.Add(item);
            }
            Assert.Throws<ArgumentOutOfRangeException>(() => _list.Insert(index, itemValue));
        }

        [Theory]
        [InlineData(new int[] { }, 0, false)]
        [InlineData(new[] { 0 }, 0, true)]
        [InlineData(new[] { 0, 1 }, 1, true)]
        public void Remove_ReturnsExpectedValue(int[] items, int itemToRemove, bool expectedResult)
        {
            foreach (var item in items)
            {
                _list.Add(item);
            }
            var actualResult = _list.Remove(itemToRemove);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(new int[] { }, 0, new int[] { })]
        [InlineData(new[] { 0 }, 0, new int[] { })]
        [InlineData(new[] { 0, 1 }, 1, new[] { 0 })]
        public void Remove_ListContainsExpectedValue(int[] items, int itemToRemove, int[] expectedResult)
        {
            foreach (var item in items)
            {
                _list.Add(item);
            }
            _list.Remove(itemToRemove);
            Assert.Equal(expectedResult, _list);
        }
    }
}
