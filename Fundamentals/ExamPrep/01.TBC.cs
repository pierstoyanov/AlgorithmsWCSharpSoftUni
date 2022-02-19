using System;

namespace ExamPrep
{
    internal class TBC
    {
        private const char VisitedSym = 'v';
        private const char DirtSym = 'd';
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var map = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var rowElem = Console.ReadLine();

                for (int c = 0; c < cols; c++)
                {
                    map[r, c] = rowElem[c];
                }

            }

            var tunnels = 0;

            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    if (IsVisited(map, row, col) || IsDirt(map, row, col))
                    {
                        continue;
                    }

                    Explore(map, row, col);

                    tunnels += 1;
                }
            }

            Console.WriteLine(tunnels);
        }

        private static void Explore(char[,] map, int row, int col)
        {
            if (IsOutside(map, row, col) || IsVisited(map, row, col) || IsDirt(map, row, col))
            {
                return;
            }

            map[row, col] = VisitedSym;

            Explore(map, row - 1, col); //UP
            Explore(map, row + 1, col); //DOWN
            Explore(map, row, col - 1); //LEFT
            Explore(map, row, col + 1); //RIGHT
            Explore(map, row - 1, col - 1); //Diag UP/LEFT
            Explore(map, row - 1, col + 1); //Diag UP/RIGHT
            Explore(map, row + 1, col - 1); //Diag DOWN/LEFT
            Explore(map, row + 1, col + 1); //Diag DOWN/RIGHT
        }

        private static bool IsOutside(char[,] map, int row, int col)
        {
            return row < 0 || row >= map.GetLength(0) || col < 0 || col >= map.GetLength(1);
        }

        private static bool IsDirt(char[,] map, int row, int col)
        {
            return map[row, col] == DirtSym;
        }

        private static bool IsVisited(char[,] map, int row, int col)
        {
            return map[row, col] == VisitedSym;
        }
    }
}
