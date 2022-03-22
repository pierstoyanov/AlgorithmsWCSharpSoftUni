using System;
using System.Linq;

class InsertionSortAlg
{
    public static void Main(string[] args)
    {
        var numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        InsertionSort(numbers);
        Console.WriteLine(string.Join(" ", numbers));
    }

    static void InsertionSort(int[] numbers)
    {
        for (int i = 1; i < numbers.Length; i++)
        {
            var j = i;

            while (j > 0 && numbers[j] < numbers[j - 1])
            {
                Swap(numbers, j, j - 1);
                j -= 1;
            }
        }
    }

    static void Swap(int[] numbers, int first, int second)
    {
        var temp = numbers[first];
        numbers[first] = numbers[second];
        numbers[second] = temp;
    }
}
