using System;
using static System.Console;

namespace L2_task09
{
    class Program
    {
        static Random _random = new Random();

        const int MinValue = -30;
        const int MaxValue = 30;

        static void Main(string[] args)
        {
            double[,] matrix = RandomMatrix(6, 7);
            PrintMatrix(matrix);

            double[,] swapRowMatrix = SwapRows(matrix);

            WriteLine("Матрица с перевёрнутыми строками:");
            PrintMatrix(swapRowMatrix);
        }

        static double[,] SwapRows(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns / 2; j++)
                {
                    double temp = matrix[i, j];
                    matrix[i, j] = matrix[i, columns - j - 1];
                    matrix[i, columns - j - 1] = temp;
                }
            }

            return matrix;
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

            WriteLine($"Матрица {rows} на {columns}:");

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
