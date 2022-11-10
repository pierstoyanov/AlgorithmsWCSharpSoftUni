using System;
using System.Collections.Generic;
using System.Linq;

public class PrimAlgorithm
{
    public class CustomPriorityQueue<T>
    {
        private List<(T element, int priority)> heap;

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
            return 2 * idx + 2;
        }

        public void Enqueue(T element, int priority)
        {
            var idx = Count;
            heap.Add((element, priority));

            while (idx != 0 &&
                heap[idx].priority < heap[Parent(idx)].priority)
            {
                Swap(idx, Parent(idx));
                idx = Parent(idx);
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

            Heapify(0);

            return root.element;
        }

        private void Heapify(int idx)
        {
            int left = Left(idx);
            int right = Right(idx);
            int smallest = idx;

            if (left < Count &&
                heap[left].priority < heap[smallest].priority)
            {
                smallest = left;
            }

            if (right < Count &&
                heap[right].priority < heap[smallest].priority)
            {
                smallest = right;
            }

            if (smallest != idx)
            {
                Swap(idx, smallest);
                Heapify(smallest);
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

            (T, int) temp = heap[indexOne];
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

        public bool checkMinHeap()
        {
            if (heap.Count <= 1)
            {
                return true;
            }

            for (int i = 0; i <= (heap.Count - 2) / 2; i++)
            {
                // check if node has lower priority than left child
                if (heap[i].priority > heap[Left(i)].priority)
                {
                    return false;
                }

                // check if node has lower priority than right child and right child exists
                if (Right(i) != heap.Count &&
                    heap[i].priority > heap[Right(i)].priority)
                {
                    return false;
                }
            }

            return true;
        }
    }
    public class Edge
    {
        public int First { get; set; }
        public int Second { get; set; }
        public int Weight { get; set; }
    }

    // Data structures
    private static Dictionary<int, List<Edge>> graph;
    private static HashSet<int> forestNodes;
    private static List<Edge> forestEdges;

    public static void Main(string[] args)
    {
        graph = new Dictionary<int, List<Edge>>();
        forestNodes = new HashSet<int>();
        forestEdges = new List<Edge>();

        var edges = int.Parse(Console.ReadLine());

        for (int i = 0; i < edges; i++)
        {
            var edgeData = Console.ReadLine()
                .Split(new []{", "}, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var firstNode = edgeData[0];
            var secondNode = edgeData[1];

            if (!graph.ContainsKey(firstNode))
            {
                graph.Add(firstNode, new List<Edge>());
            }

            if (!graph.ContainsKey(secondNode))
            {
                graph.Add(secondNode, new List<Edge>());
            }

            var edge = new Edge
            {
                First = firstNode,
                Second = secondNode,
                Weight = edgeData[2]
            };


            graph[firstNode].Add(edge);
            graph[secondNode].Add(edge);
        }

        foreach (var node in graph.Keys)
        {
            if (!forestNodes.Contains(node))
            {
                Prim(node);
            }
        }

        foreach (var edge in forestEdges)
        {
            Console.WriteLine($"{edge.First} - {edge.Second}");
        }
    }

    private static void Prim(int startingNode)
    {
        forestNodes.Add(startingNode);

        var pq = new CustomPriorityQueue<Edge>();

        // add all edges of starting node to PQ
        foreach (var edge in graph[startingNode])
        {
            pq.Enqueue(edge, edge.Weight);
        }

        while (pq.Count > 0)
        {
            var minEdge = pq.Dequeue();

            var nonTreeNode = -1;

            if (forestNodes.Contains(minEdge.First) &&
                !forestNodes.Contains(minEdge.Second))
            {
                nonTreeNode = minEdge.Second;
            }

            if (!forestNodes.Contains(minEdge.First) &&
                forestNodes.Contains(minEdge.Second))
            {
                nonTreeNode = minEdge.First;
            }

            if (nonTreeNode == -1)
            {
                continue;
            }

            forestNodes.Add(nonTreeNode);
            forestEdges.Add(minEdge);
            foreach (var node in graph[nonTreeNode])
            {
                pq.Enqueue(node, node.Weight);
            }
        }
    }
}
