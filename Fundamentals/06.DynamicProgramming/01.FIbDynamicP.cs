using System;
using System.Collections.Generic;

class FibWithMemo
{   
    private static Dictionary<int, long> cache;
    static void Main(string[] args)
    {
        var n = int.Parse(Console.ReadLine());
        cache = new Dictionary<int, long>();

        Console.WriteLine(GenerateFib(n));

    }

    private static long GenerateFib(int n)
    {
        if (n < 2)
        {
            return n;
        }

        if (cache.ContainsKey(n))
        {
            return cache[n];
        }

        var result = GenerateFib(n - 1) + GenerateFib(n - 2);
        cache[n] = result;

        return result;
    }
}
