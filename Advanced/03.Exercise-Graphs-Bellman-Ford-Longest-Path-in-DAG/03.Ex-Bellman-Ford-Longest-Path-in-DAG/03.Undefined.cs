using System;
using System.Collections.Generic;
using System.Linq;


namespace _03.Ex_Bellman_Ford_Longest_Path_in_DAG
{
    public class Undefined
    {
        public class Edge
        {
            public int To { get; set; }
            public int From { get; set; }
            public int Weight { get; set; }
        }

        // Структури от данни
        private static List<Edge> graph = new List<Edge>();
        private static double[] distance;
        private static int[] previous;

        public static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine().Split().Select(int.Parse).ToArray();

                graph.Add(new Edge
                {
                    From = edgeData[0],
                    To = edgeData[1],
                    Weight = edgeData[2]
                });
            }

            var source = int.Parse(Console.ReadLine());
            var destination = int.Parse(Console.ReadLine());

            // масив за дистанциите
            distance = new double[nodes + 1];
            /*Array.Fill(distance, double.PositiveInfinity);*/

            // масив за пътя
            previous = new int[nodes + 1];
            /*Array.Fill(previous, -1);*/

            for (int i = 0; i < nodes + 1; i++)
            {
                distance[i] = double.PositiveInfinity;
                previous[i] = -1;
            }

            distance[source] = 0;

            for (int i = 0; i < nodes - 2; i++)
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
                        previous[edge.To] = edge.From;
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
                    Console.WriteLine("Undefined");
                    return;
                }
            }

            PrintPath(previous, destination);
            Console.WriteLine(distance[destination]);
        }

        private static void PrintPath(int[] previous, int destination)
        {
            var path = new Stack<int>();
            var node = destination;
            while (node != -1)
            {
                path.Push(node);
                node = previous[node];
            }

            Console.WriteLine(string.Join(" ", path));
        }
    }
}
