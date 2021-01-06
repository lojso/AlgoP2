using System;
using System.Collections.Generic;

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

        public override string ToString()
        {
            return NodeValue.ToString();
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
            if (ParentNode.Children == null)
                ParentNode.Children = new List<SimpleTreeNode<T>>();

            ParentNode.Children.Add(NewChild);
            NewChild.Parent = ParentNode;
        }

        public void DeleteNode(SimpleTreeNode<T> NodeToDelete)
        {
            NodeToDelete.Parent.Children.Remove(NodeToDelete);

            if (NodeToDelete.Children == null)
                return;
            
            foreach (var node in NodeToDelete.Children)
            {
                NodeToDelete.Parent.Children.Add(node);
            }
        }

        public List<SimpleTreeNode<T>> GetAllNodes()
        {
            return GetAllNodes(Root);
        }

        public List<SimpleTreeNode<T>> FindNodesByValue(T val)
        {
            if (Root == null)
                return null;

            var nodes = new List<SimpleTreeNode<T>>();
            var queue = new Queue<SimpleTreeNode<T>>();
            queue.Enqueue(Root);

            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                if (currentNode.NodeValue.Equals(val))
                    nodes.Add(currentNode);

                if (currentNode.Children == null)
                    continue;

                foreach (var node in currentNode.Children)
                {
                    queue.Enqueue(node);
                }
            }

            return nodes;
        }

        public void MoveNode(SimpleTreeNode<T> OriginalNode, SimpleTreeNode<T> NewParent)
        {
            OriginalNode.Parent.Children.Remove(OriginalNode);

            if(NewParent.Children == null)
                NewParent.Children = new List<SimpleTreeNode<T>>();
            
            NewParent.Children.Add(OriginalNode);
        }

        public int Count()
        {
            return GetAllNodes(Root).Count;
        }

        public int LeafCount()
        {
            if (Root == null)
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
                    continue;
                }

                if (currentNode.Children.Count == 0)
                {
                    leafConter++;
                }

                foreach (var node in currentNode.Children)
                {
                    queue.Enqueue(node);
                }
            }

            return leafConter;
        }
        
        public List<T> EvenTrees()
        {
            List<T> cutNodes = new List<T>();
            var allNodes = GetAllNodes(Root);
            foreach (var node in allNodes)
            {
                if (ShoudCut(node))
                    AddNodeToCutNodes(node, cutNodes);
            }
            return cutNodes;
        }

        private void AddNodeToCutNodes(SimpleTreeNode<T> node, List<T> cutNodes)
        {
            cutNodes.Add(node.Parent.NodeValue);
            cutNodes.Add(node.NodeValue);
        }

        private bool ShoudCut(SimpleTreeNode<T> node)
        {
            if (node == null)
                return false;

            if (node.Parent == null)
                return false;

            return IsEven(node);
        }

        public bool IsEven(SimpleTreeNode<T> node)
        {
            return GetAllNodes(node).Count % 2 == 0;
        }
        
        public List<SimpleTreeNode<T>> GetAllNodes(SimpleTreeNode<T> root)
        {
            var nodes = new List<SimpleTreeNode<T>>();
            if (root == null)
                return nodes;
            var queue = new Queue<SimpleTreeNode<T>>();
            queue.Enqueue(root);
            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                nodes.Add(currentNode);


                if (currentNode.Children == null)
                    continue;

                foreach (var node in currentNode.Children)
                {
                    queue.Enqueue(node);
                }
            }

            return nodes;
        }
    }
}