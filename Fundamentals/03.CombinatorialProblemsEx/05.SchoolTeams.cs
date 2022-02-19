using System;
using System.Collections.Generic;
using System.Linq;

class SchoolTeams
{
    public static void Main(string[] args)
    {
        var females = Console.ReadLine().Split(", ");
        var femalesComb = new string[3];
        var femComb = new List<string[]>();

        GenerateCombinations(0, 0, females, femalesComb, femComb); 
        
        var males = Console.ReadLine().Split(", ");
        var malesComb = new string[2];
        var menComb = new List<string[]>();

        GenerateCombinations(0, 0, males, malesComb, menComb);

        foreach (var f in femComb)
        {
            foreach (var m in menComb)
            {
                Console.WriteLine($"{string.Join(", ", f)}, {string.Join(", ", m)}");
            }
        }
    }

    private static void GenerateCombinations(int index, int start, string[] elements, string[] comb, List<string[]> combinations)
    {
        if (index >= comb.Length)
        {
            //Console.WriteLine(string.Join(" ", comb));
            combinations.Add(comb.ToArray());
            return;
        }          

        for (int i = start; i < elements.Length; i++)
        {
            comb[index] = elements[i];
            GenerateCombinations(index + 1, i + 1, elements, comb, combinations);
        }
    }
}
