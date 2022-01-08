using System;
using System.Linq;

namespace RecursionAndBacktracking
{
    class ArraySum
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine(SumArray(input, 0));
        }

        private static int SumArray(int[] array, int index)
        {
            if (index >= array.Length)
            {
                return 0;
            }

            return array[index] + SumArray(array, index + 1);
        }
    }
}