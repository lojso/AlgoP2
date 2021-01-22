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
        
        public List<Vertex<T>> BreadthFirstSearch(int VFrom, int VTo)
        {
            // узлы задаются позициями в списке vertex.
            // возвращает список узлов -- путь из VFrom в VTo
            // или пустой список, если пути нету
            ClearVisited();
            Queue<int> q = new Queue<int>();
            q.Enqueue(VFrom);
            int[] path = new int[vertex.Length];
            for (var index = 0; index < path.Length; index++)
            {
                path[index] = -1;
            }

            while (q.Count > 0)
            {
                var curNode = q.Dequeue();
                SetVisited(curNode);
                var neighbours = GetUnvisitedNeighboursIndexes(curNode);
                foreach (var neighbour in neighbours)
                {
                    if(q.Contains(neighbour) == false)
                    {
                        q.Enqueue(neighbour);
                        path[neighbour] = curNode;
                    }
                }
            }

            return ReconstructPath(VFrom, VTo, path);
        }
        
        public List<Vertex<T>> WeakVertices()
        {
            var result = new List<Vertex<T>>();
            
            for (var i = 0; i < vertex.Length; i++)
            {
                if(vertex[i] == null)
                    continue;
                
                if(IsWeak(i))
                    result.Add(vertex[i]);
            }

            return result;
        }

        private bool IsWeak(int vertexIndex)
        {
            var neighbours = GetNeighboursIndexes(vertexIndex);
            for (var i = 0; i < neighbours.Count; i++)
            {
                var firstIndex = neighbours[i];
                for (int j = i + 1; j < neighbours.Count; j++)
                {
                    var secondIndex = neighbours[j];
                    if (IsEdge(firstIndex, secondIndex))
                        return false;
                }
            }

            return true;
        }

        private List<Vertex<T>> ReconstructPath(int from, int to, int[] path)
        {
            List<int> reconstructedPath = new List<int>();
            for (int curNode = to; curNode != -1; curNode = path[curNode])
            {
                reconstructedPath.Add(curNode);
            }
            
            if(reconstructedPath.Count == 0)
                return new List<Vertex<T>>();
            
            if(reconstructedPath[0] == -1)
                return new List<Vertex<T>>();

            if (reconstructedPath[0] != to || reconstructedPath[reconstructedPath.Count - 1] != from)
                return new List<Vertex<T>>();

            return BuildVertextList(reconstructedPath);


        }

        private List<Vertex<T>> BuildVertextList(List<int> reconstructedPath)
        {
            var vertexses = new List<Vertex<T>>();
            for (var i = reconstructedPath.Count - 1; i >= 0; i--)
            {
                vertexses.Add(vertex[reconstructedPath[i]]);
            }

            return vertexses;
        }

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