//line n = node number, line = list of children

private static List<int>[] graph;

static void Main (string[] args)
{
    var n = int.Parse(Console.ReadLine());
    graph = new List<int>[n];

    for (int node = 0; node < n; node++)
    {
        var line = Console.ReadLine();

        if (string.IsNullOrEmpty(line))
        {
            graph[node] = new List<int>();
        }
        else
        {
            var children = line.Split()
                    .Select(int.Parse)
                    .ToList();

            graph[node] = children;
        }
    }
}