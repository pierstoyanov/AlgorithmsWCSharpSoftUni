using System;

class NestedLoopsShort
{
    private static int[] numbers;

    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        numbers = new int[n];


        GenerateVectors(0);
    }

    private static void GenerateVectors(int idx)
    {
        if (idx >= numbers.Length)
        {
            Console.WriteLine(String.Join(" ", numbers));
            return;
        }

        for (int i = 1; i <= numbers.Length; i++)
        {
            numbers[idx] = i;
            GenerateVectors(idx + 1);
        }
    }
}