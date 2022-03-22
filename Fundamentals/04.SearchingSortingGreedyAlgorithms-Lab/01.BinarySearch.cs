using System;
using System.Linq;

class BinarySearchIterative
{
    public static void Main(string[] args)
    {
        var numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        var number = int.Parse(Console.ReadLine());
        Console.WriteLine(BinarySearch(numbers, number));
    }

    static int BinarySearch(int[] numbers, int number)
    {
        var left = 0;
        var right = numbers.Length - 1;

        while (left <= right)
        {
            var midIndex = (left + right) / 2;

            if (numbers[midIndex] == number)
            {
                return midIndex;
            }

            if (number > numbers[midIndex])
            {
                left = midIndex + 1;
            }

            else
            {
                right = midIndex - 1;
            }
        }

        return -1;
    }
}
