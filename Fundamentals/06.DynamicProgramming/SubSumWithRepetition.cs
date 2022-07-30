using System;
using System.Collections.Generic;

class SubSumWithRepetition
{
    static void Main(string[] args)
    {
        var nums = new[] { 3, 5, 2 };
        var target = 17;

        var sums = new bool[target + 1];
        sums[0] = true;

        for (int sum = 0; sum < sums.Length; sum++)
        {
            if (!sums[sum])
            {
                continue;
            }

            foreach (var num in nums)
            {
                var newSum = sum + num;

                if (newSum > target)
                {
                    continue;
                }

                sums[newSum] = true;
            }
        }


        var subset = new List<int>();

        while (target > 0)
        {
           foreach (var num in nums)
           {
                var perviousSum = target - num;

                if (perviousSum >=0 && sums[perviousSum])
                {
                   subset.Add(num);
                   target = perviousSum;

                   if (target == 0 )
                   {
                        break;
                   }
                }
           } 
        }

        Console.WriteLine(sums[target]);
        Console.WriteLine(string.Join(" ", subset));
    }
}