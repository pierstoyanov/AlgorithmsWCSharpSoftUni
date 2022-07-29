using System;
using System.Collections.Generic;
using System.Linq;


class TopologicalSorting 
{
    private static Dictionary<string, List<string>> graph;
    private static Dictionary<string, int> dependencies;

    //priority queue - sort dep items by value
    static void Main(string[] args)
    {    
        var n = int.Parse(Console.ReadLine());

        graph = ReadGrap(n);
        dependencies = ExtractDependencies(graph);
        var sorted = new List<string>();

        while (dependencies.Count > 0)
        {
            var nodeToRemove = dependencies.FirstOrDefault(d => d.Value == 0).Key;
           
            if (nodeToRemove == null)
            {
                break;
            }

            dependencies.Remove(nodeToRemove);
            sorted.Add(nodeToRemove);  

            foreach (var child in graph[nodeToRemove])
            {
                dependencies[child] -= 1;
            }

        }

        if (dependencies.Count == 0) 
        {
            Console.WriteLine($"Topological sorting: {string.Join(", ", sorted)}");
        }
        else
        {
            Console.WriteLine("Invalid topological sorting");
        }
    }

    private static Dictionary<string, int> ExtractDependencies(Dictionary<string, List<string>> graphExtract)
    {
        var result = new Dictionary<string, int>();

        foreach (var kvp in graphExtract)
        {
            var node = kvp.Key;
            var children = kvp.Value;
            //add current node
            if (!result.ContainsKey(node))
            {
                result[node] = 0; 
            }

            foreach (var child in children)
            {
                //add child or increase dependency
                if (!result.ContainsKey(child))
                {
                    result[child] = 1;
                }
                else
                {
                    result[child] += 1;
                }
            }
        }

        return result;
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
