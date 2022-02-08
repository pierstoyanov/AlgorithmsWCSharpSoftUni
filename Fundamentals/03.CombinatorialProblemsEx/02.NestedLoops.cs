using System;

class NestedLoops
{
    private static string[] result;
    private static string[] numbers;
    private static int n;

    public static void Main(string[] args)
    {
        n = int.Parse(Console.ReadLine());
        result = new string[n];

        numbers = new string[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = "" + (i + 1);
        }

        NestLoop(0);
    }

    private static void NestLoop(int idx)
    {
        if (idx >= result.Length)
        {
            Console.WriteLine(string.Join(" ", result));
            return;
        }

        for (int i = 0; i < result.Length; i++)
        {
            result[idx] = numbers[i];
            NestLoop(idx + 1);
        }
    }
}