using System;
using static System.Console;

namespace L1_task03
{
    class Program
    {
        static Random _random = new Random();

        const int MinValue = -30;
        const int MaxValue = 30;

        static void Main(string[] args)
        {
            double[,] matrix = RandomMatrix(4, 4);
            PrintMatrix(matrix);

            double diagonalSum = DiagonalSum(matrix);
            WriteLine($"Сумма диагоналей = {diagonalSum}");
        }

        static double DiagonalSum(double[,] matrix)
        {
            int sideLength = matrix.GetLength(0);
            double diagonalSum = 0;

            for (int i = 0; i < sideLength; i++)
            {
                double firstDiagonal = matrix[i, i];
                double secondDiagonal = matrix[i, sideLength - 1 - i];

                diagonalSum += firstDiagonal + secondDiagonal;
            }

            return diagonalSum;
        }

        static double[,] RandomMatrix(int rows, int columns)
        {
            double[,] matrix = new double[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = _random.Next(MinValue, MaxValue);
                }
            }

            return matrix;
        }

        static void PrintMatrix(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            WriteLine($"Матрица {rows}*{columns}:");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Write($"{matrix[i, j]},\t");
                }

                Write("\n");
            }
        }
    }
}
