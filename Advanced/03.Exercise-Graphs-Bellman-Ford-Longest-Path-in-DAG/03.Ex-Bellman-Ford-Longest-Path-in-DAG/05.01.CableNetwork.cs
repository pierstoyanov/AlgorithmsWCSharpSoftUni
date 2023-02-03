using System;
using System.Collections.Generic;


namespace _03.Ex_Bellman_Ford_Longest_Path_in_DAG
{
    public class MinPriorityQueue<T>
    {
        private List<(T element, int priority)> heap;

        public MinPriorityQueue()
        {
            heap = new List<(T, int)>();
        }

        public MinPriorityQueue(T element, int priority)
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

    public class CableNetwork2
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
        private static HashSet<int> spanningTree;
        private static List<Edge> forest;
        private static List<Edge> edges;
        private static int[] parent;

        static void Main(string[] args)
        {
            budget = int.Parse(Console.ReadLine());
            var nodes = int.Parse(Console.ReadLine());
            var edgesNumber = int.Parse(Console.ReadLine());

            var graph = new List<Edge>[nodes];
            spanningTree= new HashSet<int>();

            for (int node = 0; node < graph.Length; node++)
            {
                graph[node] = new List<Edge>();
            }


            for (int i = 0; i < edgesNumber; i++)
            {
                var edgeData = Console.ReadLine().Split();

                var edge = new Edge 
                { 
                    First = int.Parse(edgeData[0]),
                    Second = int.Parse(edgeData[1]),
                    Price = int.Parse(edgeData[2])
                };

                graph[edge.First].Add(edge);
                graph[edge.Second].Add(edge);


                if (edgeData.Length == 4)
                {
                    spanningTree.Add(edge.First);
                    spanningTree.Add(edge.Second);
                }
            }

            Console.WriteLine($"Budget used: {Prim(graph, spanningTree, budget)}");
        }

        private static int Prim(List<Edge>[] graph, HashSet<int> spanningTree, int budget)
        {
            var pq = new MinPriorityQueue<Edge>();

            var usedBudget = 0;

            foreach (var node in spanningTree)
            {
                foreach (var i  in graph[node])
                {
                    pq.Enqueue(i, i.Price);
                }
            }

            while (pq.Count > 0)
            {
                var minEdge = pq.Dequeue();
                
                // check if edge is not in the tree
                var nonTreeNode = -1;
                
                if (spanningTree.Contains(minEdge.First) &&
                    !spanningTree.Contains(minEdge.Second))
                {
                    nonTreeNode= minEdge.Second;
                }

                if (spanningTree.Contains(minEdge.Second) &&
                    !spanningTree.Contains(minEdge.First))
                {
                    nonTreeNode = minEdge.First;
                }

                if (nonTreeNode == - 1)
                {
                    continue;
                }

                // add node to tree
                spanningTree.Add(nonTreeNode);

                // add used edge price
                if (usedBudget + minEdge.Price >= budget)
                {
                    break;
                }

                usedBudget += minEdge.Price;

                foreach (var n  in graph[nonTreeNode])
                {
                    pq.Enqueue(n, n.Price);
                }
            }

            return usedBudget;
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
