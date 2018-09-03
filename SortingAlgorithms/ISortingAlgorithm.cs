using System;

namespace SortingAlgorithms
{
    public interface ISortingAlgorithm<T> where T : IComparable<T>
    {
        void Sort(T[] arrayToSort);
    }
}
