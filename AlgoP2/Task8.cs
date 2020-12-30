using System;
using System.Collections.Generic;

namespace AlgorithmsDataStructures2
{
    public class Vertex
    {
        public int Value;
        public Vertex(int val)
        {
            Value = val;
        }
    }
  
    public class SimpleGraph
    {
        public Vertex [] vertex;
        public int [,] m_adjacency;
        public int max_vertex;
        private int _size;

        public SimpleGraph(int size)
        {
            _size = size;
            max_vertex = size;
            m_adjacency = new int [size,size];
            vertex = new Vertex [size];
        }
	
        public void AddVertex(int value)
        {
            for (var i = 0; i < vertex.Length; i++)
            {
                if (vertex[i] == null)
                {
                    vertex[i] = new Vertex(value);
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
    }
}