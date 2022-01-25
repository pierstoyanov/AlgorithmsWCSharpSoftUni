using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecurrsionAndBacktracking
{
    class EightQueens
    {
        public static void Main(string[] args)
        {
            var board = new bool[8, 8];

            PutQueens(board, 0);
        }

        private static void PutQueens(bool[,] board, int row)
        {
            throw new NotImplementedException();
        }
    }
}
