using System;
using System.Collections.Generic;
    
// https://skillsmart.ru/algo/15-121-cm/bcd63523a1.html
namespace AlgorithmsDataStructures2
{
    public class BSTNode<T>
    {
        public int NodeKey; // ключ узла
        public T NodeValue; // значение в узле
        public BSTNode<T> Parent; // родитель или null для корня
        public BSTNode<T> LeftChild; // левый потомок
        public BSTNode<T> RightChild; // правый потомок	

        public BSTNode(int key, T val, BSTNode<T> parent)
        {
            NodeKey = key;
            NodeValue = val;
            Parent = parent;
            LeftChild = null;
            RightChild = null;
        }

        public override string ToString()
        {
            return NodeKey + " : " + NodeValue;
        }
    }

    // промежуточный результат поиска
    public class BSTFind<T>
    {
        // null если в дереве вообще нету узлов
        public BSTNode<T> Node;

        // true если узел найден
        public bool NodeHasKey;

        // true, если родительскому узлу надо добавить новый левым
        public bool ToLeft;

        public BSTFind()
        {
            Node = null;
        }
    }

    public class BST<T>
    {
        BSTNode<T> Root; // корень дерева, или null
        private int _count;

        public BST(BSTNode<T> node)
        {
            Root = node;
            _count = Root == null ? 0 : 1;
        }

        public BSTFind<T> FindNodeByKey(int key)
        {
            // ищем в дереве узел и сопутствующую информацию по ключу
            BSTFind<T> result = new BSTFind<T>();
            result.Node = Root;
            result.ToLeft = result.Node.NodeKey > key;
            result.NodeHasKey = result.Node.NodeKey == key;

            if (Root == null || result.NodeHasKey)
                return result;

            result.ToLeft = result.Node.NodeKey > key;

            var nextNode = result.Node.NodeKey > key ? result.Node.LeftChild : result.Node.RightChild;


            // Надо переделать на result.Node.Next
            while (nextNode != null)
            {
                result.Node = nextNode;
                result.ToLeft = result.Node.NodeKey > key;

                if (result.Node.NodeKey == key)
                {
                    result.NodeHasKey = true;
                    return result;
                }

                nextNode = result.Node.NodeKey > key ? result.Node.LeftChild : result.Node.RightChild;
            }

            return result;
        }

        public bool AddKeyValue(int key, T val)
        {
            var findResult = FindNodeByKey(key);

            if (findResult.NodeHasKey)
                return false;

            if (findResult.ToLeft)
            {
                findResult.Node.LeftChild = new BSTNode<T>(key, val, findResult.Node);
            }
            else
            {
                findResult.Node.RightChild = new BSTNode<T>(key, val, findResult.Node);
            }

            _count++;
            return true;
        }

        public BSTNode<T> FinMinMax(BSTNode<T> FromNode, bool FindMax)
        {
            var curNode = FromNode;
            while (GetNextNode(curNode, FindMax) != null && curNode != null)
            {
                curNode = GetNextNode(curNode, FindMax);
            }

            return curNode;

            BSTNode<T> GetNextNode(BSTNode<T> node, bool isRight)
            {
                return isRight ? node.RightChild : node.LeftChild;
            }
        }

        public bool DeleteNodeByKey(int key)
        {
            var nodeToDelete = FindNodeByKey(key);
            if (!nodeToDelete.NodeHasKey)
                return false;



            // // Ситуации:
            // // Мы хотим удалить лист
            if (nodeToDelete.Node.LeftChild == null && nodeToDelete.Node.RightChild == null)
            {
                if (nodeToDelete.Node.Parent == null)
                {
                    Root = null;
                }
                else
                {
                    BreakNode(nodeToDelete.Node);
                }
            }
            // // // Мы хотим удалить узел с только левым потомком
            else if (nodeToDelete.Node.LeftChild != null && nodeToDelete.Node.RightChild == null)
            {
                var insertNode = nodeToDelete.Node.LeftChild;
                if (nodeToDelete.Node.Parent == null)
                {
                    Root = insertNode;
                    insertNode.Parent = null;
                }
                else
                {
                    BreakNode(nodeToDelete.Node);
                    InsertNode(nodeToDelete.Node.Parent, insertNode, nodeToDelete.Node.NodeKey);
                }
            }
            else
            {
                var insertNode = FinMinMax(nodeToDelete.Node.RightChild, false);
                BreakNode(insertNode);
                if (nodeToDelete.Node.Parent == null)
                {
                    insertNode.LeftChild = nodeToDelete.Node.LeftChild;
                    insertNode.RightChild = nodeToDelete.Node.RightChild;
                    nodeToDelete.Node.LeftChild.Parent = insertNode;
                    nodeToDelete.Node.RightChild.Parent = insertNode;
                    Root = insertNode;
                    insertNode.Parent = null;
                }
                else
                {
                    BreakNode(nodeToDelete.Node);
                    InsertNode(nodeToDelete.Node.Parent, insertNode, nodeToDelete.Node.NodeKey);
                    insertNode.LeftChild = nodeToDelete.Node.LeftChild;
                    insertNode.RightChild = nodeToDelete.Node.RightChild;
                    nodeToDelete.Node.LeftChild.Parent = insertNode;
                    nodeToDelete.Node.RightChild.Parent = insertNode;
                }
            }

            _count--;
            return true; // если узел не найден
        }

        private static void InsertNode(BSTNode<T> ParentNode, BSTNode<T> insertNode, int compareKey)
        {
            if (compareKey > ParentNode.NodeKey)
            {
                ParentNode.RightChild = insertNode;
            }
            else
            {
                ParentNode.LeftChild = insertNode;
            }

            insertNode.Parent = ParentNode;
        }

        private void BreakNode(BSTNode<T> nodeToDelete)
        {
            if (nodeToDelete.NodeKey > nodeToDelete.Parent.NodeKey)
            {
                nodeToDelete.Parent.RightChild = null;
            }
            else
            {
                nodeToDelete.Parent.LeftChild = null;
            }
        }

        public int Count()
        {
            return _count; // количество узлов в дереве
        }
    }
}