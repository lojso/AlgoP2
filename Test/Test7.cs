using Task9;
using NUnit.Framework;

namespace Test
{
    [TestFixture]
    public class Test7
    {
        [Test]
        public void TestMakeHeapEmptyDepth0()
        {
            Heap heap = new Heap();
            heap.MakeHeap(new int[]{}, 0);
            
            Assert.True(heap.GetMax() == -1);
            Assert.True(heap.Add(1));
            Assert.True(!heap.Add(2));
            Assert.True(heap.GetMax() == 1);
        }
        
        [Test]
        public void TestMakeHeapEmptyDepth1()
        {
            Heap heap = new Heap();
            heap.MakeHeap(new int[]{}, 1);
            
            Assert.True(heap.GetMax() == -1);
            Assert.True(heap.Add(1));
            Assert.True(heap.Add(2));
            Assert.True(heap.Add(3));
            Assert.True(!heap.Add(4));
            Assert.True(heap.GetMax() == 3);
        }
        
        [Test]
        public void TestMakeHeapSortedExceedDepth1()
        {
            Heap heap = new Heap();
            heap.MakeHeap(new int[]{1, 2, 3, 4}, 1);
            
            Assert.True(heap.Add(4) == false);
            Assert.True(heap.GetMax() == 3);
            Assert.True(heap.Add(4) == true);
            Assert.True(heap.GetMax() == 4);
        }
        
        [Test] 
        public void MakeHeapSortedNotFullDepth1()
        {
            Heap heap = new Heap();
            heap.MakeHeap(new int[]{1, 3}, 1);
            
            Assert.True(heap.Add(4) == true);
            Assert.True(heap.Add(5) == false);
            Assert.True(heap.GetMax() == 4);
            Assert.True(heap.GetMax() == 3);
            Assert.True(heap.GetMax() == 1);
            Assert.True(heap.GetMax() == -1);
        }
    }
}