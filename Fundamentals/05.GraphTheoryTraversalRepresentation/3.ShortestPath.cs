using System;
using System.Collections.Generic;
using System.Linq;

class ShortestPathUnweighted
{
    private static List<int>[] graph;
    private static bool[] used;
    private static int[] parent;

    public static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var edges = int.Parse(Console.ReadLine());

        graph = new List<int>[n + 1];
        used = new bool[graph.Length];
        parent = new int[graph.Length];

        //fill array with non 0 items, beause 0 node is not the origin
        Array.Fill(parent, -1);

        //avoid null refference exception
        for (int node = 0; node < graph.Length; node++)
        {
            graph[node] = new List<int>();
        }

        for (int i = 0; i < edges; i++)
        {
            var edge = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

            var firstNode = edge[0];
            var secondNode = edge[1];

            graph[firstNode].Add(secondNode);
            graph[secondNode].Add(firstNode);
        }

        var start = int.Parse(Console.ReadLine());
        var destination = int.Parse(Console.ReadLine());

        BFS(start, destination);
    }

    private static void BFS(int startNode, int destination)
    {
        var queue = new Queue<int>();
        queue.Enqueue(startNode);

        used[startNode] = true;

        while (queue.Count > 0)
        {
            var node = queue.Dequeue();

            if (node == destination)
            {
                var path = GetPath(destination);
                Console.WriteLine($"Shortest path length is: {path.Count - 1}");
                Console.WriteLine(string.Join(" ", path));
                break;    
            }

            foreach (var child in graph[node])
            {
                if (!used[child])
                {
                    parent[child] = node;
                    used[child] = true;
                    queue.Enqueue(child);
                }
            }

        }

    }

    private static Stack<int> GetPath(int destination)
    {
        var path = new Stack<int>();

        var node = destination;

        while (node != -1)
        {
            path.Push(node);
            node = parent[node];
        }
        
        return path;
    }
}
