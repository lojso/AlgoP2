using System;
using AlgorithmsDataStructures2;

namespace AlgoP2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var heap = new Heap();
            heap.MakeHeap(new int[1], 2);
            heap.Add(11);
            heap.Add(1);
            heap.Add(3);
            heap.Add(8);
            //heap.Add(9);
            heap.Add(4);
            heap.Add(7);

            var b = heap.GetMax();
            b = heap.GetMax();
            b = heap.GetMax();
            b = heap.GetMax();
            b = heap.GetMax();
            b = heap.GetMax();
            b = heap.GetMax();

            Console.WriteLine("fin");
            
        }

        // private static string ListToStr(List<BSTNode<int>> deepAllNodes)
        // {
        //     string result = "";
        //     foreach (var node in deepAllNodes)
        //     {
        //         result += node;
        //         result += "\n";
        //     }
        //
        //     return result.Trim();
        // }
    }
}