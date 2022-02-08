using System;

class ReverseArray
{
    private static string result;
    private static string[] input;

    public static void Main(string[] args)
    {
        input = Console.ReadLine().Split(" ");
        Reverse(input.Length - 1);
    }

    private static void Reverse(int idx)
    {
        if (idx < 0)
        {
            Console.WriteLine(result.Trim());
            return;
        }

        result += $" {input[idx]}";
        Reverse(idx - 1);
        return;
    }
}