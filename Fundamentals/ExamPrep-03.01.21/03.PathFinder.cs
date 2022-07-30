using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamPrep
{
    internal class PathFinder
    {
        private static List<int>[] graph;
        private static bool[] visited;
        static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());
            graph = new List<int>[nodes];

            for (int node = 0; node < nodes; node++)
            {
                var line = Console.ReadLine();

                if (string.IsNullOrEmpty(line))
                {
                    graph[node] = new List<int>();
                }
                else
                {
                    var children = line
                        .Split()
                        .Select(int.Parse)
                        .ToList();

                    graph[node] = children;
                }
            }

            var pathsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < pathsCount; i++)
            {
                var path = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();


                var startPathIndex = 0;
                var starNode = path[0];

                visited = new bool[nodes];
                DFS(starNode, startPathIndex, path);

                if (PathExists(path, visited))
                {
                    Console.WriteLine("yes");
                }
                else
                {
                    Console.WriteLine("no");
                }

            }
        }

        private static bool PathExists(int[] path, bool[] visited)
        {
            foreach (var node in path)
            {
                if (!visited[node])
                {
                    return false;
                }
            }

            return true;
        }

        private static void DFS(int node, int pathIdx, int[] path)
        {
            if (visited[node] ||
                pathIdx >= path.Length ||
                node != path[pathIdx])
            {
                return;   
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child, pathIdx + 1, path);
            }
        }
    }
}
