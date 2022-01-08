using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurrsionAndBacktracking
{
    internal class Factorial
    {
        public static void Main(string[] args)
        {
            var num = int.Parse(Console.ReadLine());

            Console.WriteLine(FactorialRecursive(num));
        }

        private static int FactorialRecursive(int input)
        {
            if (input == 0)
                return 1;

            return input * FactorialRecursive(input - 1);

        }
    }
}
