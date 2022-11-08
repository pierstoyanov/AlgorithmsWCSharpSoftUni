using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Ex_Bellman_Ford_Longest_Path_in_DAG
{
    internal class Program
    {
        public class MaxPriorityQueue<T>
        {
            private List<(T element, double priority)> heap;

            public MaxPriorityQueue()
            {
                heap = new List<(T, double)>();
            }

            public MaxPriorityQueue(T element, double priority)
            {
                heap = new List<(T, double)>();
                Enqueue(element, priority);
            }

            public int Count
            {
                get { return heap.Count; }
            }

            private int Parent(int idx)
            {
                return (idx - 1) / 2;
            }

            private int Left(int idx)
            {
                return 2 * idx + 1;
            }

            private int Right(int idx)
            {
                return (2 * idx) + 2;
            }

            public void Enqueue(T element, double priority)
            {
                var currentIdx = Count;
                heap.Add((element, priority));

                while (currentIdx != 0 &&
                    heap[currentIdx].priority > heap[Parent(currentIdx)].priority)
                {
                    Swap(currentIdx, Parent(currentIdx));
                    currentIdx = Parent(currentIdx);
                }
            }

            public T Dequeue()
            {
                ValidateNotEmpty();

                if (Count == 1)
                {
                    var result = heap[0];
                    heap.RemoveAt(0);
                    return result.element;
                }

                var root = heap[0];

                heap[0] = heap[Count - 1];
                heap.RemoveAt(Count - 1);

                HeapifyDown(0);

                return root.element;
            }

            private void HeapifyDown(int idx)
            {
                int left = Left(idx);
                int right = Right(idx);
                int biggest = idx;

                if (left < Count && heap[left].priority > heap[biggest].priority)
                {
                    biggest = left;
                }

                if (right < Count && heap[right].priority > heap[biggest].priority)
                {
                    biggest = right;
                }

                if (biggest != idx)
                {
                    Swap(idx, biggest);
                    HeapifyDown(biggest);
                }
            }

            public T Peek()
            {
                ValidateNotEmpty();
                return heap[0].element;
            }

            private void Swap(int indexOne, int indexTwo)
            {
                ValidateIndex(indexOne, indexTwo);

                (T, double) temp = heap[indexOne];
                heap[indexOne] = heap[indexTwo];
                heap[indexTwo] = temp;
            }

            private void ValidateNotEmpty()
            {
                if (heap.Count == 0)
                    throw new InvalidOperationException("Queue is empty!");
            }

            private void ValidateIndex(params int[] indexes)
            {
                foreach (int index in indexes)
                {
                    if (index < 0 || index > heap.Count - 1)
                        throw new InvalidOperationException();
                }
            }

            public bool checkMaxHeap()
            {
                if (heap.Count <= 1)
                {
                    return true;
                }

                for (int i = 0; i <= (heap.Count - 2) / 2; i++)
                {
                    // check if node has higher priority than left child
                    if (heap[i].priority < heap[Left(i)].priority)
                    {
                        return false;
                    }

                    // check if node has higher priority than right child and right child exists
                    if (Right(i) != heap.Count &&
                        heap[i].priority < heap[Right(i)].priority)
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public class Edge
        {
            public int FirstNode { get; set; }
            public int SecondNode { get; set; }
            public double ReliabilityPercentage { get; set; }
                
        }

        // Data structures
        private static Dictionary<int, List<Edge>> edgesByNode;
        private static double[] distance;
        private static int[] parent;

        static void Main(string[] args)
        {
            edgesByNode = new Dictionary<int, List<Edge>>();

            var nodes = int.Parse(Console.ReadLine());
            var edges = int.Parse(Console.ReadLine());
            // Read edges
            for (int i = 0; i < edges; i++)
            {
                var edgeData = Console.ReadLine().Split().Select(int.Parse).ToArray();

                var newEdge = new Edge
                { 
                    FirstNode = edgeData[0],
                    SecondNode = edgeData[1],
                    ReliabilityPercentage = edgeData[2] / 100.00
                };

                if (!edgesByNode.ContainsKey(newEdge.FirstNode))
                {
                    edgesByNode.Add(newEdge.FirstNode, new List<Edge>());
                }
                
                if (!edgesByNode.ContainsKey(newEdge.SecondNode))
                {
                    edgesByNode.Add(newEdge.SecondNode, new List<Edge>());
                }

                edgesByNode[newEdge.FirstNode].Add(newEdge);
                edgesByNode[newEdge.SecondNode].Add(newEdge);
            }

            // create distance array
            var bigestNode = edgesByNode.Keys.Max();
            distance = new double[bigestNode + 1];
            for (int node = 0; node < bigestNode; node++)
            {
                distance[node] = double.NegativeInfinity;
            }

            // parent array
            parent = new int[bigestNode + 1];
            //Array.Fill(parent, -1);
            for (var i = 0; i <= bigestNode; i++)
            {
                parent[i] = -1;
            }

            var startNode = int.Parse(Console.ReadLine());
            var endNode = int.Parse(Console.ReadLine());
            distance[startNode] = 1;
            
            var pq = new MaxPriorityQueue<int>();
            pq.Enqueue(startNode, (int)distance[startNode]);

            while (pq.Count > 0)
            {
                var mostReliableNode = pq.Dequeue();
                // exit visited
                if (double.IsNegativeInfinity(distance[mostReliableNode]))
                {
                    break;
                }
                // exit target
                if (mostReliableNode == endNode)
                {
                    break;
                }

                foreach (var edge in edgesByNode[mostReliableNode])
                {
                    var otherNode = edge.FirstNode == mostReliableNode ? edge.SecondNode : edge.FirstNode;
                    var currentDistance = distance[mostReliableNode] != double.NegativeInfinity ? distance[mostReliableNode] : 1;
                    var newDistance = currentDistance * edge.ReliabilityPercentage;

                    if (newDistance > distance[otherNode] || mostReliableNode == startNode)
                    {
                        parent[otherNode] = mostReliableNode;

                        distance[otherNode] = newDistance;
                        pq.Enqueue(otherNode, distance[otherNode]);
                    }
                }
            }

            if (double.IsNegativeInfinity(distance[endNode]))
            {
                Console.WriteLine("No such path exists");
            }
            else
            {
                Console.WriteLine($"Most reliable path reliability: {distance[endNode]*100:F2}%");

                PrintPath(endNode);
            }            
        }

        private static void PrintPath(int endNode)
        {
            var path = new Stack<int>();
            var curentNode = endNode;
            while (curentNode != -1)
            {
                path.Push(curentNode);
                curentNode = parent[curentNode];
            }

            Console.WriteLine(string.Join(" -> ", path));
        }
    }
}
