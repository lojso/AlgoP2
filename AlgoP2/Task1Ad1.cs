using System.Collections.Generic;
using Task1;

namespace AlgoP2
{
    public class Task1Ad1
    {
        public static Dictionary<SimpleTreeNode<T>, int> TaskCalculateNodeLevels<T>(SimpleTree<T> tree)
        {
            Dictionary<SimpleTreeNode<T>, int> nodeLevels = new Dictionary<SimpleTreeNode<T>, int>();
            
            var queue = new Queue<SimpleTreeNode<T>>();
            queue.Enqueue(tree.Root);
            while (queue.Count > 0)
            {
                var currentNode = queue.Dequeue();
                
                if (currentNode.Parent == null && !nodeLevels.ContainsKey(currentNode))
                {
                    nodeLevels.Add(currentNode, 0);    
                } 
                else
                {
                    nodeLevels.Add(currentNode, nodeLevels[currentNode.Parent] + 1);
                }

                if (currentNode.Children == null)
                    continue;

                foreach (var node in currentNode.Children)
                {
                    queue.Enqueue(node);
                }
            }

            return nodeLevels;
        }
    }
}