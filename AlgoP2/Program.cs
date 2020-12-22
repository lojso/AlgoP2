using System;
using AlgorithmsDataStructures2;

namespace AlgoP2
{
    internal class Program
    {
        // TODO: граничные случаи
        public static void Main(string[] args)
        {
            var heap = new Heap();
            heap.MakeHeap(new int[]{11, 1, 3, 8, 9, 4, 7}, 0);
            // heap.Add(11);
            // heap.Add(1);
            // heap.Add(3);
            // heap.Add(8);
            // heap.Add(9);
            // heap.Add(4);
            // heap.Add(7);

            var b = heap.GetMax();
            b = heap.GetMax();
            b = heap.GetMax();
            b = heap.GetMax();
            b = heap.GetMax();
            b = heap.GetMax();
            b = heap.GetMax();

            Console.WriteLine("fin");
        }
    }
}