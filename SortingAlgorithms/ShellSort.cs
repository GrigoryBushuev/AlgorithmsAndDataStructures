using System;
using Utils;

namespace SortingAlgorithms
{
    public class ShellSort<T> : ISortingAlgorithm<T> where T : IComparable<T>
    {
        public void Sort(T[] arrayToSort)
        {
            if (arrayToSort is null)
                throw new ArgumentNullException(nameof(arrayToSort));

            var k = 1;

            while (k < arrayToSort.Length / 3)
                k = 3 * k + 1;

            while (k >= 1)
            {
                for (var i = k; i < arrayToSort.Length; i++)
                {
                    for (var j = i; j >= k && arrayToSort[j].CompareTo(arrayToSort[j - k]) < 0; j -= k)
                        arrayToSort.Swap(j, j - k);
                }
                k = k / 3;
            }
        }
    }
}