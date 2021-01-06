using Task9;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class Task8
    {
        [Test]
        public void AddVertex()
        {
            var g = new SimpleGraph(10);
            
            g.AddVertex(1);
            g.AddVertex(2);

            Assert.True(!g.IsEdge(1, 2));
        }
        
        [Test]
        public void RemoveVertex()
        {
            var g = new SimpleGraph(10);
            
            g.AddVertex(1);
            g.AddVertex(2);
            g.AddVertex(3);
            g.AddVertex(4);
            
            Assert.True(!g.IsEdge(1, 1));
            Assert.True(!g.IsEdge(1, 2));
            Assert.True(!g.IsEdge(1, 3));
            Assert.True(!g.IsEdge(1, 4));
            
            Assert.True(!g.IsEdge(2, 1));
            Assert.True(!g.IsEdge(2, 2));
            Assert.True(!g.IsEdge(2, 3));
            Assert.True(!g.IsEdge(2, 4));
            
            Assert.True(!g.IsEdge(3, 1));
            Assert.True(!g.IsEdge(3, 2));
            Assert.True(!g.IsEdge(3, 3));
            Assert.True(!g.IsEdge(3, 4));
            
            Assert.True(!g.IsEdge(4, 1));
            Assert.True(!g.IsEdge(4, 2));
            Assert.True(!g.IsEdge(4, 3));
            Assert.True(!g.IsEdge(4, 4));
            
            g.AddEdge(1,1);
            g.AddEdge(1,2);
            g.AddEdge(1,3);
            g.AddEdge(1,4);
            
            g.AddEdge(2,1);
            g.AddEdge(2,2);
            g.AddEdge(2,3);
            g.AddEdge(2,4);
            
            g.AddEdge(3,1);
            g.AddEdge(3,2);
            g.AddEdge(3,3);
            g.AddEdge(3,4);
            
            g.AddEdge(4,1);
            g.AddEdge(4,2);
            g.AddEdge(4,3);
            g.AddEdge(4,4);
            
            Assert.True(g.IsEdge(1, 1));
            Assert.True(g.IsEdge(1, 2));
            Assert.True(g.IsEdge(1, 3));
            Assert.True(g.IsEdge(1, 4));
            
            Assert.True(g.IsEdge(2, 1));
            Assert.True(g.IsEdge(2, 2));
            Assert.True(g.IsEdge(2, 3));
            Assert.True(g.IsEdge(2, 4));
            
            Assert.True(g.IsEdge(3, 1));
            Assert.True(g.IsEdge(3, 2));
            Assert.True(g.IsEdge(3, 3));
            Assert.True(g.IsEdge(3, 4));
            
            Assert.True(g.IsEdge(4, 1));
            Assert.True(g.IsEdge(4, 2));
            Assert.True(g.IsEdge(4, 3));
            Assert.True(g.IsEdge(4, 4));
            
            g.RemoveVertex(3);
            
            Assert.True(g.IsEdge(1, 1));
            Assert.True(g.IsEdge(1, 2));
            Assert.True(!g.IsEdge(1, 3));
            Assert.True(g.IsEdge(1, 4));
            
            Assert.True(g.IsEdge(2, 1));
            Assert.True(g.IsEdge(2, 2));
            Assert.True(!g.IsEdge(2, 3));
            Assert.True(g.IsEdge(2, 4));
            
            Assert.True(!g.IsEdge(3, 1));
            Assert.True(!g.IsEdge(3, 2));
            Assert.True(!g.IsEdge(3, 3));
            Assert.True(!g.IsEdge(3, 4));
            
            Assert.True(g.IsEdge(4, 1));
            Assert.True(g.IsEdge(4, 2));
            Assert.True(!g.IsEdge(4, 3));
            Assert.True(g.IsEdge(4, 4));
            
        }
        
        [Test]
        public void AddEdge()
        {
            var g = new SimpleGraph(4);
            
            g.AddVertex(1);
            g.AddVertex(2);

            Assert.True(!g.IsEdge(1, 2));
            Assert.True(!g.IsEdge(1, 1));
            
            g.AddEdge(1, 2);
            Assert.True(g.IsEdge(1, 2));
            Assert.True(!g.IsEdge(1, 1));
            
            g.AddEdge(1, 1);
            Assert.True(g.IsEdge(1, 2));
            Assert.True(g.IsEdge(1, 1));
        }
        
        [Test]
        public void RemoveEdge()
        {
            var g = new SimpleGraph(4);
            
            g.AddVertex(1);
            g.AddVertex(2);

            g.AddEdge(1, 2);
            g.AddEdge(1, 1);
            
            Assert.True(g.IsEdge(1, 2));
            Assert.True(g.IsEdge(1, 1));

            g.RemoveEdge(1, 2);
            Assert.True(!g.IsEdge(1, 2));
            Assert.True(g.IsEdge(1, 1));
            
            g.RemoveEdge(1, 1);
            Assert.True(!g.IsEdge(1, 2));
            Assert.True(!g.IsEdge(1, 1));
            
            g.RemoveEdge(3, 3);
        }
    }
}