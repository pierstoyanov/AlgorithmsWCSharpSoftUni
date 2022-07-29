using System;
using System.Collections.Generic;
using System.Linq;


class TopologicalSortingDFS 
{
    private static Dictionary<string, List<string>> graph;
    private static Stack<string> sorted;
    private static HashSet<string> visited;
    private static HashSet<string> cycles;

    public static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());

        graph = ReadGrap(n);
        sorted = new Stack<string>();
        visited = new HashSet<string>();
        cycles = new HashSet<string>();

        var hasCycle = false;
        foreach (var node in graph.Keys)
        {
            try
            {
                DFS(node); 
            }
            catch (InvalidOperationException ex)
            {
                
                Console.WriteLine(ex.Message);
                hasCycle = true;
                break;
            }
        }

        if (!hasCycle)
        {
            Console.WriteLine($"Topological sorting: {string.Join(", ", sorted)}");    
        }
        
    }

    private static void DFS(string node)
    {

        if (cycles.Contains(node))
        {
            throw new InvalidOperationException("Invalid topological sorting");
        }

        if (visited.Contains(node))
        {
            return;
        }

        cycles.Add(node);
        visited.Add(node);

        foreach (var child in graph[node])
        {
            DFS(child);
        }

        sorted.Push(node);
        cycles.Remove(node);
    }

    private static Dictionary<string, List<string>> ReadGrap(int n)
    {
        var result = new Dictionary<string, List<string>>();

        for (int i = 0; i < n; i++)
        {
            var line = Console.ReadLine().Split("->", StringSplitOptions.RemoveEmptyEntries)
            .Select(e => e.Trim())
            .ToArray();

            var key = line[0];
            //if there are no children
            if (line.Length == 1)
            {
                result[key] = new List<string>();
            }
            else
            {
                var children = line[1].Split(", ").ToList();
                
                result[key] = children;
            }
        }

        return result;
    }
}
