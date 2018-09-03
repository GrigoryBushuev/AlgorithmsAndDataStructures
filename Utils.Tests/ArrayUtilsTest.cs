using System;
using System.Globalization;
using System.Threading;
using Xunit;

namespace Utils.Tests
{
    [Trait("Category", "ArrayUtils")]
    public class ArrayUtilsTest
    {
        private int[] _sortedArray;
        private int[] _unsortedArray;

        public ArrayUtilsTest()
        {
            _unsortedArray = new[] { 1, 2, 3, 4, 5, 17, 12, 19, 29, 23, 31, 34, 40, 50, 70, 76, 81, 87, 89 };
            _sortedArray = new[] { 11, 12, 17, 19, 23, 29, 31, 34, 40, 50, 70, 76, 81, 87, 89 };
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
        }

        [Fact]
        public void IsSorted_OnSortedArray_ReturnsTrue()
        {
            Assert.True(_sortedArray.IsSorted());
        }

        [Fact]
        public void IsSorted_OnUnsortedArray_ReturnsFalse()
        {
            Assert.False(_unsortedArray.IsSorted());
        }

        [Fact]
        public void IsSorted_OnNullParam_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ArrayUtils.IsSorted<int>(null));
        }

        [Theory]
        [InlineData(11)]
        [InlineData(89)]
        [InlineData(29)]
        public void Rank_OnNullParam_ThrowsArgumentNullException(int keyToFind)
        {
            Assert.Throws<ArgumentNullException>(() => ArrayUtils.Rank(null, keyToFind));
        }

        [Theory]
        [InlineData(11, 0)]
        [InlineData(89, 14)]
        [InlineData(29, 5)]
        public void Rank_OnValidParam_ReturnsExpectedResult(int keyToFind, int expectedResult)
        {
            var actualResult = _sortedArray.Rank(keyToFind);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(2)]
        public void Rank_OnInvalidParam_ReturnsNull(int keyToFind)
        {
            var actualResult = _sortedArray.Rank(keyToFind);
            Assert.Null(actualResult);
        }

        [Theory]
        [InlineData(0, 0, new[] { 11, 12, 17, 19, 23, 29, 31, 34, 40, 50, 70, 76, 81, 87, 89 })]
        [InlineData(0, 1, new[] { 12, 11, 17, 19, 23, 29, 31, 34, 40, 50, 70, 76, 81, 87, 89 })]
        [InlineData(0, 14, new[] { 89, 12, 17, 19, 23, 29, 31, 34, 40, 50, 70, 76, 81, 87, 11 })]
        public void Swap_OnValidParam_ReturnsExpectedResult(int i, int j, int[] expectedResult)
        {
            _sortedArray.Swap(i, j);
            Assert.Equal(expectedResult, _sortedArray);
        }

        [Theory]
        [InlineData(0, 0)]
        [InlineData(0, 1)]
        [InlineData(0, 14)]
        public void Swap_OnNullParam_ThrowsArgumentNullException(int i, int j)
        {
            Assert.Throws<ArgumentNullException>(() => ArrayUtils.Swap<int>(null, i, j));
        }

        [Theory]
        [InlineData(-1, 0)]
        [InlineData(15, 1)]
        public void Swap_OnOutOfRangeiParam_ThrowsArgumentNullException(int i, int j)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _sortedArray.Swap(i, j));
            Assert.Equal(nameof(i), ex.ParamName);
        }

        [Theory]
        [InlineData(0, -1)]
        [InlineData(1, 15)]
        public void Swap_OnOutOfRangejParam_ThrowsArgumentNullException(int i, int j)
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => _sortedArray.Swap(i, j));
            Assert.Equal(nameof(j), ex.ParamName);
        }

        [Theory]
        [InlineData(new[] { 0 }, true, true)]
        [InlineData(new[] { 0 }, false, true)]
        [InlineData(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, true, true)]
        [InlineData(new[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 }, false, false)]
        [InlineData(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, false, true)]
        [InlineData(new[] { 9, 8, 7, 6, 5, 4, 3, 2, 1, 0 }, true, false)]
        public void IsSorted_OnValidParam_ReturnsExpectedResult(int[] array, bool isAscendingOrder, bool expectedResult)
        {
            var actualResult = array.IsSorted(isAscendingOrder);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(new[] { 0 }, 1)]
        [InlineData(new[] { 0, 1 }, 2)]
        [InlineData(new[] { 0, 1, 2 }, 3)]
        public void Count_ReturnsExpectedResult(int[] array, int expectedResult)
        {
            var actualResult = array.Count();
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact]
        public void Count_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => ArrayUtils.Count<int>(null));
            Assert.Equal("array", ex.ParamName);
        }

    }
}
