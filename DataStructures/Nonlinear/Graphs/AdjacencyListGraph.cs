using System;
using System.Collections.Generic;

namespace DataStructures.Nonlinear.Graphs
{
    public class AdjacencyListGraph<T>
    {
        private readonly Dictionary<int, Node> _nodes = new Dictionary<int, Node>();
        private int _edgesNumber = 0;

        private class Node
        {
            public T Data { get; set; }

            public Linear.List<int> Adjacents { get; set; }
        }

        public int AddVertex(T data)
        {
            _nodes.Add(_nodes.Count, new Node()
            {
                Data = data
                , Adjacents = new Linear.List<int>()
            });
            return _nodes.Count - 1;
        }

        public int VertexesCount => _nodes.Count;

        public int EdgesCount => _edgesNumber;

        private void CheckVertexIndex(int vertexIndex)
        {
            if (vertexIndex < 0 || vertexIndex >= _nodes.Count)
                throw new ArgumentOutOfRangeException(nameof(vertexIndex));
        }

        public T GetData(int vertexIndex)
        {
            CheckVertexIndex(vertexIndex);
            return _nodes[vertexIndex].Data;
        }

        public IEnumerable<int> GetAdjacents(int vertexIndex)
        {
            CheckVertexIndex(vertexIndex);
            return _nodes[vertexIndex].Adjacents;
        }

        public void AddEdge(int fromVertexIndex, int toVertexIndex)
        {
            CheckVertexIndex(fromVertexIndex);
            CheckVertexIndex(toVertexIndex);

            _edgesNumber++;
            if (!_nodes[fromVertexIndex].Adjacents.Contains(toVertexIndex))
                _nodes[fromVertexIndex].Adjacents.Add(toVertexIndex);

            if (!_nodes[toVertexIndex].Adjacents.Contains(fromVertexIndex))
                _nodes[toVertexIndex].Adjacents.Add(fromVertexIndex);

        }
    }
}
