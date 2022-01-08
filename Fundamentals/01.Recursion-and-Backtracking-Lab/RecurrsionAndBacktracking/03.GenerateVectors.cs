using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurrsionAndBacktracking
{
    class GenerateVectors
    {
        public static void Main(string[] args)
        {
            var arrayLength = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray()[0];

            Console.WriteLine(GenerateVector(arrayLength));
        }

        private static bool GenerateVector(int input)
        {
            if (input <= 0)
                return false;

            return true;

        }
    }
}
