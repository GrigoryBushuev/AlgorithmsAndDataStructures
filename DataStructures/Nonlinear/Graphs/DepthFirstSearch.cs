using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Nonlinear.Graphs
{
    /// <summary>
    /// The crux of the method is that it starts from the source vertex and traverses recursively for each adjacent vertex.
    /// 
    /// DFS is using the recursive approach to find connections between vertexes in a graph.
    /// On each recursive iteration 
    /// 1. Get adjacency list of the current vertex. 
    /// 2. To avoid cycles mark the current vertex as visited.
    /// 3. Add an index of adjacent vertex to the list of edges to the current vertex.
    /// 4. For each adjacent vertex make a recursive call of step 1
    /// 
    /// Advantages: In case of the recursive version the method doesn't require an additional data structure 
    /// Disadvantages: the method finds the first path to the target vertex which may not be an optimal path. 
    /// It's possible to get a Stackoverflow exception for the recursive version. The problem can be resolved by using an additional data structure - Stack
    /// 
    /// 
    /// Applications: The algorithm can used to find connected components
    /// </summary>
    public class DepthFirstSearch<T> : IGraphSearch
    {
        private bool[] _visited;
        private int[] _edgesTo;
        private AdjacencyListGraph<T> _graph;
        private int _sourceVertexIndex;

        public DepthFirstSearch(AdjacencyListGraph<T> graph, int sourceVertexIndex)
        {
            _graph = graph;
            _sourceVertexIndex = sourceVertexIndex;
            _visited = new bool[graph.VertexesCount];
            _edgesTo = new int[graph.EdgesCount];
            Search(sourceVertexIndex);
        }

        private void Search(int fromVertexIndex)
        {
            _visited[fromVertexIndex] = true;
            foreach (var vertex in _graph.GetAdjacents(fromVertexIndex))
            {
                if (!_visited[vertex])
                {
                    _edgesTo[vertex] = fromVertexIndex;
                    Search(vertex);
                }
            }
        }

        public bool HasPathTo(int toVertexIndex)
        {
            return _visited[toVertexIndex];
        }

        public IEnumerable<int> GetPathTo(int toVertexIndex)
        {
            if (!HasPathTo(toVertexIndex))
                return Enumerable.Empty<int>();

            var stack = new Stack<int>();
            for (var x = toVertexIndex; x != _sourceVertexIndex; x = _edgesTo[x])
            {
                stack.Push(x);
            }
            stack.Push(_sourceVertexIndex);
            return stack;
        } 
    }
}
