using System;

namespace ExamPrep
{
    internal class TBC2
    {
        private const char visitedSymbol = 'v';
        private const char dirtSymbol = 'd';

        static void Main(string[] args)
        {
            //Console.WriteLine("Enter input");
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var map = new char[rows, cols];

            for (int r = 0; r < rows; r++)
            {
                var rowEl = Console.ReadLine();

                for (int c = 0; c < cols; c++)
                {
                    map[r, c] = rowEl[c];
                }
            }

            var tunnels = 0;

            for (int row = 0; row < map.GetLength(0); row++)
            {
                for (int col = 0; col < map.GetLength(1); col++)
                {
                    if (IsOutside(map, row, col) || IsDirt(map, row, col) || IsVisited(map, row, col))
                    {
                        continue;
                    }

                    ExploreTunnel(map, row, col);
                    tunnels += 1;
                }
            }

            Console.WriteLine(tunnels);
        }

        private static void ExploreTunnel(char[,] map, int row, int col)
        {
            if (IsOutside(map, row, col) || IsDirt(map, row, col) || IsVisited(map, row, col))
            {
                return;
            }

            map[row, col] = visitedSymbol;

            ExploreTunnel(map, row - 1, col); //UP
            ExploreTunnel(map, row + 1, col); //DOWN
            ExploreTunnel(map, row, col - 1); //LEFT
            ExploreTunnel(map, row, col + 1); //RIGHT

            ExploreTunnel(map, row - 1, col - 1); //Diag UP-LEFT
            ExploreTunnel(map, row + 1, col + 1); //Diag DOWN-RIGHT
            ExploreTunnel(map, row + 1, col - 1); //Diag Down-Left
            ExploreTunnel(map, row - 1, col + 1); //Diag UP-RIGHT

        }

        private static bool IsOutside(char[,] map, int row, int col)
        {
            return row < 0 || row >= map.GetLength(0) || col < 0 || col >= map.GetLength(1);
        }


        private static bool IsDirt(char[,] map, int row, int col)
        {
            return map[row, col] == dirtSymbol;
        }
        private static bool IsVisited(char[,] map, int row, int col)
        {
            return map[row, col] == visitedSymbol;
        }
    }
}
