using DataStructures.Linear;
using Xunit;

namespace DataStructures.Tests.Linear
{
    [Trait("Category", "Stack")]
    public class StackTest
    {
        [Fact(Skip = "Rewrite")]
        public void PushTest()
        {
            var stack = new LinkedStack<int>();
            var expectedResult = 0;
            stack.Push(expectedResult);
            var actualResult = stack.Peek();
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact(Skip = "Rewrite")]
        public void PeekTest()
        {
            var stack = new LinkedStack<int>();
            var expectedResult = 0;
            stack.Push(expectedResult);
            var actualResult = stack.Peek();
            Assert.Equal(expectedResult, actualResult);
        }

        [Fact(Skip = "Rewrite")]
        public void PopTest()
        {
            var stack = new LinkedStack<int>();
            var expectedResult = 0;
            stack.Push(expectedResult);
            var actualResult = stack.Pop();
            Assert.Equal(expectedResult, actualResult);
        }
    }
}