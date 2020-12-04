using System;
using System.Collections.Generic;
using AlgorithmsDataStructures2;

namespace AlgoP2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            BSTNode<int> root = new BSTNode<int>(15, 0, null);
            BST<int> tree = new BST<int>(root);

            tree.AddKeyValue(10,0);
            tree.AddKeyValue(20,0);
            tree.AddKeyValue(5,0);
            tree.AddKeyValue(13,0);
            tree.AddKeyValue(18,0);
            tree.AddKeyValue(25,0);

            tree.DeepAllNodes(0);
            Console.WriteLine(ListToStr(tree.DeepAllNodes(1)));
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