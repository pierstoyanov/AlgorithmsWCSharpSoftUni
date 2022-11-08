using System;
using System.Collections.Generic;
using System.Linq;


namespace _03.Ex_Bellman_Ford_Longest_Path_in_DAG
{
    public class CheapTownTour
    {
        public class Edge
        {
            public int First { get; set; }
            public int Second { get; set; }
            public int Weight { get; set; }
        }

        // Data structures
        private static List<Edge> forest;
        private static List<Edge> edges;
        private static int[] parent;

        static void Main(string[] args)
        {
            forest = new List<Edge>();
            edges = new List<Edge>();

            // used for arr size
            var maxNode = -1;

            int verticesCount = int.Parse(Console.ReadLine());
            int edgesCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < edgesCount; i++)
            {
                var edgeData = Console.ReadLine().Split(" - ").Select(int.Parse).ToArray();

                var firstNode = edgeData[0];
                var secondNode = edgeData[1];

                edges.Add(new Edge
                { 
                    First = firstNode,
                    Second = secondNode,
                    Weight = edgeData[2]
                });

                if (firstNode > maxNode)
                {
                    maxNode = firstNode;
                }

                if (secondNode > maxNode)
                {
                    maxNode = secondNode;
                }
            }

            var sortedEdges = edges.OrderBy(e => e.Weight).ToArray();

            // parent arr, idx = node, value = current parent
            parent = new int[maxNode + 1];
            for (int node = 0; node < parent.Length; node++)
            {
                parent[node] = node;
            }

            foreach (var edge in sortedEdges)
            {
                var firstNodeRoot = FindRoot(edge.First);
                var secondNodeRoot = FindRoot(edge.Second);

                if (firstNodeRoot == secondNodeRoot)
                {
                    continue;
                }

                parent[firstNodeRoot] = secondNodeRoot;
                forest.Add(edge);
            }

            var totalCost = forest.Sum(x => x.Weight);
            Console.WriteLine($"Total cost: {totalCost}");
        }

        private static int FindRoot(int node)
        {
            // walk the parent arr until node is its own parent/is Root
            while (node != parent[node])
            {
                node = parent[node];
            }
            return node;
        }
    }
}
