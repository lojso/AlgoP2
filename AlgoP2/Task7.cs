using System;
using System.Collections.Generic;

namespace Task9
{
    public class Heap
    {
        public int[] HeapArray; // хранит неотрицательные числа-ключи

        private int _depth;

        public Heap()
        {
            HeapArray = null;
        }

        public void MakeHeap(int[] a, int depth)
        {
            // создаём массив кучи HeapArray из заданного
            // размер массива выбираем на основе глубины depth
            // ...
            HeapArray = new int[SumOfPowersRec(depth)];
            _depth = depth;

            for (var index = 0; index < HeapArray.Length; index++)
            {
                HeapArray[index] = -1;
            }

            foreach (var elem in a)
            {
                Add(elem);
            }
        }

        private int SumOfPowersRec(int depth)
        {
            if (depth == 0)
                return 1;

            return (int) Math.Pow(2, depth) + SumOfPowersRec(depth - 1);
        }

        public int GetMax()
        {
            // вернуть значение корня и перестроить кучу
            var maxVal = HeapArray[0];
            HeapArray[0] = -1;
            var lastIndex = GetLastIndex();
            if(lastIndex != -1)
            {
                SwapElementsByIndexes(0, lastIndex);
                RecalculateLevelAfterDeletion(0, 1);
            }
            
            return maxVal; // если куча пуста
        }

        public bool Add(int key)
        {
            // добавляем новый элемент key в кучу и перестраиваем её
            var lastEmptyIndex = GetLastEmptyIndex();
            if (lastEmptyIndex == -1)
                return false;

            HeapArray[lastEmptyIndex] = key;
            
            RecalculateAfterInsertion(lastEmptyIndex);

            return true;
        }

        private void RecalculateLevelAfterDeletion(int activeNodeIndex, int currentDepth)
        {
            var activeNodeValue = HeapArray[activeNodeIndex];
            var maxIndex = GetMaxIndex(currentDepth);
            
            if(HeapArray[maxIndex] <= activeNodeValue)
                return;
            
            SwapElementsByIndexes(activeNodeIndex, maxIndex);
            
            if(currentDepth == _depth)
                return;
            
            RecalculateLevelAfterDeletion(maxIndex, currentDepth + 1);
        }

        private void RecalculateAfterInsertion(int curInsertionIndex)
        {
            int parentIndex = GetParentIndex(curInsertionIndex);
            
            if(parentIndex < 0)
                return;
            
            if(HeapArray[curInsertionIndex] < HeapArray[parentIndex])
                return;
            
            SwapElementsByIndexes(curInsertionIndex, parentIndex);
            
            RecalculateAfterInsertion(parentIndex);
        }

        private int GetParentIndex(int curInsertionIndex)
        {
            var subtrahend = curInsertionIndex % 2 == 0 ? 2 : 1;
            return (curInsertionIndex - subtrahend) / 2;
        }

        private int GetMaxIndex(int currentDepth)
        {
            var curIndex = GetStartIndexFromDepth(currentDepth);
            
            for (int i = GetStartIndexFromDepth(currentDepth); i < GetEndIndexFromDepth(currentDepth); i++)
            {
                if (HeapArray[curIndex] < HeapArray[i])
                    curIndex = i;
            }

            return curIndex;
        }

        private int GetStartIndexFromDepth(int depth)
        {
            return (int) (Math.Pow(2, depth) - 1);
        }
        
        private int GetEndIndexFromDepth(int depth)
        {
            return GetStartIndexFromDepth(depth + 1);
        }

        private void SwapElementsByIndexes(int i1, int i2)
        {
            int temp = HeapArray[i1];
            HeapArray[i1] = HeapArray[i2];
            HeapArray[i2] = temp;
        }

        private int GetLastIndex()
        {
            for (var i = HeapArray.Length - 1; i >= 0; i--)
            {
                if (HeapArray[i] != -1)
                    return i;
            }

            return -1;
        }
        
        private int GetLastEmptyIndex()
        {
            if (HeapArray[0] == -1)
                return 0;
            
            for (var i = HeapArray.Length - 1; i >= 1; i--)
            {
                if (HeapArray[i-1] != -1 && HeapArray[i] == -1)
                    return i;
            }

            return -1;
        }
    }
}