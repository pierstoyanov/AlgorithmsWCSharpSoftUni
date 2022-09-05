using System;
using System.Collections.Generic;
using System.Linq;


namespace _04.SearchingSortingAndGreedyAlgorithms
{
    class BubleSortProgram
    {
        static void Main(string[] args)
        {
            var arr = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var result = BubbleSort(arr);
            Console.WriteLine(string.Join(' ', result));
        }

        private static T[] BubbleSort<T>(T[] arr) where T : IComparable
        {
            //loop trough entire array
            for (int i = 0; i < arr.Length; i++)
            {
                var hasSwapped = false;
                //loop until last ordered pair
                for (int j = 0; j < arr.Length - i - 1; j++)
                {
                    if (arr[j].CompareTo(arr[j + 1]) > 0)
                    {
                        (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        hasSwapped = true;
                    }
                }

                if (hasSwapped == false)
                { break; }
            }

            return arr;
        }
    }

}
