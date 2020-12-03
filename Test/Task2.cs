using Task3;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class Task2
    {
        [Test]
        public void FindNode()
        {
            var rootNode = new BSTNode<int>(20, 0, null);
            var tree = new BST<int>(rootNode);

            tree.AddKeyValue(15, 0);
            tree.AddKeyValue(25, 0);
            
            Assert.True(tree.FindNodeByKey(20).NodeHasKey == true);
            Assert.True(tree.FindNodeByKey(25).NodeHasKey == true);
            Assert.True(tree.FindNodeByKey(15).NodeHasKey == true);
            Assert.True(tree.Count() == 3);
        }
        
        [Test]
        public void FindNonExistingNode()
        {
            var rootNode = new BSTNode<int>(20, 0, null);
            var tree = new BST<int>(rootNode);

            Assert.True(tree.AddKeyValue(15, 0));
            Assert.True(tree.AddKeyValue(25, 0));
            
            Assert.True(tree.FindNodeByKey(1).NodeHasKey == false);
            Assert.True(tree.FindNodeByKey(1).ToLeft == true);
            Assert.True(tree.FindNodeByKey(1).Node.NodeKey == 15);
            Assert.True(tree.FindNodeByKey(100).NodeHasKey == false);
            Assert.True(tree.FindNodeByKey(100).ToLeft == false);
            Assert.True(tree.FindNodeByKey(100).Node.NodeKey == 25);
            Assert.True(tree.Count() == 3);
        }
        
        [Test]
        public void AddNode()
        {
            var rootNode = new BSTNode<int>(20, 0, null);
            var tree = new BST<int>(rootNode);

            Assert.True(tree.FindNodeByKey(15).NodeHasKey == false);
            Assert.True(tree.FindNodeByKey(15).ToLeft == true);
            Assert.True(tree.FindNodeByKey(15).Node.NodeKey == 20);
            
            Assert.True(tree.AddKeyValue(15, 0));
            Assert.True(tree.AddKeyValue(25, 0));
            
            Assert.False(tree.AddKeyValue(15, 0));
            Assert.False(tree.AddKeyValue(25, 0));
            
            Assert.True(tree.FindNodeByKey(15).NodeHasKey == true);
            Assert.True(tree.FindNodeByKey(25).NodeHasKey == true);
            Assert.True(tree.Count() == 3);
        }
        
        [Test]
        public void AddNodeToEmpty()
        {
            var rootNode = new BSTNode<int>(78, 0, null);
            var tree = new BST<int>(null);

            Assert.True(tree.AddKeyValue(15, 0));
            Assert.True(tree.AddKeyValue(10, 0));
            Assert.True(tree.AddKeyValue(25, 0));
            
            Assert.True(tree.Count() == 3);
        }
        
        [Test]
        public void FindMaxRootNode()
        {
            var rootNode = new BSTNode<int>(8, 0, null);
            var tree = new BST<int>(rootNode);

            tree.AddKeyValue(4, 0);
            tree.AddKeyValue(12, 0);
            tree.AddKeyValue(2, 0);
            tree.AddKeyValue(6, 0);
            tree.AddKeyValue(10, 0);
            tree.AddKeyValue(14, 0);
            tree.AddKeyValue(1, 0);
            tree.AddKeyValue(3, 0);
            tree.AddKeyValue(5, 0);
            tree.AddKeyValue(7, 0);
            tree.AddKeyValue(9, 0);
            tree.AddKeyValue(11, 0);
            tree.AddKeyValue(13, 0);
            tree.AddKeyValue(15, 0);

            var maxNode = tree.FinMinMax(rootNode, true);
            var minNode = tree.FinMinMax(rootNode, false);
            
            Assert.True(maxNode.NodeKey == 15);
            Assert.True(minNode.NodeKey == 1);
        }
        
        [Test]
        public void FindMaxSubtreeNode()
        {
            var rootNode = new BSTNode<int>(8, 0, null);
            var tree = new BST<int>(rootNode);

            tree.AddKeyValue(4, 0);
            tree.AddKeyValue(12, 0);
            tree.AddKeyValue(2, 0);
            tree.AddKeyValue(6, 0);
            tree.AddKeyValue(10, 0);
            tree.AddKeyValue(14, 0);
            tree.AddKeyValue(1, 0);
            tree.AddKeyValue(3, 0);
            tree.AddKeyValue(5, 0);
            tree.AddKeyValue(7, 0);
            tree.AddKeyValue(9, 0);
            tree.AddKeyValue(11, 0);
            tree.AddKeyValue(13, 0);
            tree.AddKeyValue(15, 0);

            var maxNode = tree.FinMinMax(rootNode.LeftChild, true);
            var minNode = tree.FinMinMax(rootNode.RightChild, false);
            
            Assert.True(maxNode.NodeKey == 7);
            Assert.True(minNode.NodeKey == 9);
        }
        
        [Test]
        public void DeleteNode()
        {
            var rootNode = new BSTNode<int>(8, 0, null);
            var tree = new BST<int>(rootNode);

            tree.AddKeyValue(4, 0);
            tree.AddKeyValue(12, 0);
            tree.AddKeyValue(2, 0);
            tree.AddKeyValue(6, 0);
            tree.AddKeyValue(10, 0);
            tree.AddKeyValue(14, 0);
            tree.AddKeyValue(1, 0);
            tree.AddKeyValue(3, 0);
            tree.AddKeyValue(5, 0);
            tree.AddKeyValue(7, 0);
            tree.AddKeyValue(9, 0);
            tree.AddKeyValue(11, 0);
            tree.AddKeyValue(13, 0);
            tree.AddKeyValue(15, 0);

            Assert.True(tree.FindNodeByKey(12).NodeHasKey == true);
            
            tree.DeleteNodeByKey(12);
            
            Assert.True(tree.FindNodeByKey(12).NodeHasKey == false);
            Assert.True(tree.FindNodeByKey(12).ToLeft == false);
            Assert.True(tree.FindNodeByKey(12).Node.NodeKey == 11);
            Assert.True(rootNode.RightChild.NodeKey == 13);
        }
    }
}