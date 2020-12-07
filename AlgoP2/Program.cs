using System;
using System.Collections.Generic;
using AlgorithmsDataStructures2;
using Task3;

namespace AlgoP2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            aBST atree = new aBST(2);

            atree.AddKey(15);
            //atree.AddKey(10);
            atree.AddKey(20);
            atree.AddKey(17);
            atree.AddKey(25);

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