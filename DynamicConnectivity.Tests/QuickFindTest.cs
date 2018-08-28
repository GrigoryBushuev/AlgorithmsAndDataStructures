using System.Globalization;
using System.Threading;
using Xunit;

namespace DynamicConnectivity.Tests
{
    [Trait("Category", "QuickFind")]
    public class QuickFindTest
    {
        private QuickFind _quickFind;

        public QuickFindTest()
        {
            _quickFind = new QuickFind(10);
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
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
        public void IsConnected_ReturnsExpectedResult(int p, int q, bool expectedResult)
        {
            //7-9 6-9 2-0 5-8 7-4 6-1 0-5 4-3 2-4 
            _quickFind.Union(p, q);
            var actualResult = _quickFind.IsConnected(p, q);
            Assert.Equal(expectedResult, actualResult);
        }
    }
}