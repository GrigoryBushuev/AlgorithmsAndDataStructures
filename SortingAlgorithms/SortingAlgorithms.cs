using System;

namespace SortingAlgorithms
{
    public static class SortingAlgorithms
    {
        public static void Sort<T>(this T[] arrayToSort, ISortingAlgorithm<T> sortingAlgorithm) where T : IComparable<T>
        {
            if (arrayToSort is null)
                throw new ArgumentNullException(nameof(arrayToSort));

            if (sortingAlgorithm is null)
                throw new ArgumentNullException(nameof(sortingAlgorithm));

            sortingAlgorithm.Sort(arrayToSort);
        }
    }
}
