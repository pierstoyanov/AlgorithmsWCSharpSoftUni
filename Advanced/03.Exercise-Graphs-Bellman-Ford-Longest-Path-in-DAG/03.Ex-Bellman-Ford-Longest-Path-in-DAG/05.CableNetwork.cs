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
        private static Dictionary<int, List<Edge>> connectedNodes;


        static void Main(string[] args)
        {
            budget = int.Parse(Console.ReadLine());
            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());

            nodeEdges = new Dictionary<int, List<Edge>>();
            for (int i = 0; i < edges; i++)
            {
                var edgeLine = Console.ReadLine().Split();
                var edgeData = edgeLine.Select(int.Parse).ToArray();
                var edgeType = edgeLine.Last() == "connected" ? true : false;

                var firstNode = edgeData[0];
                var SecondNode = edgeData[1];

                var edge = new Edge
                {
                    First = firstNode,
                    Second = SecondNode,
                    Price = edgeData[2],
                    IsConnected = edgeType
                };

                var connectionPrice = edgeData[2];

                if (!nodeEdges.ContainsKey(firstNode))
                {
                    nodeEdges.Add(firstNode, new List<Edge>());
                }

                if (!nodeEdges.ContainsKey(SecondNode))
                {
                    nodeEdges.Add(SecondNode, new List<Edge>());
                }

                nodeEdges[source].Add(new Edge
                {
                    Source = source,
                    Destination = destination,
                    Time = time
                });

            }
        }
    }
}
