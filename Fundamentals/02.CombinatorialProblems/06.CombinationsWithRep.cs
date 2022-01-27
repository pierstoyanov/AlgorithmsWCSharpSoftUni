using System;

class CombinationsWithRep
{
    private static string[] elements;
    private static int k;
    private static string[] combinations;


    public static void Main(string[] args)
    {
        elements = Console.ReadLine().Split();
        k = int.Parse(Console.ReadLine());
        combinations = new string[k];

        GenerateCombinations(0, 0);
    }

    private static void GenerateCombinations(int idx, int elementsStartIdx)
    {
        if (idx >= combinations.Length)
        {
            Console.WriteLine(string.Join(" ", combinations));
            return;
        }

        for (int i = elementsStartIdx; i < elements.Length; i++)
        { 
            combinations[idx] = elements[i];
            //i - take current element when combining
            GenerateCombinations(idx + 1, i);
        }
    }
}