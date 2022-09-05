using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.SearchingSortingAndGreedyAlgorithms
{
    class BinarySearchProgram
    {
        static void Main(string[] args)
        {
            var list = Console.ReadLine().Split().ToArray();
            var target = Console.ReadLine();

            var result = BinarySearch(list, target, 0, list.Length - 1);
            Console.WriteLine(result);
        }

        public static int BinarySearch<T>(IEnumerable<T> collection, T target, int left, int right)
            where T : IComparable
        {
            if (left <= right)
            {
                int middleIdx = left + (right - left) / 2;

                if (collection.ElementAt(middleIdx).Equals(target))
                    return middleIdx;

                if (target.CompareTo(collection.ElementAt(middleIdx)) > 0)
                    return BinarySearch(collection, target, middleIdx + 1, right);
                
                else if (target.CompareTo(collection.ElementAt(middleIdx)) < 0)
                    return BinarySearch(collection, target, left, middleIdx - 1);
            }

            return -1;
        }
    }
}
