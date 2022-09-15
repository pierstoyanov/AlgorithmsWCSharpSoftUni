using System;
using System.Linq;

namespace _04.SearchingSortingAndGreedyAlgorithms
{
    class InsertionSortProgram
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var result = InsertionSort(arr);
            Console.WriteLine(string.Join(' ', result));
        }

        private static int[] InsertionSort(int[] arr)
        {
            //loop trough entire array
            for (int i = 0; i < arr.Length; i++)
            {
                var current = arr[i];
                var j = i - 1;

                while (j >= 0 && arr[j] > current)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }

                arr[j + 1] = current;
            }

            return arr;
        }
    }
}
