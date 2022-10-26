using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

class DijkstraGraphSearchCustomPQ
{
    public class CustomPriorityQueue<T>
    {
        private List<(T, int)> heap;

        public CustomPriorityQueue()
        {
            heap = new List<(T, int)>();
        }

        public CustomPriorityQueue(T element, int priority)
        {
            heap = new List<(T, int)>();
            Enqueue(element, priority);
        }

        public int Count
        {
            get { return heap.Count; }
        }

        public void Enqueue(T element, int priority)
        {
            heap.Add((element, priority));
            Heapify(heap.Count - 1);
        }

        public T Dequeue()
        {
            ValidateNotEmpty();

            //take first element
            (T, int) result = heap[0];

            //swap first and last element & remove last
            Swap(0, Count - 1);
            heap.RemoveAt(Count - 1);

            HeapifyDown(0);

            return result.Item1;
        }

        private void Heapify(int index)
        {
            if (index == 0)
                return;

            int parentIndex = (index - 1) / 2;

            if (heap[index].Item2 < heap[parentIndex].Item2)
            {
                //heap[index], heap[parentIndex] = heap[parentIndex], heap[index];
                Swap(index, parentIndex);
                Heapify(parentIndex);
            }
        }

        private void HeapifyDown(int index)
        {
            int leftChildIndex = 2 * index + 1;
            int rightChildIndex = 2 * index + 2;
            int maxChildIndex = leftChildIndex;

            if (leftChildIndex >= heap.Count)
                return;

            if (rightChildIndex > heap.Count && heap[leftChildIndex].Item2 > heap[rightChildIndex].Item2)
            {
                maxChildIndex = rightChildIndex;
            }

            if (heap[index].Item2 > heap[maxChildIndex].Item2)
            {
                Swap(index, maxChildIndex);
                HeapifyDown(maxChildIndex);
            }
        }

        public T Peek()
        {
            ValidateNotEmpty();
            return heap[0].Item1;
        }

        private void Swap(int indexOne, int indexTwo)
        {
            ValidateIndex(indexOne, indexTwo);
            // Swap items at index One and index Two
            (T, int) temp = heap[indexOne];
            heap[indexOne] = heap[indexTwo];
            heap[indexTwo] = temp;
        }

        private void ValidateNotEmpty()
        {
            if (heap.Count == 0)
                throw new InvalidOperationException();
        }

        private void ValidateIndex(params int[] indexes)
        {
            foreach (int index in indexes)
            {
                if (index < 0 || index > heap.Count - 1)
                    throw new InvalidOperationException();
            }
        }
    }

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
        var pq = new CustomPriorityQueue<int>();
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
            }
        }

        if (double.IsPositiveInfinity(distance[endNode]))
        {
            Console.WriteLine("There is no such path.");
        }
        else
        {
            Console.WriteLine(distance[endNode]);

            var currentNode = endNode;
            var path = new List<int>();
            while (currentNode != -1)
            {
                path.Add(currentNode);
                currentNode = parent[currentNode];
            }

            path.Reverse();
            Console.WriteLine(string.Join(' ', path));
        }
    }
}
