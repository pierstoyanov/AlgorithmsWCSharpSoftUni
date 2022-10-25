using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class DijkstraGraphSearch
{
    public class Edge 
    {
        public int FirstNode { get; set; }
        public int SecondNode { get; set; }
        public int Weight { get; set; }
    }

    private static Dictionary<int, List<Edge>> edgesByNode;
    private static double[] distance;
    private static int[] parent;

    static void Main(string[] args)
    {
        edgesByNode = new Dictionary<int, List<Edge>>();
        // read graph & fill edgesByNode collection - int node: list[edges...]
        var edgesCount = int.Parse(Console.ReadLine());
        
        for (int i = 0; i < edgesCount; i++)
        {
            var edgeArgs = Console.ReadLine().Split(", ").Select(int.Parse).ToArray();

            var firstNode = edgeArgs[0];
            var secondNode = edgeArgs[1];

            var edge = new Edge
            {
                FirstNode = firstNode,
                SecondNode = secondNode,
                Weight = edgeArgs[2]
            };

            // add nodes to dictionary if they don't exist
            if (!edgesByNode.ContainsKey(firstNode))
            {
                edgesByNode.Add(firstNode, new List<Edge>());
            }

            if (!edgesByNode.ContainsKey(secondNode))
            {
                edgesByNode.Add(secondNode, new List<Edge>());
            }
            // add edge to nodes
            edgesByNode[firstNode].Add(edge);
            edgesByNode[secondNode].Add(edge);
        }

        // create distance arr
        var biggestNode = edgesByNode.Keys.Max();
        distance = new double[biggestNode + 1];
        for (int node = 0; node <= biggestNode; node++)
        {
            distance[node] = double.PositiveInfinity;
        }

        parent = new int[biggestNode + 1];
        Array.Fill(parent, -1);


        var startNode = int.Parse(Console.ReadLine());
        var endNode = int.Parse(Console.ReadLine());
        // also use distance as visited arr
        distance[startNode] = 0;
        // distance is the priority, start node - 0
        var pq = new PriorityQueue<int, int>();
        //(Comparer<int>.Create((f, s) => (int) (distance[f] - distance[s])));
        pq.Enqueue(startNode, (int)distance[startNode]);

        while (pq.Count > 0)
        {
            var minNode = pq.Dequeue();

            if (double.IsPositiveInfinity(minNode))
            {
                break;
            }

            if (minNode == endNode)
            {
                break;
            }

            foreach (var edge in edgesByNode[minNode])
            {
                // get other node in the Edge, that is not min node
                var otherNode = edge.FirstNode == minNode ? edge.SecondNode : edge.FirstNode;

                // new distance from start to current Edge
                var newDistance = distance[minNode] + edge.Weight;

                if (newDistance < distance[otherNode])
                {
                    parent[otherNode] = minNode;

                    // update distance arr
                    distance[otherNode] = newDistance;
                    pq.Enqueue(otherNode, (int)distance[otherNode]);
                }
               /* // update distance arr
                distance[otherNode] = Math.Min(distance[otherNode], newDistance);
*/
            }
        }

        Console.WriteLine(distance[endNode]);

        var currentNode = endNode;
        var path = new List<int>();
        while (currentNode != -1)
        {
            path.Add(currentNode);
            currentNode = parent[currentNode];
        }

        Console.WriteLine(string.Join(' ', path));
    }
}