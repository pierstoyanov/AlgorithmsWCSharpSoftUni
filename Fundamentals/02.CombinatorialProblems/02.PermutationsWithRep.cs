using System;
using System.Collections.Generic;

class PermutationsWithRep
{
    private static string[] elements;
    private static HashSet<string> permutations;

    public static void Main(string[] args)
    {
        elements = Console.ReadLine().Split();
        permutations = new HashSet<string>();

        Permute(0);

        Console.WriteLine(string.Join(Environment.NewLine, permutations));
    }

    public static void Permute(int index)
    {
        if (index >= elements.Length)
        {
            permutations.Add(string.Join(" ", elements));
            return;
        }

        Permute(index + 1);

        for (int i = index + 1; i < elements.Length; i++)
        {
            Swap(index, i);
            Permute(index + 1);
            Swap(index, i);
        }
    }

    private static void Swap(int v1, int v2)
    {
        var temp = elements[v1];

        elements[v1] = elements[v2];
        elements[v2] = temp;
    }
}