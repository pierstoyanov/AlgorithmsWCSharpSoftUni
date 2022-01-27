using System;
using System.Collections.Generic;

class PermutationsWithRepetition
{
    private static string[] elements;

    public static void Main(string[] args)
    {
        elements = Console.ReadLine().Split();
        Permute(0);
    }

    public static void Permute(int index)
    {
        if (index >= elements.Length)
        {
            Console.WriteLine(string.Join(" ", elements));
            return;
        }

        Permute(index + 1);
        var used = new HashSet<string> { elements[index] };

        for (int i = index + 1; i < elements.Length; i++)
        {
            if (!used.Contains(elements[i]))
            {
                Swap(index, i);
                Permute(index + 1);
                Swap(index, i);
                used.Add(elements[i]);
            }
        }
    }

    private static void Swap(int v1, int v2)
    {
        var temp = elements[v1];
        elements[v1] = elements[v2];
        elements[v2] = temp;
    }
}