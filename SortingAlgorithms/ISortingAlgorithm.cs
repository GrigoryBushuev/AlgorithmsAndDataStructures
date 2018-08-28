using System;
using System.Collections.Generic;

namespace SortingAlgorithms
{
	public interface ISortingAlgorithm<T> where T : IComparable<T>
	{
		void Sort(IEnumerable<T> arrayToSort);
	}
}
