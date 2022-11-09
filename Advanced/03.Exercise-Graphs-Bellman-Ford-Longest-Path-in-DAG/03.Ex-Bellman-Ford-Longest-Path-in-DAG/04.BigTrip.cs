using System;
using System.Collections.Generic;
using System.Linq;


namespace _03.Ex_Bellman_Ford_Longest_Path_in_DAG
{
    public static class BigTrip
    {
        private class Edge 
        {
            public int Source { get; set; }
            public int Destination { get; set; }
            public int Time { get; set; }
        }

        private static Dictionary<int, List<Edge>> nodeEdges;
        private static double[] distance;
        private static int[] previous;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            int e = int.Parse(Console.ReadLine());

            nodeEdges = new Dictionary<int, List<Edge>>();
            for (int i = 0; i < e; i++)
            {
                var edgeData = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var source = edgeData[0];
                var destination = edgeData[1];
                var time = edgeData[2];

                if (!nodeEdges.ContainsKey(source))
                {
                    nodeEdges.Add(source, new List<Edge>());
                }

                if (!nodeEdges.ContainsKey(destination))
                {
                    nodeEdges.Add(destination, new List<Edge>());
                }

                nodeEdges[source].Add(new Edge 
                {
                    Source = source,
                    Destination = destination,
                    Time = time
                });

            }

            var targetSource = int.Parse(Console.ReadLine());
            int targetDestination = int.Parse(Console.ReadLine());

            distance = new double[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                distance[i] = double.NegativeInfinity;
            }
            distance[targetSource] = 0;

            previous = new int[n + 1];
            for (int i = 0; i < n + 1; i++)
            {
                previous[i] = -1;
            }


            var sortedNodes = TopologicalDFS();

            while (sortedNodes.Count > 0)
            {
                var node = sortedNodes.Pop();

                foreach (var edge in nodeEdges[node])
                 {
                    var newTime = distance[edge.Source] + edge.Time;

                    if (newTime > distance[edge.Destination])
                    {
                        distance[edge.Destination] = newTime;
                        previous[edge.Destination] = edge.Source;
                    }
                }
            }


            Console.WriteLine(distance[targetDestination]);
            PrintPath(previous, targetDestination);
        }

        private static void PrintPath(int[] previous, int targetDestination)
        {
            var path = new Stack<int>();
            var node = targetDestination;
            while (node != -1)
            {
                path.Push(node);
                node = previous[node];
            }

            Console.WriteLine(string.Join(" ", path));
        }

        private static Stack<int> TopologicalDFS()
        {
            var result = new Stack<int>();
            var visited = new HashSet<int>();

            foreach (var node in nodeEdges.Keys)
            {
                DFS(node, visited, result);
            }

            return result;
        }

        private static void DFS(int node, HashSet<int> visited, Stack<int> result)
        {
            if (visited.Contains(node))
            {
                return;
            }

            visited.Add(node);

            foreach (var edge in nodeEdges[node])
            {
                DFS(edge.Destination, visited, result);
            }

            result.Push(node);
        }
    }
}
