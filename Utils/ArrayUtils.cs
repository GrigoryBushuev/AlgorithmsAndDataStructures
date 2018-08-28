using System;

namespace Utils
{
    public static class ArrayUtils
    {
        public static bool IsSorted<T>(this T[] array, bool ascending = true) where T : IComparable<T>
        {
            if (array is null)
                throw new ArgumentNullException(nameof(array));

            if (array.Length == 1)
                return true;

            var comparableValue = @ascending ? 1 : -1;
            for (var i = 1; i < array.Length; i++)
            {
                var compareResult = array[i].CompareTo(array[i - 1]);
                if (compareResult != comparableValue && compareResult != 0)
                {
                    return false;
                }
            }
            return true;
        }

        public static void Swap<T>(this T[] array, int i, int j)
        {
            if (array is null)
                throw  new ArgumentNullException(nameof(array));

            if (i < 0 || i >= array.Length)
                throw new ArgumentOutOfRangeException(nameof(i));

            if (j < 0 || j >= array.Length)
                throw new ArgumentOutOfRangeException(nameof(j));

            if (i == j)
                return;            

            var temp = array[i];
            array[i] = array[j];
            array[j] = temp;
        }

        public static int? Rank<T>(this T[] sortedArray, T key) where T : IComparable<T>
        {
            if (sortedArray is null)
                throw new ArgumentNullException(nameof(sortedArray));

            int lo = 0;
            int hi = sortedArray.Length - 1;

            while (lo <= hi)
            {
                int mid = lo + (hi - lo) / 2;
                int cmp = key.CompareTo(sortedArray[mid]);
                if (cmp < 0)
                    hi = mid - 1;
                else if (cmp > 0)
                    lo = mid + 1;
                else
                    return mid;
            }
            return null;
        }
    }
}
