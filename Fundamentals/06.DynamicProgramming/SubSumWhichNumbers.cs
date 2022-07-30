using System;
using System.Collections.Generic;

class SubSumWhichNumbers
{
    static void Main(string[] args)
    {
        var nums = new[] { 3, 5, 1, 4, 2 };
        var possibleSums = GetAllPossibleSums(nums);
        var target = 6;

        if (possibleSums.ContainsKey(target))
        {
            var usedNums = FindSubset(possibleSums, target);
            Console.WriteLine(string.Join(" ", usedNums));
        }
    }

    private static List<int> FindSubset(Dictionary<int, int> possibleSums, int target)
    {
        var subset = new List<int>();

        while (target > 0)
        {
            var num = possibleSums[target];
            target -= num;
            
            subset.Add(num); 
        }

        return subset;
    }

    private static Dictionary<int, int> GetAllPossibleSums(int[] nums)
    {
        var sums = new Dictionary<int, int> { {0, 0} };

        foreach (var num in nums)
        {
            var currentSums = sums.Keys.ToArray();

            foreach (var sum in currentSums)
            {
                var newSum = sum + num;
                if (sums.ContainsKey(newSum))
                {
                    continue;
                }

                sums.Add(newSum, num);
            }

        }

        return sums;
    }
}