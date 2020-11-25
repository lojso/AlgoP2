using System.Collections.Generic;
using AlgorithmsDataStructures2;

namespace AlgoP2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var rootNode = new SimpleTreeNode<int>(0, null);
            
            var node1 = new SimpleTreeNode<int>(1, null);
            var node2 = new SimpleTreeNode<int>(2, null);
            var node3 = new SimpleTreeNode<int>(3, null);
            var node4 = new SimpleTreeNode<int>(4, null);
            var node5 = new SimpleTreeNode<int>(5, null);
            var node6 = new SimpleTreeNode<int>(6, null);
            var node7 = new SimpleTreeNode<int>(7, null);
            var node8 = new SimpleTreeNode<int>(8, null);
            
            var tree = new SimpleTree<int>(rootNode);
            
            tree.AddChild(rootNode, node1);
            tree.AddChild(rootNode, node2);
            
            tree.AddChild(node2, node3);
            tree.AddChild(node2, node4);
            
            tree.AddChild(node3, node5);
            tree.AddChild(node5, node6);
            tree.AddChild(node6, node7);
            tree.AddChild(node6, node8);

            Dictionary<SimpleTreeNode<int>, int> nodeLevels = Task1Ad1.TaskCalculateNodeLevels(tree);
        }
    }
}