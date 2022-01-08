using System;
using System.Linq;

namespace RecurrsionAndBacktracking
{
    class RecursiveDrawing
    {
        public static void Main(string[] args)
        {
            var input = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray()[0];

            DrawWithRecursion(input);
        }

        private static void DrawWithRecursion(int input)
        {
            if (input <= 0)
                return;

            Console.WriteLine(new String('*', input));
            DrawWithRecursion(input - 1);
            Console.WriteLine(new String('#', input));
            return;

        }
    }
}
