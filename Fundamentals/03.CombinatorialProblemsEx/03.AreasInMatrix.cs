using System;
using System.Collections.Generic;
using System.Linq;

class AreasInMatrix
{
    private static char[,] matrix;
    private static int size;

    public class Area
    {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Size { get; set; }
    }


    public static void Main(string[] args)
    {
        var rows = int.Parse(Console.ReadLine());
        var cols = int.Parse(Console.ReadLine());

        matrix = new char[rows, cols];

        for (int i = 0; i < rows; i++)
        {
            var colEl = Console.ReadLine();

            for (int j = 0; j < cols; j++)
            {
                matrix[i, j] = colEl[j];
            }
        }

        var areas = new List<Area>();

        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                size = 0;
                Explore(r, c);

                if (size != 0)
                {
                    areas.Add(new Area { Row = r, Col = c, Size = size });
                }    
            }
        }

        var sorted = areas
            .OrderByDescending(a => a.Size)
            .ThenBy(a => a.Row)
            .ThenBy(a => a.Col)
            .ToList();

        Console.WriteLine($"Total areas found: {sorted.Count}");
        for (int i = 0; i < sorted.Count; i++)
        {
            Console.WriteLine($"Area #{i + 1} at ({sorted[i].Row}, {sorted[i].Col}), size: {sorted[i].Size}");
        }
    }

    private static void Explore(int row, int col)
    {
        if (IsOutside(row, col) || IsWall(row, col) || IsVisited(row, col))
        {
            return;
        }
             
        size += 1;

        matrix[row, col] = 'v';

        Explore(row - 1, col);
        Explore(row + 1, col);
        Explore(row, col - 1);
        Explore(row, col + 1);
    }

    private static bool IsVisited(int row, int col)
    {
        return matrix[row, col] == 'v';
    }

    private static bool IsWall(int row, int col)
    {
        return matrix[row, col] == '*';
    }

    private static bool IsOutside(int row, int col)
    {
        return row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1);   
    }
}
