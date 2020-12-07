using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class aBST
    {
        public int?[] Tree; // массив ключей

        public aBST(int depth)
        {
            // правильно рассчитайте размер массива для дерева глубины depth:
            int tree_size = SumOfPowersRec(depth);
            Tree = new int?[tree_size];
            for (int i = 0; i < tree_size; i++)
                Tree[i] = null;
        }

        private int SumOfPowersRec(int depth)
        {
            if (depth == 0)
                return 1;

            return (int) Math.Pow(2, depth) + SumOfPowersRec(depth - 1);

        }

        public int? FindKeyIndex(int key)
        {
            var curIndex = 0;

            while (curIndex < Tree.Length)
            {
                if (Tree[curIndex] == null)
                    return -curIndex;

                if (Tree[curIndex].Value == key)
                    return curIndex;

                curIndex = key > Tree[curIndex].Value ? GetRightIndex(curIndex) : GetLeftIndex(curIndex);
            }
            return null; // не найден
        }

        public int AddKey(int key)
        {
            // добавляем ключ в массив
            var insertIndex = FindKeyIndex(key);

            if (insertIndex.HasValue && insertIndex >= 0 && Tree[insertIndex.Value] == key)
                return insertIndex.Value;
            
            if(!insertIndex.HasValue || insertIndex > 0)
                return -1;

            if (insertIndex.Value == 0 && Tree[0] != null)
                return -1;

            Tree[-insertIndex.Value] = key;
            return -insertIndex.Value;

            // индекс добавленного/существующего ключа или -1 если не удалось
        }

        private int GetLeftIndex(int index)
        {
            return 2 * index + 1;
        }
        
        private int GetRightIndex(int index)
        {
            return 2 * index + 2;
        }
    }
}