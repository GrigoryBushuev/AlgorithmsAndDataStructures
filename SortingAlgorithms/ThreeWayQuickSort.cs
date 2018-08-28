using System;
using System.Collections.Generic;
using Utils;

namespace SortingAlgorithms
{
    public class ThreeWayQuickSort<T> : ISortingAlgorithm<T> where T : IComparable<T>
    {
        public void Sort(IEnumerable<T> collection)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));

            if (!(collection is T[] arrayToSort))
                throw new InvalidCastException(nameof(collection));

            Sort(arrayToSort, 0, arrayToSort.Length - 1);
        }

        private void Sort(T[] arrayToSort, int loIndex, int hiIndex)
        {
            if (loIndex >= hiIndex)
                return;

            var i = loIndex + 1;
            var gtIndex = hiIndex;
            var ltIndex = loIndex;

            T vRes = arrayToSort[loIndex];
            while (i <= gtIndex)
            {
                var cmp = arrayToSort[i].CompareTo(vRes);
                if (cmp < 0)
                    arrayToSort.Swap(ltIndex++, i++);
                else if (cmp > 0)
                    arrayToSort.Swap(i, gtIndex--);
                else
                    i++;
            }

            Sort(arrayToSort, loIndex, ltIndex - 1);
            Sort(arrayToSort, gtIndex + 1, hiIndex);
        }
    }
}
