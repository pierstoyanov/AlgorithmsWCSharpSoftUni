using System;

class ReverseArrayShort
{
    private static string[] input;

    public static void Main(string[] args)
    {
        input = Console.ReadLine().Split(" ");
        Reverse(input, 0);

        Console.WriteLine(String.Join(" ", input));
    }

    private static void Reverse(string[] elements, int idx)
    {
        if (idx == elements.Length / 2)
        {
            return;
        }

        var temp = elements[idx];
        elements[idx] = elements[elements.Length - idx - 1];
        elements[elements.Length - idx - 1] = temp;

        Reverse(elements, idx + 1);
    }
}