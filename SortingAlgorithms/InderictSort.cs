using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms
{
    /// <summary>
    /// A version of merge-sort that does not rearrange the array, 
    /// but returns an int[] array perm such that perm[i] is the index of the ith smallest entry in the array.
    /// </summary>
    public static class IndirectSortUtil
    {
        public static int[] IndirectSort<T>(this IEnumerable<T> collection) where T : IComparable<T>
        {
            if (collection is null)
                throw new ArgumentNullException(nameof(collection));

            var indexArray = new int[collection.Count()];
            var auxIndexArray = new int[collection.Count()];
            for (int i = 0; i < collection.Count(); i++)
            {
                indexArray[i] = i;
                auxIndexArray[i] = i;
            }

            Sort(collection as T[], indexArray, auxIndexArray, 0, collection.Count() - 1);
            return indexArray;
        }


        private static void Sort<T>(T[] arrayToIndex, int[] indexArray, int[] auxIndexArray, int startIndex, int endIndex) where T : IComparable<T>
        {
            if (endIndex <= startIndex)
                return;

            var midIndex = startIndex + (endIndex - startIndex) / 2;
            Sort(arrayToIndex, indexArray, auxIndexArray, startIndex, midIndex);
            Sort(arrayToIndex, indexArray, auxIndexArray, midIndex + 1, endIndex);
            Merge(arrayToIndex, indexArray, auxIndexArray, startIndex, midIndex, endIndex);
        }


        private static void Merge<T>(T[] arrayToIndex, int[] indexArray, int[] auxIndexArray, int startIndex, int midIndex, int endIndex) where T : IComparable<T>
        {
            var i = startIndex;
            var j = midIndex + 1;

            for (var k = startIndex; k <= endIndex; k++)
            {
                auxIndexArray[k] = indexArray[k];
            }

            for (var k = startIndex; k <= endIndex; k++)
            {
                if (i > midIndex)
                {
                    indexArray[k] = auxIndexArray[j++];
                }
                else if (j > endIndex)
                {
                    indexArray[k] = auxIndexArray[i++];
                }
                else if (arrayToIndex[auxIndexArray[i]].CompareTo(arrayToIndex[auxIndexArray[j]]) <= 0)
                {
                    indexArray[k] = auxIndexArray[i++];
                }
                else
                {
                    indexArray[k] = auxIndexArray[j++];
                }
            }
        }
    }
}
