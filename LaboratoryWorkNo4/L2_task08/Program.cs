using System;
using static System.Console;

namespace L2_task08
{
    class Program
    {
        static Random _random = new Random();

        const int MinValue = -30;
        const int MaxValue = 30;

        static void Main(string[] args)
        {
            double[,] matrix = RandomMatrix(6, 6);
            PrintMatrix(matrix);

            double[,] swappedMatrix = SwapRowNeighbors(matrix);

            WriteLine("Матрица с поменяннами местами соседними строками (1 и 2, 3 и 4, 5 и 6):");
            PrintMatrix(swappedMatrix);
        }

        static double[,] SwapRowNeighbors(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int colunms = matrix.GetLength(1);

            for (int i = 0; i < rows; i += 2)
            {
                for (int j = 0; j < colunms; j++)
                {
                    double temp = matrix[i, j];
                    matrix[i, j] = matrix[i + 1, j];
                    matrix[i + 1, j] = temp;
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
