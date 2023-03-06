using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.Exercise_Graphs_Strongly_Connected_Components_Max_Flow
{
    internal class BiConnectedComponents
    {
        private static List<int>[] graph;
        private static int[] depth;
        private static int[] lowPoint;
        private static bool[] visited;
        private static int[] parent;

        private static Stack<int> stack;

        private static List<HashSet<int>> components;

        static void Main(string[] args)
        {
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());
            // init collections
            graph = new List<int>[nodes];
            depth = new int[nodes];
            lowPoint = new int[nodes];
            visited = new bool[nodes];
            parent = new int[nodes];

            stack = new Stack<int>();
            components = new List<HashSet<int>>();

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<int>(); 
                parent[node] = - 1;
            }
            // read graph;
            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var firstNode = edgeData[0];
                var secondNode = edgeData[1];

                graph[firstNode].Add(secondNode);
                graph[secondNode].Add(firstNode);
            }

            Console.Clear();

            for (int node = 0; node < graph.Length; node++)
            {
                if (visited[node]) 
                { 
                    continue; 
                }

                FindArticulationPoint(node, 1);

                var lastComponent = stack.ToHashSet();
                // Console.WriteLine(string.Join(' ', lastComponent));
                
                components.Add(lastComponent);
            }

            Console.WriteLine($"Number of bi-connected components: {components.Count}");
        }

        private static void FindArticulationPoint(int node, int currentDepth)
        {
            visited[node] = true;
            depth[node] = currentDepth;
            // assume lowPoint is same as depth, update later
            lowPoint[node] = currentDepth;

            var isArticulationPoint = false;
            var childCount = 0;

            foreach (var child in graph[node])
            {
                // child has not been visited
                if (!visited[child])
                {
                    stack.Push(node);
                    stack.Push(child);

                    parent[child] = node;

                    FindArticulationPoint(child, currentDepth + 1);
                    
                    childCount += 1;
                    /*// check if art. point
                    if (lowPoint[child] >= depth[node])
                    {
                        isArticulationPoint = true;
                    }*/


                    if (parent[node] != -1 && lowPoint[child] >= depth[node] ||
                        parent[node] == -1 && childCount > 1)
                    {
                        var component = new HashSet<int>();

                        while (true)
                        {
                            var stackChild = stack.Pop();
                            var stackNode = stack.Pop();

                            component.Add(stackNode);
                            component.Add(stackChild);

                            if (stackNode == node && 
                                stackChild == child)
                            {
                                break;
                            }
                        }

                        // Console.WriteLine(string.Join(' ', component));
                        components.Add(component);
                    }

                    // set low point
                    lowPoint[node] = Math.Min(lowPoint[node], lowPoint[child]);
                }
                else if (parent[node] != child  &&
                    depth[child] < lowPoint[node])
                {
                    lowPoint[node] = depth[child];

                    stack.Push(node);
                    stack.Push(child);
                }
            }


        }
    }
}
