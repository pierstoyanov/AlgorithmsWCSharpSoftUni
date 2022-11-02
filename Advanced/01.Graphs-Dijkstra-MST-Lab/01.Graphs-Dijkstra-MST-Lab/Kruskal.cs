using System;
using System.Collections.Generic;
using System.Linq;

public class Kruskal
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

    public static void Main(string[] args)
    {
        forest = new List<Edge>(); 
        edges = new List<Edge>();

        // read graph
        var count = int.Parse(Console.ReadLine());
        var maxNode = -1;

        for (int i = 0; i < count; i++)
        {
            var edgeData = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            var firstNode = edgeData[0];
            var secondNode = edgeData[1];

            if (firstNode > maxNode)
            {
                maxNode = firstNode;
            }
            if (secondNode > maxNode)
            {
                maxNode = secondNode;
            }

            edges.Add(new Edge
            {
                First = firstNode,
                Second = secondNode,
                Weight = edgeData[2]
            });
        }

        // order 
        var sortedEdges = edges.OrderBy(e => e.Weight).ToArray();


        // idx = node, value = current parent
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

        foreach (var edge in forest)
        {
            Console.WriteLine($"{edge.First} - {edge.Second}");
        }

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

