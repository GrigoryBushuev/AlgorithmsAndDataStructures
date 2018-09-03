using System;
using Utils;

namespace SortingAlgorithms
{
    public class InsertationSort<T> : ISortingAlgorithm<T> where T : IComparable<T>
    {
        public void Sort(T[] arrayToSort)
        {
            if (arrayToSort is null)
                throw new ArgumentNullException(nameof(arrayToSort));

            for (var i = 1; i < arrayToSort.Count(); i++)
                //Starting from current index we compare two neighborhood elements. In case they are unordered we swap them. 
                //Thus by the end of the internal iteration all elements are ordered from 0 to i
                for (var j = i; j > 0 && arrayToSort[j].CompareTo(arrayToSort[j - 1]) < 0; j--)
                    arrayToSort.Swap(j - 1, j);
        }
    }
}
