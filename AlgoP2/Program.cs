using System.Collections.Generic;
using AlgorithmsDataStructures2;
using Task1;

namespace AlgoP2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, int> d = new Dictionary<string, int>();
            d.Add("1", 1);
            d.Add("2", 2);
            object a = d["3"];
        }
    }
}