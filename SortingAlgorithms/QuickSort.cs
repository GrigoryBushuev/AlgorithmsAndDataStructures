using System;
using Utils;

namespace SortingAlgorithms
{
    public class QuickSort<T> : ISortingAlgorithm<T> where T : IComparable<T>
    {
        public void Sort(T[] arrayToSort)
        {
            if (arrayToSort is null)
                throw new ArgumentNullException(nameof(arrayToSort));

            Sort(arrayToSort, 0, arrayToSort.Count() - 1);
        }

        private int Partition(T[] arrayToSort, int lo, int hi)
        {
            var partitionIndex = lo;
            var partitionValue = arrayToSort[partitionIndex];

            var i = lo + 1;
            var j = hi;

            while (true)
            {
                while (i < hi && arrayToSort[i].CompareTo(partitionValue) <= 0) i++;
                while (j > lo && arrayToSort[j].CompareTo(partitionValue) > 0) j--;
                if (i >= j) break;
                arrayToSort.Swap(i, j);
            }
            arrayToSort.Swap(partitionIndex, j);
            return j;
        }

        private void Sort(T[] arrayToSort, int lo, int hi)
        {
            if (lo >= hi)
                return;

            var partitionIndex = Partition(arrayToSort, lo, hi);
            Sort(arrayToSort, lo, partitionIndex - 1);
            Sort(arrayToSort, partitionIndex + 1, hi);
        }
    }
}
