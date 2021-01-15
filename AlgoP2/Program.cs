using System;
using System.Collections.Generic;
using AlgorithmsDataStructures2;

namespace AlgoP2
{
    internal class Program
    {
        // TODO: граничные случаи
        public static void Main(string[] args)
        {
            var g = new SimpleGraph<int>(9);

            g.AddVertex(0);
            g.AddVertex(1);
            g.AddVertex(2);
            g.AddVertex(3);
            g.AddVertex(4);
            g.AddVertex(5);
            g.AddVertex(6);
            g.AddVertex(7);
            g.AddVertex(8);
            
            g.AddEdge(0,1);
            g.AddEdge(0,2);
            g.AddEdge(0,3);
            g.AddEdge(0,4);
            
            g.AddEdge(1,0);
            g.AddEdge(1,2);
            g.AddEdge(1,6);
            
            g.AddEdge(2,1);
            g.AddEdge(2,0);
            g.AddEdge(2,3);
            
            g.AddEdge(3,2);
            g.AddEdge(3,0);
            g.AddEdge(3,4);
            g.AddEdge(3,7);
            
            g.AddEdge(4,0);
            g.AddEdge(4,3);
            g.AddEdge(4,5);
            
            g.AddEdge(5,4);
            g.AddEdge(5,6);
            g.AddEdge(5,7);
            
            g.AddEdge(6,1);
            g.AddEdge(6,5);
            
            g.AddEdge(7,5);
            g.AddEdge(7,3);
            
            var result = g.BreadthFirstSearch(1, 5);
            Console.WriteLine(result);

        }
    }
}