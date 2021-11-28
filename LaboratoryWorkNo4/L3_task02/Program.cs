using System;
using static System.Console;

namespace L3_task02
{
    class Program
    {
        static Random _random = new Random();

        const int MinValue = -30;
        const int MaxValue = 30;

        static void Main(string[] args)
        {
            WriteLine("A) В виде двумерного массива:\n");

            double[,] matrix = RandomMatrix(6, 6);
            PrintMatrix(matrix);

            double[,] zeroedMatrix = FillBordersZeroes(matrix);

            WriteLine("Матрица с 0-границей:");
            PrintMatrix(zeroedMatrix);

            WriteLine("\nБ) В виде одномерной последовательности:\n");

            double[] odMatrix = RandomOneDimensionalMatrix(6, 6);
            PrintOneDimensionalMatrix(odMatrix, 6, 6);

            double[] zeroedOdMatrix = FillBorderZeroesOneDimensional(odMatrix, 6);

            WriteLine("Матрица с 0-границей:");
            PrintOneDimensionalMatrix(zeroedOdMatrix, 6, 6);
        }

        static double[,] FillBordersZeroes(double[,] matrix)
        {
            int sideLength = matrix.GetLength(0);

            for (int i = 0; i < sideLength; i++)
            {
                matrix[i, 0] = 0;
                matrix[0, i] = 0;

                matrix[sideLength - 1, i] = 0;
                matrix[i, sideLength - 1] = 0;
            }

            return matrix;
        }

        static double[] FillBorderZeroesOneDimensional(double[] matrix, int sideLength)
        {
            for (int i = 0; i < sideLength; i++)
            {
                matrix[Index(i, 0, sideLength)] = 0;
                matrix[Index(0, i, sideLength)] = 0;

                matrix[Index(sideLength - 1, i, sideLength)] = 0;
                matrix[Index(i, sideLength -1, sideLength)] = 0;
            }

            return matrix;
        }

        static int Index(int i, int j, int columns)
        {
            return columns * i + j;
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

        static double[] RandomOneDimensionalMatrix(int rows, int columns)
        {
            double[] matrix = new double[rows * columns];

            for (int i = 0; i < matrix.Length; i++)
            {
                matrix[i] = _random.Next(MinValue, MaxValue);
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

        static void PrintOneDimensionalMatrix(double[] matrix, int rows, int columns)
        {
            WriteLine($"Матрица {rows} на {columns}:");

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int index = columns * i + j;
                    Write($"{matrix[index]},\t");
                }

                Write("\n");
            }
        }
    }
}
