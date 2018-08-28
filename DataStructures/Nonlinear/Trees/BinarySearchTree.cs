using System;
using System.Collections.Generic;
using System.Linq;
using DataStructures.Linear;

namespace DataStructures.Nonlinear.Trees
{
    public class BinarySearchTree<TKey, TValue> where TKey : IComparable<TKey> where TValue : IComparable<TValue>
    {
        private BinarySearchTreeNode<TKey, TValue> _root;

        public BinarySearchTreeNode<TKey, TValue> GetNodeByKey(TKey key)
        {
            return GetNodeByKey(_root, key);
        }

        public int Size
        {
            get { return GetSize(_root); }
        }

        public void Add(TKey key, TValue value)
        {
            _root = Add(_root, key, value);
        }

        public BinarySearchTreeNode<TKey, TValue> Min()
        {
            return Min(_root);
        }

        public BinarySearchTreeNode<TKey, TValue> Min(BinarySearchTreeNode<TKey, TValue> node)
        {
            if (node.LeftNode is null) return node;
            return Min(node.LeftNode);
        }

        public BinarySearchTreeNode<TKey, TValue> Max()
        {
            return Max(_root);
        }

        public BinarySearchTreeNode<TKey, TValue> Max(BinarySearchTreeNode<TKey, TValue> node)
        {
            if (node.RightNode is null) return node;
            return Max(node.RightNode);
        }

        public void DeleteMin()
        {
            _root = DeleteMin(_root);
        }

        public BinarySearchTreeNode<TKey, TValue> DeleteMin(BinarySearchTreeNode<TKey, TValue> node)
        {
            if (node.LeftNode is null) return node.RightNode;
            node.LeftNode = DeleteMin(node.LeftNode);
            node.Size = GetSize(node.LeftNode) + GetSize(node.RightNode) + 1;
            return node;
        }

        public void Delete(TKey key)
        {
            _root = Delete(_root, key);
        }

        public BinarySearchTreeNode<TKey, TValue> Delete(BinarySearchTreeNode<TKey, TValue> node, TKey key)
        {
            if (node is null) return null;  
            var cmpResult = key.CompareTo(node.Key);
            if (cmpResult > 0)
            {
                node.RightNode = Delete(node.RightNode, key);
            }
            else if (cmpResult < 0)
            {
                node.LeftNode = Delete(node.LeftNode, key);
            }
            else
            {
                if (node.RightNode == null) return node.LeftNode;
                if (node.LeftNode == null) return node.RightNode;

                var tempNode = node;
                node = Min(tempNode.RightNode);
                node.RightNode = DeleteMin(tempNode.RightNode);
                node.LeftNode = tempNode.LeftNode;
            }
            node.Size = GetSize(node.LeftNode) + GetSize(node.RightNode) + 1;
            return node;
        }

        public System.Collections.Generic.IEnumerable<BinarySearchTreeNode<TKey, TValue>> All()
        {
            if (GetSize(_root) > 0)
                return Range(Min().Key, Max().Key);
            return Enumerable.Empty<BinarySearchTreeNode<TKey, TValue>>();
        }

        public System.Collections.Generic.IEnumerable<BinarySearchTreeNode<TKey, TValue>> Range(TKey lo, TKey hi)
        {
            var queue = new Queue<BinarySearchTreeNode<TKey, TValue>>();
            Range(_root, queue, lo, hi);
            return queue;
        }

        public System.Collections.Generic.IEnumerable<BinarySearchTreeNode<TKey, TValue>> LevelOrderTraversal()
        {
            var result = new Queue<BinarySearchTreeNode<TKey, TValue>>();
            result.Enqueue(_root);
            foreach (var node in result)
            {
                if (node.LeftNode != null)
                    result.Enqueue(node.LeftNode);
                if (node.RightNode != null)
                    result.Enqueue(node.RightNode);
            }
            return result;
        }

        private int GetSize(BinarySearchTreeNode<TKey, TValue> node)
        {
            return node == null ? 0 : node.Size;
        }

        private BinarySearchTreeNode<TKey, TValue> GetNodeByKey(BinarySearchTreeNode<TKey, TValue> rootNode, TKey key)
        {
            BinarySearchTreeNode<TKey, TValue> result = null;
            var cmpResult = key.CompareTo(rootNode.Key);
            if (cmpResult > 0)
            {
                result = GetNodeByKey(rootNode.RightNode, key);
            }
            else if (cmpResult < 0)
            {
                result = GetNodeByKey(rootNode.LeftNode, key);
            }
            else
            {
                result = rootNode;
            }
            return result;
        }

        private BinarySearchTreeNode<TKey, TValue> Add(BinarySearchTreeNode<TKey, TValue> rootNode, TKey key, TValue value)
        {
            if (rootNode is null)
                return new BinarySearchTreeNode<TKey, TValue>(key, value, null, null, 1);

            var cmpResult = key.CompareTo(rootNode.Key);
            BinarySearchTreeNode<TKey, TValue> result = null;
            if (cmpResult > 0)
            {
                result = Add(rootNode.RightNode, key, value);
                rootNode.RightNode = result;
            }
            else if (cmpResult < 0)
            {
                result = Add(rootNode.LeftNode, key, value);
                rootNode.LeftNode = result;
            }
            else
            {
                rootNode.Value = value;
            }
            rootNode.Size = GetSize(rootNode.LeftNode) + GetSize(rootNode.RightNode) + 1;
            return rootNode;
        }

        private void Range(BinarySearchTreeNode<TKey, TValue> node, Queue<BinarySearchTreeNode<TKey, TValue>> queue, TKey lo, TKey hi)
        {
            if (node == null) return;			

            var loCmpResult = lo.CompareTo(node.Key);
            var hiCmpResult = hi.CompareTo(node.Key);

            if (loCmpResult < 0)
                Range(node.LeftNode, queue, lo, hi);

            if (loCmpResult <= 0 && hiCmpResult >= 0)
                queue.Enqueue(node);
            
            if (hiCmpResult > 0)
                Range(node.RightNode, queue, lo, hi);
        }
    }
}
