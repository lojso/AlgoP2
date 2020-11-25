using System;
using System.Linq;
using AlgorithmsDataStructures2;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class Task1
    {
        [Test]
        public void CountNull()
        {
            var tree = new SimpleTree<int>(null);
            
            Assert.True(tree.Count() == 0);
        }
        
        [Test]
        public void Create()
        {
            var root = new SimpleTreeNode<int>(1, null);
            var tree = new SimpleTree<int>(root);

            Assert.True(tree.Count() == 1);
            Assert.True(tree.FindNodesByValue(1).Count == 1);
            Assert.True(tree.GetAllNodes().Count == 1);
            Assert.True(tree.LeafCount() == 1);
        }

        [Test]
        public void Add()
        {
            var root = new SimpleTreeNode<int>(0, null);
            var node1 = new SimpleTreeNode<int>(1, null);
            var node2 = new SimpleTreeNode<int>(2, null);
            var node3 = new SimpleTreeNode<int>(3, null);
            var node4 = new SimpleTreeNode<int>(4, null);
            var node5 = new SimpleTreeNode<int>(5, null);
            
            var tree = new SimpleTree<int>(root);
            
            tree.AddChild(root, node1);
            tree.AddChild(root, node2);
            tree.AddChild(root, node3);
            tree.AddChild(node3, node4);
            tree.AddChild(node3, node5);

            Assert.True(tree.Count() == 6);
            Assert.True(tree.FindNodesByValue(1).Count == 1);
            Assert.True(tree.GetAllNodes().Count == 6);
            Assert.True(tree.LeafCount() == 4);
        }
        
        [Test]
        public void Delete()
        {
            var root = new SimpleTreeNode<int>(0, null);
            var node1 = new SimpleTreeNode<int>(1, null);
            var node2 = new SimpleTreeNode<int>(2, null);
            var node3 = new SimpleTreeNode<int>(3, null);
            var node4 = new SimpleTreeNode<int>(4, null);
            var node5 = new SimpleTreeNode<int>(5, null);
            
            var tree = new SimpleTree<int>(root);
            
            tree.AddChild(root, node1);
            tree.AddChild(root, node2);
            tree.AddChild(root, node3);
            tree.AddChild(node3, node4);
            tree.AddChild(node3, node5);
            
            tree.DeleteNode(node5);
            tree.DeleteNode(node2);

            Assert.True(tree.Count() == 4);
            Assert.True(tree.FindNodesByValue(1).Count == 1);
            Assert.True(tree.GetAllNodes().Count == 4);
            Assert.True(tree.LeafCount() == 2);
        }
        
        [Test]
        public void FindAfterDelete()
        {
            var root = new SimpleTreeNode<int>(0, null);
            var node1 = new SimpleTreeNode<int>(1, null);
            var node2 = new SimpleTreeNode<int>(2, null);
            var node3 = new SimpleTreeNode<int>(3, null);
            var node4 = new SimpleTreeNode<int>(4, null);
            var node5 = new SimpleTreeNode<int>(5, null);
            
            var tree = new SimpleTree<int>(root);
            
            tree.AddChild(root, node1);
            tree.AddChild(root, node2);
            tree.AddChild(root, node3);
            tree.AddChild(node3, node4);
            tree.AddChild(node3, node5);
            
            Assert.True(tree.FindNodesByValue(5).Count == 1);
            
            tree.DeleteNode(node5);
            tree.DeleteNode(node2);

            Assert.True(tree.Count() == 4);
            Assert.True(tree.FindNodesByValue(5).Count == 0);
            Assert.True(tree.GetAllNodes().Count == 4);
            Assert.True(tree.LeafCount() == 2);
        }
        
        [Test]
        public void FindMultiple()
        {
            var root = new SimpleTreeNode<int>(0, null);
            var node1 = new SimpleTreeNode<int>(1, null);
            var node2 = new SimpleTreeNode<int>(2, null);
            var node3 = new SimpleTreeNode<int>(3, null);
            var node4 = new SimpleTreeNode<int>(4, null);
            var node5 = new SimpleTreeNode<int>(5, null);
            var node5_2 = new SimpleTreeNode<int>(5, null);
            
            var tree = new SimpleTree<int>(root);
            
            tree.AddChild(root, node1);
            tree.AddChild(root, node2);
            tree.AddChild(root, node3);
            tree.AddChild(node3, node4);
            tree.AddChild(node3, node5);
            tree.AddChild(node3, node5_2);

            Assert.True(tree.Count() == 7);
            Assert.True(tree.FindNodesByValue(5).Count == 2);
            Assert.True(tree.GetAllNodes().Count == 7);
            Assert.True(tree.LeafCount() == 5);
        }
        
        [Test]
        public void DeleteBranch()
        {
            var root = new SimpleTreeNode<int>(0, null);
            var node1 = new SimpleTreeNode<int>(1, null);
            var node2 = new SimpleTreeNode<int>(2, null);
            var node3 = new SimpleTreeNode<int>(3, null);
            var node4 = new SimpleTreeNode<int>(4, null);
            var node5 = new SimpleTreeNode<int>(5, null);
            var node5_2 = new SimpleTreeNode<int>(5, null);
            
            var tree = new SimpleTree<int>(root);
            
            tree.AddChild(root, node1);
            tree.AddChild(root, node2);
            tree.AddChild(node2, node3);
            tree.AddChild(node2, node4);

            tree.DeleteNode(node2);

            Assert.True(tree.Count() == 4);
            Assert.True(tree.GetAllNodes().Count == 4);
            Assert.True(tree.LeafCount() == 3);
        }
        
        [Test]
        public void MoveBranch()
        {
            var root = new SimpleTreeNode<int>(0, null);
            var node1 = new SimpleTreeNode<int>(1, null);
            var node2 = new SimpleTreeNode<int>(2, null);
            var node3 = new SimpleTreeNode<int>(3, null);
            var node4 = new SimpleTreeNode<int>(4, null);
            var node5 = new SimpleTreeNode<int>(5, null);
            var node5_2 = new SimpleTreeNode<int>(5, null);
            
            var tree = new SimpleTree<int>(root);
            
            tree.AddChild(root, node1);
            tree.AddChild(root, node2);
            tree.AddChild(node2, node3);
            tree.AddChild(node2, node4);

            tree.MoveNode(node2, node1);

            Assert.True(tree.Count() == 5);
            Assert.True(tree.GetAllNodes().Count == 5);
            Assert.True(tree.LeafCount() == 2);
        }
    }
}