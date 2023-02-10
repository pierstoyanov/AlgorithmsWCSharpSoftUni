
using System.ComponentModel.Design;
using System.Security.Cryptography;

public class KosarajuSharir
{
    static void Main(string[] args)
    {
        var nodes = int.Parse(Console.ReadLine());
        var lines = int.Parse(Console.ReadLine());

        var graph = new List<int>[nodes];
        var reversedGraph = new List<int>[nodes];

        for (int node = 0; node < graph.Length; node++)
        {
            graph[node] = new List<int>();
            reversedGraph[node] = new List<int>();
        }

/*        // read graph
        for (int i = 0; i < lines; i++)
        {
            var line = Console.ReadLine().Split(", ")
                .Select(int.Parse)
                .ToArray();

            var node = line[0];

            graph[node].AddRange(line.Skip(1));
        }*/

        // read graph and reverse
        for (int i = 0; i < lines; i++)
        {
            var line = Console.ReadLine().Split(", ")
                        .Select(int.Parse)
                        .ToArray();

            var node = line[0];

            for (int j = 0; j < line.Length; j++)
            {
                var child = line[j];
                graph[node].Add(child);
                reversedGraph[child].Add(node);
            }
        }

        var visited = new bool[graph.Length];
        var sorted = new Stack<int>();

        for (int node = 0; node < graph.Length; node++)
        {
            DFS(node, graph, visited, sorted);
        }

        visited = new bool[graph.Length];


        Console.WriteLine("Strongly Connected Components:");
        while (sorted.Count > 0)
        {
            var node = sorted.Pop();
            var component = new Stack<int>();

            if (visited[node])
            {
                continue;
            }

            DFS(node, reversedGraph, visited, component);

            Console.WriteLine($"{{{string.Join(",", component)}}}");
        }
    }

    private static void DFS(int node, List<int>[] graph, bool[] visited, Stack<int> result)
    {
        if (visited[node]) return;

        visited[node] = true;

        foreach (var child in graph[node])
        {
            DFS(child, graph, visited, result);
        }

        result.Push(node);
    }
}
