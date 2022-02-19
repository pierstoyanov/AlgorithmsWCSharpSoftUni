using System;
using System.Linq;

class StringMashup
{
    private static char[] elements;
    private static int k;
    private static char[] combinations;

    public static void Main(string[] args)
    {
        var input = Console.ReadLine().ToCharArray();
        Array.Sort(input);
        elements = input;

        //elements = new string(input.OrderBy(c => c).ToArray()).Split();

        k = int.Parse(Console.ReadLine());
        combinations = new char[k];

        GenerateCombinations(0, 0);
    }

    private static void GenerateCombinations(int idx, int elementsStartIdx)
    {
        if (idx >= combinations.Length)
        {
            Console.WriteLine(string.Join("", combinations));
            return;
        }

        for (int i = elementsStartIdx; i < elements.Length; i++)
        {
            combinations[idx] = elements[i];
            //i+1 use all other but current elem
            GenerateCombinations(idx + 1, i);
        }
    }
}