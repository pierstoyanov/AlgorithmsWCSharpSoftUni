using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;


class SetCover
{
    public static void Main(string[] args)
    {
        var universe = Console.ReadLine()
            .Split(", ")
            .Select(int.Parse)
            .ToHashSet();

        var n = int.Parse(Console.ReadLine());

        var sets = new List<int[]>();

        for (int i = 0; i < n; i++)
        {
            var set = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            sets.Add(set);
        }

        var usedSets = new List<int[]>();
        while (universe.Count > 0)
        {
            var set = sets
                .OrderByDescending(s => s.Count(e => universe.Contains(e)))
                .FirstOrDefault();

            usedSets.Add(set);
            sets.Remove(set);

            foreach (var element in set)
            {
                universe.Remove(element);
            }

        }

        Console.WriteLine($"Sets to take ({usedSets.Count}):");

        foreach (var s in usedSets)
        {
            Console.WriteLine(string.Join(", ", s));
        }
    }
}
