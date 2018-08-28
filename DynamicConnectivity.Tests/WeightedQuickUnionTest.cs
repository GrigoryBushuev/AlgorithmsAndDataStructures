using System.Globalization;
using System.Threading;
using Xunit;

namespace DynamicConnectivity.Tests
{
    [Trait("Category", "WeightedQuickUnion")]
    public class WeightedQuickUnionTest
    {
        private WeightedQuickUnion _connectedAfterUnionWeightedQuickUnionSut;
        private WeightedQuickUnion _connectedWeightedQuickUnionSut;

        public WeightedQuickUnionTest()
        {
            _connectedAfterUnionWeightedQuickUnionSut = new WeightedQuickUnion(10);
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            _connectedWeightedQuickUnionSut = new WeightedQuickUnion(10);
            //7-9  0 1 2 3 4 5 6 7 8 7  1 1 1 1 1 1 1 2 1 1
            _connectedWeightedQuickUnionSut.Union(7, 9);
            //6-9  0 1 2 3 4 5 7 7 8 7  1 1 1 1 1 1 1 3 1 1
            _connectedWeightedQuickUnionSut.Union(6, 9);
            //2-0  2 1 2 3 4 5 7 7 8 7  1 1 2 1 1 1 1 3 1 1
            _connectedWeightedQuickUnionSut.Union(2, 0);
            //5-8  2 1 2 3 4 5 7 7 5 7  1 1 2 1 1 2 1 3 1 1
            _connectedWeightedQuickUnionSut.Union(5, 8);
            //7-4  2 1 2 3 7 5 7 4 5 7  1 1 2 1 1 2 1 4 1 1 
            _connectedWeightedQuickUnionSut.Union(7, 4);
            //6-1  2 7 2 3 7 5 7 4 5 7  1 1 2 1 1 2 1 5 1 1
            _connectedWeightedQuickUnionSut.Union(6, 1);
            //0-5  2 7 2 3 7 2 7 7 5 7  1 1 4 1 1 2 1 5 1 1
            _connectedWeightedQuickUnionSut.Union(0, 5);
            //4-3  2 7 2 7 7 2 7 7 5 7  1 1 4 1 1 2 1 6 1 1
            _connectedWeightedQuickUnionSut.Union(4, 3);
            //2-4  2 7 7 7 7 2 7 7 5 7  1 1 4 1 1 2 1 10 1 1
            _connectedWeightedQuickUnionSut.Union(2, 4);
            //2-4  2 7 7 7 7 2 7 7 5 7  1 1 4 1 1 2 1 10 1 1
            _connectedWeightedQuickUnionSut.Union(2, 2);
            //2-7  2 7 7 7 7 2 7 7 5 7  1 1 4 1 1 2 1 10 1 1
            _connectedWeightedQuickUnionSut.Union(2, 7);
        }

        [Theory]
        [InlineData(7, 9, true)]
        [InlineData(6, 9, true)]
        [InlineData(2, 0, true)]
        [InlineData(5, 8, true)]
        [InlineData(7, 4, true)]
        [InlineData(6, 1, true)]
        [InlineData(0, 5, true)]
        [InlineData(4, 3, true)]
        [InlineData(2, 4, true)]
        [InlineData(2, 2, true)]
        [InlineData(2, 7, true)]
        public void IsConnected_AfterUnion_ReturnsExpectedResult(int p, int q, bool expectedResult)
        {
            //7-9 6-9 2-0 5-8 7-4 6-1 0-5 4-3 2-4
            //    0 1 2 3 4 5 6 7 8 9
            //7-9 0 1 2 3 4 5 6 7 8 7  1 1 1 1 1 1 1 2 1 1
            //6-9 0 1 2 3 4 5 6 7 8 7  1 1 1 1 1 1 1 2 1 1
            _connectedAfterUnionWeightedQuickUnionSut.Union(p, q);
            var actualResult = _connectedAfterUnionWeightedQuickUnionSut.IsConnected(p, q);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(7, 9, true)]
        [InlineData(6, 9, true)]
        [InlineData(2, 0, true)]
        [InlineData(5, 8, true)]
        [InlineData(7, 4, true)]
        [InlineData(6, 1, true)]
        [InlineData(0, 5, true)]
        [InlineData(4, 3, true)]
        [InlineData(2, 4, true)]
        [InlineData(2, 2, true)]
        [InlineData(2, 7, true)]
        public void IsConnected_ReturnsExpectedResult(int p, int q, bool expectedResult)
        {
            var actualResult = _connectedWeightedQuickUnionSut.IsConnected(p, q);
            Assert.Equal(expectedResult, actualResult);
        }


    }
}
