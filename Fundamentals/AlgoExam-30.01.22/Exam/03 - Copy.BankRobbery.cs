using System;
using System.Collections.Generic;
using System.Linq;

class BankRobbery
{
    private static int[] elements;

    private static int[] left;
    private static int[] right;
    public static void Main(string[] args)
    {
        var input = Console.ReadLine().Split(" ");
        elements = Array.ConvertAll(input, s => int.Parse(s));
        Array.Sort(elements);
        Array.Reverse(elements);
          
        isPossible(elements, elements.Length);
        

        //var splitPoint = findSplitPoint(elements);
        //Console.WriteLine(splitPoint);

        //List<int> elList = elements.ToList();

        //Console.WriteLine(String.Join(" ", elList.GetRange(0, splitPoint)));
        //Console.WriteLine(String.Join(" ", elList.GetRange(splitPoint, elList.Count - 1)));
        // Console.WriteLine(String.Join(",", elements));

    }

    static int accumulate(int[] arr, int first, int last)
    {
        int init = 0;
        for (int i = first; i < last; i++)
        {
            init = init + arr[i];
        }

        return init;
    }

    // Returns true if it is possible to divide
    // array into two halves of same sum.
    // This function mainly uses combinationUtil()
    static Boolean isPossible(int[] arr, int n)
    {
        // If size of array is not even.
        if (n % 2 != 0)
            return false;

        // If sum of array is not even.
        int sum = accumulate(arr, 0, n);
        if (sum % 2 != 0)
            return false;

        // A temporary array to store all
        // combination one by one int k=n/2;
        int[] half = new int[n / 2];

        // Print all combination using temporary
        // array 'half[]'
        combinationUtil(arr, half, 0, n - 1, 0, n, sum);
        Array.Reverse(half);
        Console.WriteLine(String.Join(" ", half));

        return combinationUtil(arr, half, 0, n - 1,
                                0, n, sum);
    }

    /* arr[] ---> Input Array
    half[] ---> Temporary array to store current
                combination of size n/2
    start & end ---> Starting and Ending indexes in arr[]
    index ---> Current index in half[] */
    static Boolean combinationUtil(int[] arr, int[] half,
                                int start, int end,
                                int index, int n,
                                int sum)
    {
        // Current combination is ready to
        // be printed, print it
        if (index == n / 2)
        {
            int curr_sum = accumulate(half, 0, n / 2);
            return (curr_sum + curr_sum == sum);
        }

        // replace index with all possible elements.
        // The condition "end-i+1 >= n/2-index" makes
        // sure that including one element at index
        // will make a combination with remaining
        // elements at remaining positions
        for (int i = start; i <= end && end - i + 1 >=
                                n / 2 - index; i++)
        {
            half[index] = arr[i];
            if (combinationUtil(arr, half, i + 1, end,
                                index + 1, n, sum))
                return true;
        }

        return false;
    }
}