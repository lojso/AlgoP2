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
        public int     Level; // глубина узла
	
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
            Root.Level = 0;
            
            if (startIndex == centerIndex)
                return;

            AddNode(a, startIndex, centerIndex, true, Root);
            
            if(centerIndex + 1 < endIndex)
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
            
            if(centerIndex + 1 < endIndex)
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
            return false; // сбалансировано ли дерево с корнем root_node
        }
    }
}