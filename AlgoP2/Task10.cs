using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Vertex<T>
    {
        public bool Hit;
        public T Value;

        public Vertex(T val)
        {
            Value = val;
            Hit = false;
        }
    }

    public class SimpleGraph<T>
    {
        public Vertex<T> [] vertex;
        public int [,] m_adjacency;
        public int max_vertex;
        private int _size;

        public SimpleGraph(int size)
        {
            _size = size;
            max_vertex = size;
            m_adjacency = new int [size,size];
            vertex = new Vertex<T> [size];
        }
	
        public void AddVertex(T value)
        {
            for (var i = 0; i < vertex.Length; i++)
            {
                if (vertex[i] == null)
                {
                    vertex[i] = new Vertex<T>(value);
                    return;
                }
            }
        }

        // здесь и далее, параметры v -- индекс вершины
        // в списке  vertex
        public void RemoveVertex(int v)
        {
            vertex[v] = null;
            for (int i = 0; i < _size; i++)
            {
                if (m_adjacency[v, i] != 0)
                {
                    m_adjacency[v, i] = 0;
                    m_adjacency[i, v] = 0;
                }
            }

            // ваш код удаления вершины со всеми её рёбрами
        }
	
        public bool IsEdge(int v1, int v2)
        {
            // true если есть ребро между вершинами v1 и v2
            return m_adjacency[v1, v2] != 0;
        }
	
        public void AddEdge(int v1, int v2)
        {
            m_adjacency[v1, v2] = 1;
            m_adjacency[v2, v1] = 1;
            // добавление ребра между вершинами v1 и v2
        }
	
        public void RemoveEdge(int v1, int v2)
        {
            m_adjacency[v1, v2] = 0;
            m_adjacency[v2, v1] = 0;
            // удаление ребра между вершинами v1 и v2
        }
        
        public List<Vertex<T>> DepthFirstSearch(int VFrom, int VTo)
        {
            ClearVisited();
            Stack<int> path = new Stack<int>();
            var currNode = VFrom;

            do
            {
                SetVisited(currNode);
                path.Push(currNode);

                if (currNode == VTo)
                {
                    path.Push(currNode);
                    return StackToList(path);
                }

                while (path.Count > 0)
                {
                    currNode = path.Peek();
                    var neighbours = GetUnvisitedNeighboursIndexes(currNode);
                    if (neighbours.Count > 0)
                    {
                        if (neighbours.Contains(VTo))
                        {
                            path.Push(VTo);
                            return StackToList(path);
                        }

                        currNode = neighbours[0];
                        break;
                    }

                    path.Pop();
                }
            } while (path.Count > 0);

            return new List<Vertex<T>>();

            // Узлы задаются позициями в списке vertex.
            // Возвращается список узлов -- путь из VFrom в VTo.
            // Список пустой, если пути нету.
        }

        // private void DFS(int currentNodeIndex, int targetNodeIndex, Stack<int> dfsStack)
        // {
        //     SetVisited(currentNodeIndex);
        // }

        private void ClearVisited()
        {
            foreach (var vertexNode in vertex)
            {
                vertexNode.Hit = false;
            }
        }

        private bool IsVisited(int nodeIndex)
        {
            return vertex[nodeIndex].Hit;
        }

        private void SetVisited(int nodeIndex)
        {
            vertex[nodeIndex].Hit = true;
        }

        private List<Vertex<T>> StackToList(Stack<int> dfsStack)
        {
            var result = new List<Vertex<T>>();
            while (dfsStack.Count > 0)
            {
                result.Add(vertex[dfsStack.Pop()]);
            }

            result.Reverse();
            return result;
        }

        private List<int> GetUnvisitedNeighboursIndexes(int vFrom)
        {
            var result = new List<int>();
            var neighboursIndexes = GetNeighboursIndexes(vFrom);
            
            foreach (var neighbour in neighboursIndexes)
            {
                if(vertex[neighbour].Hit != true)
                    result.Add(neighbour);
            }

            return result;
        }

        private List<int> GetNeighboursIndexes(int nodeIndex)
        {
            var result = new List<int>();
            
            for (int i = 0; i < _size; i++)
            {
                if (m_adjacency[nodeIndex, i] != 0) 
                    result.Add(i);
            }

            return result;
        }
    }
}