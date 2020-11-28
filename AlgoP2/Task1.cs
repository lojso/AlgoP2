using System;
using System.Collections.Generic;

// https://skillsmart.ru/algo/15-121-cm/z9h53ee284.html
namespace Task1
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
            var nodes = new List<SimpleTreeNode<T>>();
            if (Root == null)
                return nodes;
            var queue = new Queue<SimpleTreeNode<T>>();
            queue.Enqueue(Root);
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
            return GetAllNodes().Count;
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
    }
}