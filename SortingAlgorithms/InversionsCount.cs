using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingAlgorithms
{
	public static class InversionsCountUtil
	{
		public static Tuple<IEnumerable<T>, int> InversionsCount<T>(this IEnumerable<T> collection) where T : IComparable<T>
		{
			if (collection is null)
				throw new ArgumentNullException(nameof(collection));

			var arr = (T[])collection;
			if (arr.Count() == 1)
				return new Tuple<IEnumerable<T>, int>(arr, 1);

			var aux = new T[arr.Count()];

			var inversionsCount = SplitAndCount(arr, aux, 0, arr.Count() - 1);			
			return new Tuple<IEnumerable<T>, int>(arr, inversionsCount);
		}

		private static int SplitAndCount<T>(T[] arr, T[] aux, int startIndex, int endIndex) where T : IComparable<T>
		{
			if (startIndex >= endIndex)
				return 0;

			var midIndex = startIndex + (endIndex - startIndex) / 2;

			var x = SplitAndCount(arr, aux, startIndex, midIndex);
			var y = SplitAndCount(arr, aux, midIndex + 1, endIndex);
			var z = MergeAndCount(arr, aux, startIndex, endIndex, midIndex);

			return x + y + z;
		}

		private static int MergeAndCount<T>(T[] arr, T[] aux, int startIndex, int endIndex, int midIndex) where T : IComparable<T>
		{
			var i = startIndex;
			var j = midIndex + 1;

			for (var k = startIndex; k <= endIndex; k++)
			{
				aux[k] = arr[k];
			}

			var numOfSwaps = 0;

			for (var k = startIndex; k <= endIndex; k++)
			{
				if (i > midIndex)
				{
					arr[k] = aux[j++];
				}
				else if(j > endIndex)
				{
					arr[k] = aux[i++];
				}
				else if (aux[i].CompareTo(aux[j]) < 0)
				{
					arr[k] = aux[i++];
				}
				else
				{
					numOfSwaps = numOfSwaps + midIndex - i + 1;
					arr[k] = aux[j++];
				}
			}
			return numOfSwaps;
		}
	}
}
