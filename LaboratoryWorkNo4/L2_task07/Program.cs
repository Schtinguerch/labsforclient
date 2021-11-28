using System;
using static System.Console;

namespace L2_task07
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

            double[,] zeroedMatrix = ZeroUpperDiagonalAndMaxValue(matrix);

            WriteLine("Матрица, где элемента правее главной диагонали (и выже максимального значения диагонали) обнулены:");
            PrintMatrix(zeroedMatrix);
        }

        static double[,] ZeroUpperDiagonalAndMaxValue(double[,] matrix)
        {
            int sideLength = matrix.GetLength(0);
            int maxValueIndex = 0;

            for (int i = 0; i < sideLength; i++)
            {
                if (matrix[i, i] > matrix[maxValueIndex, maxValueIndex])
                {
                    maxValueIndex = i;
                }
            }

            for (int i = 0; i < maxValueIndex; i++)
            {
                for (int j = i + 1; j < sideLength; j++)
                {
                    matrix[i, j] = 0;
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
