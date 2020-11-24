﻿using System;
using System.Collections.Generic;

// https://skillsmart.ru/algo/15-121-cm/z9h53ee284.html
namespace AlgorithmsDataStructures2
{
    public class SimpleTreeNode<T>
    {
        public T NodeValue; // значение в узле
        public SimpleTreeNode<T> Parent; // родитель или null для корня
        public List<SimpleTreeNode<T>> Children; // список дочерних узлов или null
	
        public SimpleTreeNode(T val, SimpleTreeNode<T> parent)
        {
            NodeValue = val;
            Parent = parent;
            Children = null;
        }
    }
	
    public class SimpleTree<T>
    {
        public SimpleTreeNode<T> Root; // корень, может быть null

        public SimpleTree(SimpleTreeNode<T> root)
        {
            Root = root;
        }
	
        public void AddChild(SimpleTreeNode<T> ParentNode, SimpleTreeNode<T> NewChild)
        {
            ParentNode.Children.Add(NewChild);
        }

        public void DeleteNode(SimpleTreeNode<T> NodeToDelete)
        {
            NodeToDelete.Parent.Children.Remove(NodeToDelete);
            
            NodeToDelete.Parent.Children.AddRange(NodeToDelete.Children);
        }

        public List<SimpleTreeNode<T>> GetAllNodes()
        {
            var nodes = new List<SimpleTreeNode<T>>();
            if(Root == null)
                return nodes;
            var queue = new Queue<SimpleTreeNode<T>>();
            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                nodes.Add(currentNode);

                foreach (var node in queue)
                {
                    queue.Enqueue(node);
                }
            }

            return nodes;
        }
	
        public List<SimpleTreeNode<T>> FindNodesByValue(T val)
        {
            if(Root == null)
                return null;
            
            var nodes = new List<SimpleTreeNode<T>>();
            var queue = new Queue<SimpleTreeNode<T>>();
            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                if(currentNode.Equals(val))
                    nodes.Add(currentNode);

                foreach (var node in queue)
                {
                    queue.Enqueue(node);
                }
            }

            return nodes;
        }
   
        public void MoveNode(SimpleTreeNode<T> OriginalNode, SimpleTreeNode<T> NewParent)
        {
            OriginalNode.Parent.Children.Remove(OriginalNode);
            
            NewParent.Children.Add(OriginalNode);
        }
   
        public int Count()
        {
            return GetAllNodes().Count;
        }

        public int LeafCount()
        {
            if(Root == null)
                return 0;

            int leafConter = 0;
            var queue = new Queue<SimpleTreeNode<T>>();
            queue.Enqueue(Root);
            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                
                if (currentNode.Children == null)
                {
                    leafConter++;
                }
                else if (currentNode.Children.Count == 0)
                {
                    leafConter++;
                }
                
                foreach (var node in queue)
                {
                    queue.Enqueue(node);
                }
            }
            
            return leafConter;
        }
    }
 
}