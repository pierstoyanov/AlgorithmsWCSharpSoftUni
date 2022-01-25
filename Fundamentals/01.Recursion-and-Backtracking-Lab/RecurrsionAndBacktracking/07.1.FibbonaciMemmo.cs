using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurrsionAndBacktracking
{
    class FibbonacciWithMemmoization
    {
        public static void Main(string[] args)
        {
            var inputNumber = int.Parse(Console.ReadLine());
            var result = GetFibonacci(inputNumber, new Dictionary<int, int>());
            Console.WriteLine(result);
        }

        private static int GetFibonacci(int n, Dictionary<int, int> dict)
        {
            if (n == 1 || n == 0)
            {
                return 1;
            }

            else if (dict.ContainsKey(n - 1) && dict.ContainsKey(n - 2))
            {
                return dict[n - 1] + dict[n - 2];
            }
            else if (dict.ContainsKey(n - 1))
            {
                return dict[n - 1] + GetFibonacci(n - 2, dict);
            }
            else if (dict.ContainsKey(n - 2))
            {
                return GetFibonacci(n - 1, dict) + dict[n - 2];
            }

            dict[n] = GetFibonacci(n - 1, dict) + GetFibonacci(n - 2, dict);
            return GetFibonacci(n - 1, dict) + GetFibonacci(n - 2, dict);
        }
    }
}
