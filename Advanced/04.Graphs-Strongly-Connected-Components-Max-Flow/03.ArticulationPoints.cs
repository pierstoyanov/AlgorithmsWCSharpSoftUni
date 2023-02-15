using System;
using System.Collections.Generic;
using System.Linq;


namespace ArticulationPoints
{
    public class HopcroftTarjan
    {
        private static List<int>[] graph;
        private static bool[] visited;
        private static int[] depth;
        private static int[] lowpoint;
        private static int?[] parent;

        private static List<int> articulationPoints;

        static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());
            var lines = int.Parse(Console.ReadLine());

            graph = new List<int>[nodes];
            visited = new bool[nodes];
            depth = new int[nodes];
            lowpoint = new int[nodes];
            // int nullable
            parent = new int?[nodes];
            // for int arr
            // Array.Fill(parent, -1);

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>();
            }

            for (int l = 0; l < lines; l++)
            {
                var line = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();
                
                var node = line[0];

                // undirected graph
                for (int j = 0; j < line.Length; j++)
                {
                    var child = line[j];
                    graph[node].Add(child);
                    graph[child].Add(node);
                }


               // for directed graph
               // graph[node].AddRange(line.Skip(1));
            }


            articulationPoints = new List<int>();

            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node])
                {
                    continue;
                }

                FindArticulationPoint(node, 1);
            }
            
            Console.WriteLine($"Articulation points: {string.Join(", ", articulationPoints)}");
        }

        private static void FindArticulationPoint(int node, int currentDepth)
        {
            // mark node as visited, mark depth, assume lowpoint equals depth 
            visited[node] = true;
            depth[node] = currentDepth;
            lowpoint[node] = currentDepth;

            var childCount = 0;
            var isArticulationPoint = false;

            foreach (var child in graph[node])
            {
                if (!visited[child])
                {
                    parent[child] = node;
                    FindArticulationPoint(child, currentDepth += 1);
                    
                    childCount += 1;
                    // if child is visited, but the path is different than the original path
                    if (lowpoint[child] >= depth[node])
                    {
                        isArticulationPoint = true;
                    }

                    lowpoint[node] = Math.Min(lowpoint[node], lowpoint[child]);
                }
                else if (parent[node] != child)
                {
                    lowpoint[node] = Math.Min(lowpoint[node], depth[child]);
                }
            }
/*
 * 
 *          when using int arr filled with -1, 
            if ((parent[node] == -1 && childCount > 1) ||
                 (parent[node] != -1 && isArticulationPoint))*/

                // check for root and add item if is art. point
                if ((parent[node] == null && childCount > 1) ||
                (parent[node] != null && isArticulationPoint))
            {
                articulationPoints.Add(node);
            }
        }
    }
} 