using DataStructures.Nonlinear.Graphs;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using Xunit;

namespace DataStructures.Tests.Nonlinear.Graphs
{
    [Trait("Category", "DepthFirstSearch")]
    public class DepthFirstSearchTest
    {
        private AdjacencyListGraph<int> _graph;
        public DepthFirstSearchTest()
        {
            _graph = new AdjacencyListGraph<int>();
            _graph.AddVertex(0);
            _graph.AddVertex(1);
            _graph.AddVertex(2);
            _graph.AddVertex(3);
            _graph.AddVertex(4);
            _graph.AddVertex(5);
            _graph.AddVertex(6);
            _graph.AddVertex(7);
            _graph.AddVertex(8);
            _graph.AddVertex(9);
            _graph.AddVertex(10);
            _graph.AddVertex(11);
            _graph.AddVertex(12);

            _graph.AddEdge(0, 1);
            _graph.AddEdge(0, 2);
            _graph.AddEdge(0, 5);
            _graph.AddEdge(0, 6);
            _graph.AddEdge(3, 4);
            _graph.AddEdge(3, 5);
            _graph.AddEdge(4, 5);
            _graph.AddEdge(4, 6);
            _graph.AddEdge(7, 8);
            _graph.AddEdge(9, 10);
            _graph.AddEdge(9, 11);
            _graph.AddEdge(9, 12);
            _graph.AddEdge(11, 12);
            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
        }

        [Theory]
        [InlineData(0, 4, true)]
        [InlineData(10, 4, false)]
        [InlineData(10, 12, true)]
        public void HasPathTo_OnValidParameters_ReturnsExpectedResult(int fromVertexIndex, int toVertexIndex, bool expectedResult)
        {
            var dfs = new DepthFirstSearch<int>(_graph, fromVertexIndex);
            var actualResult = dfs.HasPathTo(toVertexIndex);
            Assert.Equal(expectedResult, actualResult);
        }

        [Theory]
        [InlineData(0, 4, new int[] { 0, 5, 3, 4 })]
        [InlineData(10, 4, new int[] { })]
        [InlineData(10, 12, new int[] { 10, 9, 11, 12 })]
        public void GetPathTo_OnValidParameters_ReturnsExpectedResult(int fromVertexIndex, int toVertexIndex, IEnumerable<int> expectedPath)
        {
            var dfs = new DepthFirstSearch<int>(_graph, fromVertexIndex);
            var actualResult = dfs.GetPathTo(toVertexIndex);
            Assert.Equal(expectedPath, actualResult);
        }
    }
}
