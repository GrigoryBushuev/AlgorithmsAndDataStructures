namespace DynamicConnectivity
{
    /// <summary>
    /// WeightenedQuickUnion keeps track of the sizes of connected components
    /// and use these sizes in union operation to make its tree more balanced.
    /// The union updates 
    /// </summary>
    public class WeightedQuickUnion
    {
        private readonly int[] _components;
        private int[] _sizes;

        public WeightedQuickUnion(int num)
        {
            _components = new int[num];
            _sizes = new int[num];

            for (var i = 0; i < num; i++)
            {
                _components[i] = i;
                _sizes[i] = 1;
            }
        }

        /// <summary>
        /// Returns true if p and q are in the same component
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        /// <returns></returns>
        public bool IsConnected(int p, int q)
        {
            return Find(p) == Find(q);
        }

        /// <summary>
        /// Add connection between p and q
        /// </summary>
        /// <param name="p"></param>
        /// <param name="q"></param>
        public void Union(int p, int q)
        {
            if (p == q)
                return;

            var pRoot = Find(p);
            var qRoot = Find(q);

            //Check whether components are already connected
            if (pRoot == qRoot) return;

            if (_sizes[pRoot] >= _sizes[qRoot])
            {
                _components[qRoot] = pRoot;
                _sizes[pRoot] += _sizes[qRoot];
            }
            else
            {
                _components[pRoot] = qRoot;
                _sizes[qRoot] += _sizes[pRoot];
            }
        }

        /// <summary>
        /// Returns the root index of the searching component
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        private int Find(int index)
        {
            while (_components[index] != index)
                index = _components[index];

            return index;
        }
    }
}
