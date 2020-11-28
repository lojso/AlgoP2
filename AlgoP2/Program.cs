using System.Collections.Generic;
using AlgorithmsDataStructures2;
using Task1;

namespace AlgoP2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // 11, 5, 4, 1, 3, 15, 17, -1, 46, -8, 0
            var rootNode = new BSTNode<int>(15, 1, null);
            
            var tree = new BST<int>(rootNode);
            
            tree.AddKeyValue(10, 0);
            tree.AddKeyValue(20, 0);
            tree.AddKeyValue(5, 0);
            tree.AddKeyValue(17, 0);
            tree.AddKeyValue(16, 0);
            tree.AddKeyValue(22, 0);
            tree.AddKeyValue(21, 0);
            // tree.AddKeyValue(3, 0);
            // tree.AddKeyValue(15, 0);
            // tree.AddKeyValue(17, 0);
            // tree.AddKeyValue(-1, 0);
            // tree.AddKeyValue(46, 0);
            // tree.AddKeyValue(-8, 0);
            // tree.AddKeyValue(0, 0);

            tree.DeleteNodeByKey(15);
            //tree.DeleteNodeByKey(27);
        }
    }
}