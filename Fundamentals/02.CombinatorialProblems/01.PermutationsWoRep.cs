using System;

class PermutationsWithoutRepetition
{
    private static string[] input;
    private static string[] permutations;
    private static bool[] used;

    public static void Main(string[] args)
    {
        input = Console.ReadLine().Split();
        permutations = new string[input.Length];
        used = new bool[input.Length];

        Permute(0);
    }

    public static void Permute(int index)
    {
        if (index >= permutations.Length)
        {
            Console.WriteLine(string.Join(" ", permutations));
            return;
        }

        for (int i = 0; i < input.Length; i++)
        {
            if (!used[i])
            {
                used[i] = true;
                permutations[index] = input[i];
                Permute(index + 1);
                used[i] = false;
            }
        }
    }
}