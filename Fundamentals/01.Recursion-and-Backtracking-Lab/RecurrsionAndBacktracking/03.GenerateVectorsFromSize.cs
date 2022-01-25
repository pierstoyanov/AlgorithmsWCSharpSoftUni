using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurrsionAndBacktracking
{
    class GenerateVectorsFromSize
    {
        public static void Main(string[] args)
        {

            int input = int.Parse(Console.ReadLine());

            var arr = new int[input];

            GenerateVectors(arr, 0);

        }

        private static void GenerateVectors(int[] arr, int index)
        {
            if (index >= arr.Length)
            {
                Console.WriteLine(string.Join(string.Empty, arr));
                return;
            }

            for (int i = 0; i < 2; i++)
            {
                arr[index] = i;
                GenerateVectors(arr, index + 1);
            }
        }
    }
}
