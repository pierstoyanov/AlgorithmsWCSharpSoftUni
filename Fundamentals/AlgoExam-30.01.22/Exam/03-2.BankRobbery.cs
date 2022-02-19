using System;
using System.Collections.Generic;
using System.Linq;

class BankRobberyTwo
{
    private static int[] elements;
    public static bool[] used;

    public static int[] left;
    public static int[] right;


    public static void Main(string[] args)
    {
        var input = Console.ReadLine().Split(" ");
        elements = Array.ConvertAll(input, s => int.Parse(s));

        //Array.Sort(elements);
        splitEqualSum(elements, elements.Length);

    }

	public static void splitEqualSum(int[] arr, int n)
	{
		// Define some useful resultant auxiliary variables
		int sum = 0;
		int auxiliary = 0;
		int breakPoint = -1;
		// Loop controlling variable
		int i = 0;
		// Calculate sum of all elements
		for (i = 0; i < n; ++i)
		{
			sum += arr[i];
		}
		// Find that two equal subarray exists in given array
		for (i = 0; i < n && breakPoint == -1; ++i)
		{
			// Add current element into auxiliary variable
			auxiliary += arr[i];
			// Reduce current element
			sum = sum - arr[i];
			if (auxiliary == sum)
			{
				breakPoint = i + 1;
			}
		}
		if (breakPoint != -1)
		{
			for (i = 0; i < n; ++i)
			{
				if (breakPoint == i)
				{
					Console.Write("\n");
				}
				Console.Write("  " + arr[i]);
			}
		}
		else
		{
			Console.Write("\n No equal subarrays sum \n");
		}
	}
}