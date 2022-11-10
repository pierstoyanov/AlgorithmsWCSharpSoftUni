using System;
using System.Collections.Generic;
using System.Linq;


public class BellmanFord
{
    public class Program
    {
        public class Edge
        {
            public int From { get; set; }
            public int To { get; set; }
            public int Weight { get; set; }
        }

        public static void Main()
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            var graph = new List<Edge>();
            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine().Split().Select(int.Parse).ToArray();

                graph.Add(new Edge { 
                    From = edgeData[0],
                    To = edgeData[1],
                    Weight = edgeData[2]
                });

            }

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());
            // distance arr
            var distance = new double[nodes + 1];
            Array.Fill(distance, double.PositiveInfinity);
            distance[source] = 0;
            // path arr
            var prev = new int[nodes + 1];
            Array.Fill(prev, -1);

            for (int i = 0; i < nodes - 1; i++)
            {
                var updated = false; 
                foreach (var edge in graph)
                {
                    if (double.IsPositiveInfinity(distance[edge.From]))
                    {
                        continue;
                    }

                    var newDistance = distance[edge.From] + edge.Weight;

                    if (newDistance < distance[edge.To])
                    {
                        distance[edge.To] = newDistance;
                        prev[edge.To] = edge.From;
                        updated = true;
                    }
                }

                if (!updated)
                {
                    break;
                }
            }

            foreach (var edge in graph)
            {   
                // при повтарянето на foreach,
                // ако има по-малка дистанция от намерените,
                // значи попада в негативен цикъл
                var newDistance = distance[edge.From] + edge.Weight;

                if (newDistance < distance[edge.To])
                {
                    Console.WriteLine("Negative Cycle Detected");
                    return;
                }
            }
            
            PrintPath(prev, destination);
            Console.WriteLine(distance[destination]);
        }

        private static void PrintPath(int[] prev, int destination)
        {
            var path = new Stack<int>();
            var node = destination;
            while (node != -1)
            {
                path.Push(node);
                node = prev[node];
            }

            Console.WriteLine(string.Join(" ", path));
        }
    }
}
