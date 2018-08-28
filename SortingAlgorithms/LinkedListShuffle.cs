using System;

namespace SortingAlgorithms
{
	public class LinkedListShuffle
	{
		public static DataStructures.Linear.LinkedListNode<T> Shuffle<T>(DataStructures.Linear.LinkedListNode<T> firstNode) where T : IComparable<T>
		{
			if (firstNode == null)
				throw new ArgumentNullException(nameof(firstNode));

			if (firstNode.Next == null)
				return firstNode;

			var middle = GetMiddle(firstNode);
			var rightNode = middle.Next;
			middle.Next = null;

			var mergedResult = ShuffledMerge(Shuffle(firstNode), Shuffle(rightNode));
			return mergedResult;
		}

		private static DataStructures.Linear.LinkedListNode<T> ShuffledMerge<T>(DataStructures.Linear.LinkedListNode<T> leftNode, DataStructures.Linear.LinkedListNode<T> rightNode) where T : IComparable<T>
		{
			var dummyHead = new DataStructures.Linear.LinkedListNode<T>();
			DataStructures.Linear.LinkedListNode<T> curNode = dummyHead;
			
			var rnd = new Random((int)DateTime.Now.Ticks);
			while (leftNode != null || rightNode != null)
			{
				var rndRes =  rnd.Next(0, 2);
				if (rndRes == 0)
				{
					if (leftNode != null)
					{
						curNode.Next = leftNode;
						leftNode = leftNode.Next;
					}
					else
					{
						curNode.Next = rightNode;
						rightNode = rightNode.Next;
					}
				}
				else
				{
					if (rightNode != null)
					{
						curNode.Next = rightNode;
						rightNode = rightNode.Next;
					}
					else
					{
						curNode.Next = leftNode;
						leftNode = leftNode.Next;
					}
				}

				curNode = curNode.Next;						
			}
			return dummyHead.Next;
		}

		private static DataStructures.Linear.LinkedListNode<T> GetMiddle<T>(DataStructures.Linear.LinkedListNode<T> firstNode) where T : IComparable<T>
		{
			if (firstNode.Next == null)
				return firstNode;

			DataStructures.Linear.LinkedListNode<T> fast, slow;
			fast = slow = firstNode;
			while (fast.Next != null && fast.Next.Next != null)
			{
				slow = slow.Next;
				fast = fast.Next.Next;
			}
			return slow;
		}
	}
}
