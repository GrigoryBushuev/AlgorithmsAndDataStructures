using System.Collections.Generic;

namespace DataStructures.Nonlinear.Graphs
{
    public interface IGraphSearch
    {
        IEnumerable<int> GetPathTo(int toVertexIndex);

        bool HasPathTo(int toVertexIndex);
    }
}
