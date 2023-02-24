using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.Exercise_Graphs_Strongly_Connected_Components_Max_Flow
{
    internal class MaximumTasksAssignment
    {
        private static bool[,] graph;
        private static int[] parent;
        static void Main(string[] args)
        {
            var people = int.Parse(Console.ReadLine());
            var tasks = int.Parse(Console.ReadLine());

            var nodes = people + tasks + 2;
            graph = new bool[nodes, nodes];

            // connect origin of bipartitie matrix to people
            for (int person = 1; person <= people; person++)
            {
                graph[0, person] = true;
            }

            // connect end of bipartitie matrix to task
            for (int task = people + 1; task <= people + tasks; task++)
            {
                graph[task, nodes - 1] = true;
            }

            // read graph
            for (int person = 1; person <= people; person++)
            {
                var line = Console.ReadLine();
                for (int task = 0; task < line.Length; task++)
                {
                    if (line[task] == 'Y')
                    {
                        graph[person, people + task + 1] = true;
                    }
                }
            }

            // print graph
            /*            for (int row = 0; row < graph.GetLength(0); row++)
                        {
                            for (int col = 0; col < graph.GetLength(1); col++)
                            {
                                Console.Write($"{(graph[row, col] ? 'Y' : 'N')} ");
                            }

                            Console.WriteLine();
                        }*/


            var source = 0;
            var target = nodes - 1;

            parent = new int[nodes];
            Array.Fill(parent, -1);

            while (BFS(source, target))
            {
                var node = target;

                while (parent[node] != -1)
                {
                    var prev = parent[node];
                    graph[prev, node] = false;
                    graph[node, prev] = true;

                    node = prev;
                }
            }

            /*
                        for (int row = 0; row < graph.GetLength(0); row++)
                        {
                            for (int col = 0; col < graph.GetLength(1); col++)
                            {
                                var x = graph[row, col] ? "Y" : "N";
                                Console.Write($"{x} ");
                            }

                            Console.WriteLine();
                        }*/

            for (int task = people + 1; task <= people + tasks; task++)
            {
                for (int i = 0; i < graph.GetLength(1); i++)
                {
                    if (graph[task, i])
                    {
                        Console.WriteLine($"{(char)(64 + i)}-{task - people}");
                    }
                }
            }
        }

       

        private static bool BFS(int source, int target)
        {
            var visited = new bool[graph.GetLength(0)];
            var queue = new Queue<int>();

            visited[source] = true;
            queue.Enqueue(source);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();

                for (int child = 0; child < graph.GetLength(1); child++)
                {
                    // if child is not visited &
                    // there is an edge between node and child
                    if (!visited[child] &&
                        graph[node, child])
                    {
                        parent[child] = node;
                        visited[child] = true;
                        queue.Enqueue(child);
                    }
                }
            }

            return visited[target];
        }
    }
}
