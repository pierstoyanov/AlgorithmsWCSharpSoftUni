// first line - n of nodes, second - n of edges, 2-int(second) edges (destination - source)

private static List<int>[] graph;

static void Main(string[] args)
{
    var n = int.Parse(Console.ReadLine());
    var edges = int.Parse(Console.ReadLine());

    graph = new List<int>[n + 1];
    //avoid null refference exception
    for (int node = 0; node < graph.Length; node++)
    {
        graph[node] = new List<int>();
    }

    for (int i = 0; i < edges; i++)
    {
        var edge = Console.ReadLine()
        .Split()
        .Select(int.Parse)
        .ToArray();

        var firstNode = edge[0];
        var secondNode = edge[1];

        graph[firstNode].Add(secondNode);
        graph[secondNode].Add(firstNode);
    }
}
