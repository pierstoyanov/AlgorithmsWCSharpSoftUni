using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurrsionAndBacktracking
{
    class Fibbonaci
    {
        public static void Main(string[] args)
        {
            var inputNumber = int.Parse(Console.ReadLine());

            Console.WriteLine(GetFibonacci(inputNumber));
        }

        private static int GetFibonacci(int n)
        {
            if (n == 1 || n == 0)
            {
                return 1;
            }
            return GetFibonacci(n - 1) + GetFibonacci(n - 2);
        }
    }
}
