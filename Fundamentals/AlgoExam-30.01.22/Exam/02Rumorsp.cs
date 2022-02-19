using System;
using System.Linq;

class Rumors
{
    private static char[] elements;
    private static int k;
    private static int[,] graph;

    public static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        var e = int.Parse(Console.ReadLine());

        for (int i = 0; i <= e; i++)
        {
            var line = Console.ReadLine();

            for (int col = 0; col < 2; col++)
            {
                graph[i, col] = line[col];
            }
        }
    }


}