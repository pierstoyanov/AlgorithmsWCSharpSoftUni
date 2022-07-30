using System;
using System.Collections.Generic;

class SubSum
{
    static void Main(string[] args)
    {
        var nums = new[] { 3, 5, 1, 4, 2 };
        var possibleSums = GetAllPossibleSums(nums);
        Console.WriteLine(string.Join(" ", possibleSums));
    }

    private static HashSet<int> GetAllPossibleSums(int[] nums)
    {
        var sums = new HashSet<int> { 0 };

        foreach (var num in nums)
        {
            var newSums = new HashSet<int>();

            foreach (var sum in sums)
            {
                newSums.Add(sum + num);
            }

            sums.UnionWith(newSums);
        }

        return sums;
    }
}