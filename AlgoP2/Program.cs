using System;
using System.Collections.Generic;
using AlgorithmsDataStructures2;

namespace AlgoP2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var a = new[] {15, 8, 20, 30, 4, 12};
            // 4 8 12 15 20 30

            var bTree = new BalancedBST();
            bTree.GenerateTree(a);
            
            var n1 = new BSTNode(1, null);
            var n2 = new BSTNode(2, null);
            var n3 = new BSTNode(3, null);
            var n4 = new BSTNode(4, null);
            var n5 = new BSTNode(5, null);
            var n6 = new BSTNode(6, null);
            
            BalancedBST.AddNodeDebug(n1, n2, true);
            BalancedBST.AddNodeDebug(n1, n3, false);
            
            // BalancedBST.AddNodeDebug(n3, n4, true);
            // BalancedBST.AddNodeDebug(n3, n5, false);
            //
            // BalancedBST.AddNodeDebug(n5, n6, true);
            
            

            var res = bTree.IsBalanced(n1);

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