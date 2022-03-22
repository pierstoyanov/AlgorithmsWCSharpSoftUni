using System;
using System.Linq;


class BinarySearchRecursive {
    public static void Main(string[] args) {
        var numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        var number = int.Parse(Console.ReadLine());
        Console.WriteLine(BinarySearch(numbers, number));
    }

    static int BinarySearch(int[] numbers, int number)
    {
        return BinarySearch(numbers, number, 0, numbers.Length - 1);
    }

    static int BinarySearch(int[] numbers, int number, int left, int right)
    {
        if (left <= right)
        {
            var midIndex = left + (right - left) / 2;

            if (numbers[midIndex] == number)
            {
                return midIndex;
            }

            if (number > numbers[midIndex])
            {
                return BinarySearch(numbers, number, midIndex + 1, right);
            }
            else
            {
                return BinarySearch(numbers, number, left, midIndex - 1);
            }
        }

        return -1;
    }
}
