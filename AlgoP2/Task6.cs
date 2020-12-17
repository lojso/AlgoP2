using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class BSTNode
    {
        public int NodeKey; // ключ узла
        public BSTNode Parent; // родитель или null для корня
        public BSTNode LeftChild; // левый потомок
        public BSTNode RightChild; // правый потомок	
        public int Level; // глубина узла

        public BSTNode(int key, BSTNode parent)
        {
            NodeKey = key;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }
    }

    public class BalancedBST
    {
        public BSTNode Root; // корень дерева

        public BalancedBST()
        {
            Root = null;
        }

        public void GenerateTree(int[] a)
        {
            Array.Sort(a);
            int startIndex = 0;
            int endIndex = a.Length;
            int centerIndex = startIndex + (int) Math.Floor((endIndex - startIndex) / 2f);
            Root = new BSTNode(a[centerIndex], null);
            Root.Level = 1;

            if (startIndex == centerIndex)
                return;

            AddNode(a, startIndex, centerIndex, true, Root);

            if (centerIndex + 1 < endIndex)
                AddNode(a, centerIndex + 1, endIndex, false, Root);
        }

        private void AddNode(int[] array, int startIndex, int endIndex, bool isLeftNode, BSTNode parent)
        {
            int centerIndex = startIndex + (int) Math.Floor((endIndex - startIndex) / 2f);
            var node = new BSTNode(array[centerIndex], parent);
            node.Parent = parent;
            node.Level = parent.Level + 1;

            AddToParent(isLeftNode, parent, node);

            if (startIndex == centerIndex)
                return;

            AddNode(array, startIndex, centerIndex, true, node);

            if (centerIndex + 1 < endIndex)
                AddNode(array, centerIndex + 1, endIndex, false, node);
        }

        private static void AddToParent(bool isLeftNode, BSTNode parent, BSTNode node)
        {
            if (parent == null)
                return;

            if (isLeftNode)
            {
                parent.LeftChild = node;
            }
            else
            {
                parent.RightChild = node;
            }
        }

        public bool IsBalanced(BSTNode root_node)
        {
            return IsBalancedRec(root_node).IsBalanced;
        }

        private IsBalancedContext IsBalancedRec(BSTNode root_node)
        {
            IsBalancedContext leftResult = IsSubtreeBalanced(root_node.LeftChild);
            IsBalancedContext rightResult = IsSubtreeBalanced(root_node.RightChild);

            return new IsBalancedContext
            {
                Depth = Math.Max(leftResult.Depth, rightResult.Depth) + 1,
                IsBalanced = Math.Abs(leftResult.Depth - rightResult.Depth) <= 1 &&
                             leftResult.IsBalanced && rightResult.IsBalanced,
            };
        }

        private IsBalancedContext IsSubtreeBalanced(BSTNode node)
        {
            return node == null
                ? new IsBalancedContext()
                {
                    Depth = 0,
                    IsBalanced = true,
                }
                : IsBalancedRec(node);
        }

        private struct IsBalancedContext
        {
            public int Depth;
            public bool IsBalanced;
        }

        public static void AddNodeDebug(BSTNode parent, BSTNode node, bool toLeft)
        {
            if (toLeft)
            {
                parent.LeftChild = node;
            }
            else
            {
                parent.RightChild = node;
            }
            node.Parent = parent;
        }
    }
}