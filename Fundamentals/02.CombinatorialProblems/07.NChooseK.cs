using System;

class NChooseK
{
    public static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int k = int.Parse(Console.ReadLine());

        Console.WriteLine(GetBinomialCoef(n, k));

    }

    private static int GetBinomialCoef(int row, int col)
    {
        if (row <= 1 || col == 0 || col == row)
        {
            return 1;
        }

        return GetBinomialCoef(row - 1, col) + GetBinomialCoef(row - 1, col - 1);
    }
}