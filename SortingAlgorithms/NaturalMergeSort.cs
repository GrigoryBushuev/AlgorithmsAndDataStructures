using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
    public class NaturalMergeSort<T> : ISortingAlgorithm<T> where T : IComparable<T>
    {
        private T[] _auxiliaryArray;

        public void Sort(IEnumerable<T> collection)
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));

            if (!(collection is T[] arr))
                throw new InvalidCastException(nameof(collection));

            _auxiliaryArray = new T[arr.Length];

            var lo = 0;
            var mid = arr.Length - 1;
            var hi = arr.Length - 1;

            while (lo < arr.Length)
            {
                mid = GetNextSentinelIndex(arr, lo);
                if (mid == arr.Length - 1)
                {
                    if (lo > 0)
                    {
                        lo = 0;
                        continue;
                    }
                    else
                        break;
                }
                hi = GetNextSentinelIndex(arr, mid + 1);
                Merge(arr, lo, mid, hi);

                if (hi == arr.Length - 1)
                    lo = 0;
                else
                    lo = hi + 1;
            }
        }

        private void Merge(T[] arrayToSort, int lo, int mid, int hi)
        {
            var i = lo;
            var j = mid + 1;

            for (var k = lo; k <= hi; k++)
                _auxiliaryArray[k] = arrayToSort[k];

            for (var k = lo; k <= hi; k++)
            {
                if (i > mid)
                    arrayToSort[k] = _auxiliaryArray[j++];
                else if (j > hi)
                    arrayToSort[k] = _auxiliaryArray[i++];
                else if (_auxiliaryArray[i].CompareTo(_auxiliaryArray[j]) < 0)
                    arrayToSort[k] = _auxiliaryArray[i++];
                else
                    arrayToSort[k] = _auxiliaryArray[j++];
            }

        }

        private int GetNextSentinelIndex(T[] arrayToScan, int startIndex)
        {
            if (startIndex >= arrayToScan.Length - 1)
                return startIndex;

            while (startIndex <= arrayToScan.Length - 2 && arrayToScan[startIndex + 1].CompareTo(arrayToScan[startIndex]) >= 0)
                startIndex++;
            return startIndex;
        }
    }
}
