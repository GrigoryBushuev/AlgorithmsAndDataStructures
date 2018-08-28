using System.Collections.Generic;
using System.Linq;

namespace DataStructures.Nonlinear.Graphs
{
    /// <summary>
    /// The crux of the method is that its traverse starts from source and explores its adjacent vertexes first.
    /// 
    /// 1. Add current vertex to the queue.
    /// 2. While the queue is not empty dequeue a vertex from the queue and get its adjacent vertexes. 
    /// 3. To avoid cycles mark an each adjacent vertex as visited.
    /// 4. Each adjacent vertex add to collection of edges to the current vertex.
    /// 5. Add each adjacent vertex to the queue.
    /// 
    /// Advantages: The BFS allows to find the optimal path to the target vertex.
    /// Disadvantages: The BFS requires a queue as an additional data structure.
    /// 
    /// Applications: Garbage collectors. Serialization/Deserialization algorithms.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BreathFirstSearch<T> : IGraphSearch
    {
        private AdjacencyListGraph<T> _graph;
        private int _sourceVertexIndex;
        private bool[] _visited;
        private int[] _pathTo; 


        public BreathFirstSearch(AdjacencyListGraph<T> graph, int sourceVertexIndex)
        {
            _graph = graph;
            _sourceVertexIndex = sourceVertexIndex;
            _visited = new bool[_graph.VertexesCount];
            _pathTo = new int[graph.EdgesCount];
            Search(sourceVertexIndex);
        }

        private void Search(int sourceVertexIndex)
        {
            var queue = new Queue<int>();
            queue.Enqueue(sourceVertexIndex);

            while (queue.Any()) {
                var currentVertexIndex = queue.Dequeue();
                foreach (var vertexIndex in _graph.GetAdjacents(currentVertexIndex))
                {
                    if (_visited[vertexIndex])
                        continue;

                    _visited[vertexIndex] = true;
                    _pathTo[vertexIndex] = currentVertexIndex;
                    queue.Enqueue(vertexIndex);
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

            var result = new Stack<int>();
            for (var x = toVertexIndex; x != _sourceVertexIndex; x = _pathTo[x])
            {
                result.Push(x);
            }
            result.Push(_sourceVertexIndex);
            return result;
        }
    }
}
