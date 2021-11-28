using System;
using static System.Console;
using static System.Math;

namespace L1_task31
{
    class Program
    {
        static Random _random = new Random();

        const int MinValue = -30;
        const int MaxValue = 30;

        static void Main(string[] args)
        {
            double[,] matrix = RandomMatrixWithoutLastColumn(5, 8);
            PrintMatrix(matrix);

            double[] insertionVector = new double[5] { 999, 999, 999, 999, 999 };
            double[,] filledMatrix = AddVectorAfterColumnMaxValue(matrix, insertionVector, 4);

            WriteLine("Матрица, дозаполненная вектором после столбца с минимальным элементом в 5-й строке:");
            PrintMatrix(filledMatrix);
        }

        static double[,] AddVectorAfterColumnMaxValue(double[,] matrix, double[] vector, int rowIndex)
        {
            int minValueColumn = 0;
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int i = 0; i < columns - 1; i++)
            {
                if (matrix[rowIndex, i] < matrix[rowIndex, minValueColumn])
                {
                    minValueColumn = i;
                }
            }

            for (int j = columns - 1; j > minValueColumn + 1; j--)
            {
                for (int i = 0; i < rows; i++)
                {
                    matrix[i, j] = matrix[i, j - 1];
                }
            }

            for (int i = 0; i < rows; i++)
            {
                matrix[i, minValueColumn + 1] = vector[i];
            }

            return matrix;
        }

        static double[,] RandomMatrixWithoutLastColumn(int rows, int columns)
        {
            double[,] matrix = new double[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns - 1; j++)
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
