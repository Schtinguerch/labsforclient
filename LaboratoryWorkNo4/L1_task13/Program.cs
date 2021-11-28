using System;
using static System.Console;
namespace L1_task13
{
    internal class Program
    {
        static Random _random = new Random();

        const int MinValue = -30;
        const int MaxValue = 30;

        static void Main(string[] args)
        {
            double[,] matrix = RandomMatrix(5, 5);
            PrintMatrix(matrix);

            int columnMaxValue = GetColumnWithMaxDiagonalValue(matrix);
            WriteLine($"Столбец с максимальным элемент на диагонали = [{columnMaxValue}]");
            WriteLine($"Он же {columnMaxValue + 1}-й столбец");

            double[,] swappedMatrix = SwapColumns(matrix, 3, columnMaxValue);
            PrintMatrix(swappedMatrix);
        }

        static int GetColumnWithMaxDiagonalValue(double[,] matrix)
        {
            int maxValueColumn = 0;
            int sideLength = matrix.GetLength(0);

            for (int i = 0; i < sideLength; i++)
            {
                if (matrix[i, i] > matrix[maxValueColumn, maxValueColumn])
                {
                    maxValueColumn = i;
                }

                if (matrix[i, sideLength - 1 - i] > matrix[maxValueColumn, maxValueColumn]) 
                {
                    maxValueColumn = i;
                }
            }

            return maxValueColumn;
        }

        static double[,] SwapColumns(double[,] matrix, int a, int b)
        {
            int rows = matrix.GetLength(0);

            for (int i = 0; i < rows; i++)
            {
                double buffer = matrix[i, a];
                matrix[i, a] = matrix[i, b];
                matrix[i, b] = buffer;
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
