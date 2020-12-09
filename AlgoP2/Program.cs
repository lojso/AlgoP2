using System;
using System.Collections.Generic;
using AlgorithmsDataStructures2;
using Task4;
using Task3;

namespace AlgoP2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var a = new[] {15, 8, 20, 4, 12, 25};

            var bTree = BalancedBST.GenerateBBSTArray(a);

            Console.WriteLine("fin");
        }

        private static string ListToStr(List<BSTNode<int>> deepAllNodes)
        {
            string result = "";
            foreach (var node in deepAllNodes)
            {
                result += node;
                result += "\n";
            }

            return result.Trim();
        }
    }
}