using Task4;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class Task4
    {
        [Test]
        public void Create0Depth()
        {
            var tree = new aBST(0);
            Assert.True(tree.Tree.Length == 1);
        }
        
        [Test]
        public void Create2Depth()
        {
            var tree = new aBST(2);
            Assert.True(tree.Tree.Length == 7);
        }
        
        [Test]
        public void AddEmpty()
        {
            var tree = new aBST(0);

            Assert.True(tree.AddKey(15) == 0);
            
            Assert.True(tree.FindKeyIndex(15) == 0);
            Assert.True(tree.FindKeyIndex(11) == null);
        }
        
        [Test]
        public void Add()
        {
            var tree = new aBST(2);

            Assert.True(tree.AddKey(15) == 0);
            Assert.True(tree.AddKey(10) == 1);
            Assert.True(tree.AddKey(20) == 2);
            Assert.True(tree.AddKey(12) == 4);
            Assert.True(tree.AddKey(17) == 5);
            Assert.True(tree.AddKey(11) == -1);
            
            Assert.True(tree.AddKey(10) == 1);
            Assert.True(tree.AddKey(15) == 0);
            Assert.True(tree.AddKey(20) == 2);
            Assert.True(tree.AddKey(12) == 4);
            Assert.True(tree.AddKey(17) == 5);
            
            Assert.True(tree.FindKeyIndex(15) == 0);
            Assert.True(tree.FindKeyIndex(11) == null);
            Assert.True(tree.FindKeyIndex(5) == -3);
        }
    }
}