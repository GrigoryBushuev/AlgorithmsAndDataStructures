using System;
using Xunit;

namespace SortingAlgorithms.Tests
{
    public class CountingSortTest
    {
        [Theory]
        [InlineData(new int[] { 1 }, new[] { 1 })]
        [InlineData(new int[] { 1, 2, 3 }, new[] { 1, 2, 3 })]
        [InlineData(new int[] { 3, 2, 1 }, new[] { 1, 2, 3 })]
        public void Sort_ReturnsExpectedResult(int[] array, int[] expectedResult)
        {
            CountingSort.Sort(array);
            Assert.Equal(expectedResult, array);
        }

        public void Sort_OnNullParam_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentNullException>(() => CountingSort.Sort(null));
            Assert.Equal("arrayToSort", ex.ParamName);
        }

        public void Sort_OnNegativeParam_ThrowsArgumentNullException()
        {
            var ex = Assert.Throws<ArgumentOutOfRangeException>(() => CountingSort.Sort(new int[] { -1, 0, 1 }));
            Assert.Equal("arrayToSort", ex.ParamName);
        }
    }
}
