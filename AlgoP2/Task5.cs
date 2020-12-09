using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public static class BalancedBST
    {
        public static int[] GenerateBBSTArray(int[] a)
        {
            var depth = Math.Ceiling(Math.Log(a.Length + 1, 2) - 1);
            var treeArrayLen = (int) Math.Pow(2, depth + 1) - 1;
            var treeArray = new int[treeArrayLen];
            Array.Sort(a);
            
            AddArray(a, 0, a.Length, treeArray, 0);

            return treeArray;
        }

        public static void AddArray(int[] array, int startIndex, int endIndex, int[] tree, int currentInsertionIndex)
        {
            int centerIndex = startIndex + (int) Math.Floor((endIndex - startIndex) / 2f);
            tree[currentInsertionIndex] = array[centerIndex];
            
            if (startIndex == centerIndex)
                return;
            
            AddArray(array, startIndex, centerIndex, tree, GetLeftIndex(currentInsertionIndex));
            
            if(centerIndex + 1 < endIndex)
                AddArray(array, centerIndex + 1, endIndex, tree, GetRightIndex(currentInsertionIndex));
        }
        
        private static int GetLeftIndex(int index)
        {
            return 2 * index + 1;
        }
        
        private static int GetRightIndex(int index)
        {
            return 2 * index + 2;
        }
    }
}