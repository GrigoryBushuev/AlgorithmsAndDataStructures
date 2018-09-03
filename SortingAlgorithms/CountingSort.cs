using System;
using Utils;

namespace SortingAlgorithms
{
    public static class CountingSort
    {
        public static void Sort(int[] arrayToSort)
        {
            if (arrayToSort is null)
                throw new ArgumentNullException(nameof(arrayToSort));

            var bucket = new int[arrayToSort.Max() + 1];
            for (var i = 0; i < arrayToSort.Count(); i++)
            {
                if (arrayToSort[i] < 0)
                    throw new ArgumentOutOfRangeException(nameof(arrayToSort));
                bucket[arrayToSort[i]]++;
            }

            var resArrPointer = 0;
            for (var i = 0; i < bucket.Length; i++)
            {
                var val = bucket[i];
                while (val > 0)
                {
                    arrayToSort[resArrPointer] = i;
                    resArrPointer++;
                    val--;
                }
            }
        }
    }
}
