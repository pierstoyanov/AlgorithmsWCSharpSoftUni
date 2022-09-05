using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SearchingSortingAndGreedyAlgorithms
{
    class SelectionSortProgram
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split().Select(int.Parse).ToArray();


            var result = SelectionSort.Sort(list);
            Console.Write(string.Join(' ', result));   
        }

    }

    class SelectionSort
    {
        public static T[] Sort<T>(T[] list) where T : IComparable
        {
            for (int i = 0; i < list.Length - 1; i++)
            {
                var minIdx = i;
                for (int j = i + 1; j < list.Length; j++)
                {
                    if (list[j].CompareTo(list[minIdx]) < 0)
                    {
                        Swap(list, j, i);
                    }
                }
            }
            return list;
        }

        private static void Swap<T>(IList<T> list, int j, int i) where T : IComparable
        {
            (list[j], list[i]) = (list[i], list[j]);
        }
    }
}
