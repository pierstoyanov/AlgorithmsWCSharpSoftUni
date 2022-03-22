using System;
using System.Linq;


class QuickSortAlg
{
    public static void Main(string[] args)
    {
        var numbers = Console.ReadLine()
            .Split()
            .Select(int.Parse)
            .ToArray();

        QuickSort(numbers, 0, numbers.Length - 1);

        Console.WriteLine(string.Join(" ", numbers));
    }

    static void QuickSort(int[] numbers, int start, int end)
    {

        if (start >= end)
        {
            return;
        }
        var pivot = start;
        var left = start + 1;
        var right = end;

        while (left <= right)
        {
            if (numbers[left] > numbers[pivot] && numbers[right] < numbers[pivot])
            {
                Swap(numbers, left, right);
            }

            if (numbers[left] <= numbers[pivot])
            {
                left += 1;
            }

            if (numbers[right] >= numbers[pivot])
            {
                right -= 1;
            }
        }

        Swap(numbers, pivot, right);

        if (right - 1 - start > end - right + 1)
        {
            QuickSort(numbers, right + 1, end);
            QuickSort(numbers, start, right - 1);
        }
        else
        {
            QuickSort(numbers, start, right - 1);
            QuickSort(numbers, right + 1, end);
        }

    }

    static void Swap(int[] numbers, int first, int second)
    {
        var temp = numbers[first];
        numbers[first] = numbers[second];
        numbers[second] = temp;
    }

}
