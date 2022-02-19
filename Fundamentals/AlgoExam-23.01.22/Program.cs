using System;
using System.Collections.Generic;

namespace Exam
{
    class MoveDownRight
    {
        public static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());
            int pathCount = 0;

            var paths = CountPaths(rows, cols, new Dictionary<Tuple<int, int>, int>(), pathCount);
            Console.WriteLine(paths);
        }

        private static int CountPaths(int rows, int cols, Dictionary<Tuple<int, int>, int> dict, int pathCount)
        {
            if (rows == 1 || cols == 1)
            {
                return 1;
            }

            var here = new Tuple<int, int>(rows, cols);

            if (!dict.ContainsKey(here))
            {
                var result = CountPaths(rows - 1, cols, dict, pathCount) + CountPaths(rows, cols - 1, dict, pathCount);
                dict.Add(new Tuple<int, int>(rows, cols), result);
                return result;

            }
            else
            {
                return dict[here];
            }
        }
    }
}