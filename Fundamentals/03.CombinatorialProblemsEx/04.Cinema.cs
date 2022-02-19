using System;
using System.Collections.Generic;
using System.Linq;

class Cinema
{
    private static List<string> movingPeople;
    private static string[] people;
    private static bool[] locked;

    public static void Main(string[] args)
    {
        movingPeople = Console.ReadLine().Split(", ").ToList();
        people = new string[movingPeople.Count];
        locked = new bool[movingPeople.Count];


        while (true)
        {
            var line = Console.ReadLine();
            if (line == "generate")
            {
                break;
            }
            var parts = line.Split(" - ");
            var name = parts[0];
            var position = int.Parse(parts[1]) - 1;

            people[position] = name;
            locked[position] = true;

            movingPeople.Remove(name);
        }

        Permute(0);
    }

    private static void Permute(int index)
    {
        if (index >= movingPeople.Count)
        {
            //movingPeople.Sort();
            PrintPermute();
            //Console.WriteLine(string.Join(" ", movingPeople));
            return;
        }

        for (int i = index +1; i < movingPeople.Count; i++)
        {
            Swap(index, i);
            Permute(index + 1);
            Swap(index, i);

        }
        Permute(index + 1);
    }

    private static void PrintPermute()
    {
        var peopleIdx = 0;

        for(int i = 0; i < people.Length; i++)
        {
            if (i == people.Length - 1)
            {
                if (locked[i])
                {
                    Console.Write($"{people[i]}");
                }
                else
                {
                    Console.Write($"{movingPeople[peopleIdx++]}");
                }
            }
            else
            {
                if (locked[i])
                {
                    Console.Write($"{people[i]} ");
                }
                else
                {
                    Console.Write($"{movingPeople[peopleIdx++]} ");
                }
            }

        }

        Console.WriteLine();
    }

    private static void Swap(int first, int second)
    {
        var temp = movingPeople[first];
        movingPeople[first] = movingPeople[second];
        movingPeople[second] = temp;
    }
}
