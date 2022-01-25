using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurrsionAndBacktracking
{
    class PathsInALabyrinth
    {
        public static void Main(string[] args)
        {

            FindPaths(ReadLabyrinth(), 0, 0, new List<string>(), string.Empty);
        }

        private static char[,] ReadLabyrinth()
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());
            var lab = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine();

                for (int col = 0; col < line.Length; col++)
                {
                    lab[row, col] = line[col];
                }
            }

            return lab;
        }

        private static void FindPaths(char[,] lab, int row, int col, List<string> directions, string currentDirection)
        {
            //validate rows and colls
            if (row < 0 || row >= lab.GetLength(0) || col < 0 || col >= lab.GetLength(1))
            {
                return;
            }

            //check for wall or visited cell
            if (lab[row, col] == '*' || lab[row, col] == 'v')
            {
                return;
            }

            //add currentDirection to directions
            directions.Add(currentDirection);

            //exit
            if (lab[row, col] == 'e')
            {
                Console.WriteLine(string.Join(string.Empty, directions));

                directions.RemoveAt(directions.Count - 1);

                return;
            }

            //mark visited
            lab[row, col] = 'v';

            //move in directions
            FindPaths(lab, row - 1, col, directions, "U"); //UP
            FindPaths(lab, row + 1, col, directions, "D"); //DOWN
            FindPaths(lab, row, col - 1, directions, "L"); //LEFT
            FindPaths(lab, row, col + 1, directions, "R"); //RIGHT

            //remove cell marking
            lab[row, col] = '-';
            directions.RemoveAt(directions.Count - 1);

        }
    }
}
