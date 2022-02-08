using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurrsionAndBacktracking
{
    class EightQueens
    {

        public static HashSet<int> attackedRows = new HashSet<int>();
        public static HashSet<int> attackedCols = new HashSet<int>();
        public static HashSet<int> attLeftDiag = new HashSet<int>();
        public static HashSet<int> attRightDiag = new HashSet<int>();


        public static void Main(string[] args)
        {
            var board = new bool[8, 8];

            PutQueens(board, 0);
        }

        private static void PutQueens(bool[,] board, int row)
        {
            if (row >= board.GetLength(0))
            {
                PrintBoard(board);
                return;
            }

            for (int col = 0; col < board.GetLength(1); col++)
            {
                if (CanPlaceQueen(row, col))
                {
                    attackedRows.Add(row);
                    attackedCols.Add(col);
                    attLeftDiag.Add(row - col);
                    attRightDiag.Add(row + col);

                    board[row, col] = true;

                    PutQueens(board, row + 1);

                    attackedRows.Remove(row);
                    attackedCols.Remove(col);
                    attLeftDiag.Remove(row - col);
                    attRightDiag.Remove(row + col);
                    board[row, col] = false;
                }
            }
        }

        private static bool CanPlaceQueen(int row, int col)
        {
            return !attackedRows.Contains(row) &&
            !attackedCols.Contains(col) &&
            !attLeftDiag.Contains(row - col) &&
            !attRightDiag.Contains(row + col);
        }

        private static void PrintBoard(bool[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col])
                    {
                        Console.Write("* ");
                    }
                    else
                    {
                        Console.Write("- ");
                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine();
        }
    }
}
