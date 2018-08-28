using System;
using System.Collections.Generic;
using DataStructures.Linear;

namespace DataStructures.Nonlinear.Trees
{
    /// <summary>
    /// LLRB Left leaning red black tree
    /// </summary>
    /// <typeparam name="TNode"></typeparam>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class RedBlackTree<TKey, TValue> where TKey : IComparable<TKey>
    {
        private RedBlackTreeNode<TKey, TValue> _root;

        private RedBlackTreeNode<TKey, TValue> RotateLeft(RedBlackTreeNode<TKey, TValue> node)
        {           
            var x = node.RightNode;
            node.RightNode = x.LeftNode;
            x.LeftNode = node;            
            x.IsRed = node.IsRed;

            //TODO: Add getting size             
            return x;
        }

        private RedBlackTreeNode<TKey, TValue> RotateRight(RedBlackTreeNode<TKey, TValue> node)
        {
            var x = node.LeftNode;
            node.LeftNode = x.RightNode;
            x.RightNode = node;
            x.IsRed = node.IsRed;
            node.IsRed = true;
            //TODO: Add getting size  
            return x;
        }

        private RedBlackTreeNode<TKey, TValue> FlipColors(RedBlackTreeNode<TKey, TValue> node)
        {
            node.LeftNode.IsRed = false;
            node.RightNode.IsRed = false;
            node.IsRed = true;
            return node;
        }

        private bool IsRed(RedBlackTreeNode<TKey, TValue> node)
        {
            if (node == null)
                return false;
            return node.IsRed;
        }

        public void Add(TKey key, TValue value)
        {
            if (_root == null)
                _root = new RedBlackTreeNode<TKey, TValue>(key, value, null, null, 1, false);
            Add(_root, key, value);
            //We color the root black after each insertion
            _root.IsRed = false;
        }

        public IEnumerable<RedBlackTreeNode<TKey, TValue>> LevelOrderTraversal()
        {
            var BFSNodes = new LinkedQueue<RedBlackTreeNode<TKey, TValue>>();
            BFSNodes.Enqueue(_root);
            foreach (var node in BFSNodes)
            {
                if (node.LeftNode != null)
                    BFSNodes.Enqueue(node.LeftNode);
                if (node.RightNode != null)
                    BFSNodes.Enqueue(node.RightNode);
            }

            return BFSNodes;
        }


        public RedBlackTreeNode<TKey, TValue> Add(RedBlackTreeNode<TKey, TValue> node, TKey key, TValue value)
        {
            if (node == null)
                return new RedBlackTreeNode<TKey, TValue>(key, value, null, null, 1, true);

            int cmp = key.CompareTo(node.Key);
            if (cmp < 0)
                node.LeftNode = Add(node.LeftNode, key, value);
            else if (cmp > 0)
                node.RightNode = Add(node.RightNode, key, value);
            else
                node.Value = value;

            //Red-black magic is here
            if (!IsRed(node.LeftNode) && IsRed(node.RightNode))
                node = RotateLeft(node);

            if (IsRed(node.LeftNode) && IsRed(node.LeftNode.LeftNode))
                node = RotateRight(node);

            if (IsRed(node.LeftNode) && IsRed(node.RightNode))
                node = FlipColors(node);
            
            return node;
        }
    }
}
