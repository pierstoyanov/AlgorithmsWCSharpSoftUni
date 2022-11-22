using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;


namespace _03.Ex_Bellman_Ford_Longest_Path_in_DAG
{
    public class CableNetwork
    {
        public class Edge
        {
            public int First { get; set; }
            public int Second { get; set; }
            public int Price { get; set; }
            public bool IsConnected { get; set; }
        }

        private static int budget;
        private static Dictionary<int, List<Edge>> nodeEdges;
        private static HashSet<int> connectedNodes;
        private static List<Edge> forest;
        private static List<Edge> edges;
        private static int[] parent;

        static void Main(string[] args)
        {
            budget = int.Parse(Console.ReadLine());
            var nodes = int.Parse(Console.ReadLine());
            var edgesNumber = int.Parse(Console.ReadLine());

            nodeEdges = new Dictionary<int, List<Edge>>();
            connectedNodes = new HashSet<int>();
            forest = new List<Edge>();
            edges = new List<Edge>();

            var maxNode = -1;

            for (int i = 0; i < edgesNumber; i++)
            {
                var edgeLine = Console.ReadLine().Split();
                var edgeData = edgeLine.Take(3).Select(int.Parse).ToArray();
                
                var edgeConnected = edgeLine.Last() == "connected" ? true : false;

                var firstNode = edgeData[0];
                var SecondNode = edgeData[1];
                var connectionPrice = edgeData[2];

                var edge = new Edge
                {
                    First = firstNode,
                    Second = SecondNode,
                    Price = connectionPrice,
                    IsConnected = edgeConnected
                };

                if (edgeConnected)
                {
                    forest.Add(edge);
                    connectedNodes.Add(firstNode);
                    connectedNodes.Add(SecondNode);
                }
                else
                {
                    edges.Add(edge);
                }

                maxNode = firstNode > maxNode ? firstNode : maxNode;
                maxNode = SecondNode > maxNode ? SecondNode : maxNode;


                if (!nodeEdges.ContainsKey(firstNode))
                {
                    nodeEdges.Add(firstNode, new List<Edge>());
                }

                if (!nodeEdges.ContainsKey(SecondNode))
                {
                    nodeEdges.Add(SecondNode, new List<Edge>());
                }

                nodeEdges[firstNode].Add(edge);
                nodeEdges[SecondNode].Add(edge);
            }


            // idx = node, value = current parent
            parent = new int[maxNode + 1];
            for (int node = 0; node < parent.Length; node++)
            {
                parent[node] = node;
            }

            var sortedEdges = edges.OrderBy(e => e.Price).ToArray();
            var usedBudget = 0;

            foreach (var edge in sortedEdges)
            {
                var firstNodeRoot = FindRoot(edge.First);
                var secondNodeRoot = FindRoot(edge.Second);
             
                // conditions to not evaluate the edge - 1. both nodes are coneccted
                // Not (first parent conected XOR second parent conected)
                if (firstNodeRoot == secondNodeRoot || 
                    !(connectedNodes.Contains(firstNodeRoot) ^ connectedNodes.Contains(secondNodeRoot)))
                {
                    continue;
                }

                if (budget <= usedBudget + edge.Price)
                {
                    break;
                }
                usedBudget += edge.Price;

                parent[firstNodeRoot] = secondNodeRoot;
                forest.Add(edge);
            }

            Console.WriteLine($"Budget used: {usedBudget}");
        }

        private static int FindRoot(int node)
        {
            // walk the parent arr until node is its own parent/is Root
            while (node != parent[node])
            {
                node = parent[node];
            }

            return node;
        }
    }
}
