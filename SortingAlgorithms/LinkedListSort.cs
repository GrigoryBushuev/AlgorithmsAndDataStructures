using System;

namespace SortingAlgorithms
{
    public static class LinkedListSort
    {
        public static DataStructures.Linear.LinkedListNode<T> Sort<T>(DataStructures.Linear.LinkedListNode<T> firstNode) where T : IComparable<T>
        {
            if (firstNode is null)
                throw new ArgumentNullException(nameof(firstNode));

            if (firstNode.Next == null)
                return firstNode;

            var head = firstNode;
            var leftNode = head;
            var iterNum = 0;

            while (leftNode != null)
            {
                //Let's start again from the beginning
                leftNode = head;
                iterNum = 0;
                DataStructures.Linear.LinkedListNode<T> tailNode = null;

                while (leftNode != null)
                {
                    //Let's get the left sublist

                    //Let's find the node which divides sublist into two ordered sublists
                    var sentinelNode = GetSentinelNode(leftNode);
                    var rightNode = sentinelNode.Next;

                    //If the right node is null it means that we don't have two sublist and the left sublist is ordered already
                    //so we just add the rest sublist to the tail
                    if (rightNode == null)
                    {
                        if (tailNode == null)
                            break;
                        tailNode.Next = leftNode;
                        break;
                    }

                    sentinelNode.Next = null;

                    //Let's find the node where the right sublist ends
                    sentinelNode = GetSentinelNode(rightNode);
                    var restNode = sentinelNode.Next;
                    sentinelNode.Next = null;

                    DataStructures.Linear.LinkedListNode<T> newTailNode = null;

                    //Merging of two ordered sublists   
                    var mergedList = Merge(leftNode, rightNode, ref newTailNode);
                    //If we're at the beginning of the list the head of the merged sublist becomes the head of the list
                    if (iterNum == 0)
                        head = mergedList;
                    else //add the 					
                        tailNode.Next = mergedList;

                    tailNode = newTailNode;
                    leftNode = restNode;
                    iterNum++;
                }
                if (iterNum == 0)
                    break;
            }
            return head;
        }

        /// <summary>
        /// Merges two ordered sublists   
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="aNode">Left part of sublist</param>
        /// <param name="bNode">Right part of sublist</param>
        /// <param name="tailNode">Tail node of the merged list</param>
        /// <returns>The result of merging</returns>
        private static DataStructures.Linear.LinkedListNode<T> Merge<T>(DataStructures.Linear.LinkedListNode<T> leftNode,
                                                                        DataStructures.Linear.LinkedListNode<T> rightNode,
                                                                        ref DataStructures.Linear.LinkedListNode<T> tailNode) where T : IComparable<T>
        {
            var dummyHead = new DataStructures.Linear.LinkedListNode<T>();
            var curNode = dummyHead;

            while (leftNode != null || rightNode != null)
            {
                if (rightNode == null)
                {
                    curNode.Next = leftNode;
                    leftNode = leftNode.Next;
                }
                else if (leftNode == null)
                {
                    curNode.Next = rightNode;
                    rightNode = rightNode.Next;
                }
                else if (leftNode.Value.CompareTo(rightNode.Value) <= 0)
                {
                    curNode.Next = leftNode;
                    leftNode = leftNode.Next;
                }
                else
                {
                    curNode.Next = rightNode;
                    rightNode = rightNode.Next;
                }
                curNode = curNode.Next;
            }
            tailNode = curNode;
            return dummyHead.Next;
        }

        /// <summary>
        /// Returns the sentinel node
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="firstNode"></param>
        /// <returns></returns>
        private static DataStructures.Linear.LinkedListNode<T> GetSentinelNode<T>(DataStructures.Linear.LinkedListNode<T> firstNode) where T : IComparable<T>
        {
            var curNode = firstNode;

            while (curNode != null && curNode.Next != null && curNode.Value.CompareTo(curNode.Next.Value) <= 0)
                curNode = curNode.Next;

            return curNode;
        }
    }
}
