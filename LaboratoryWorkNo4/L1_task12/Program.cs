using System;
using static System.Console;

namespace L1_task12
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

            double[,] erasedMatrx = EraseMaxValueRowAndColumn(matrix);

            WriteLine("Матрица без строки и столбца с пересечением на максимальном элемента:");
            PrintMatrix(erasedMatrx);
        }

        static double[,] EraseMaxValueRowAndColumn(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            int maxValueRow = 0;
            int maxValueColumn = 0;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] > matrix[maxValueRow, maxValueColumn])
                    {
                        maxValueRow = i;
                        maxValueColumn = j;
                    }
                }
            }

            WriteLine($"Максимальное значение пересекается в [{maxValueRow}, {maxValueColumn}]");
            WriteLine($"Или же в {maxValueRow + 1}-й строке и в {maxValueColumn + 1}-й столбце");

            double[,] erasedMatrix = new double[rows - 1, columns - 1];

            for (int i = 0; i < maxValueRow; i++)
            {
                for (int j = 0; j < maxValueColumn; j++)
                {
                    erasedMatrix[i, j] = matrix[i, j];
                }
            }

            for (int i = maxValueRow + 1; i < rows; i++)
            {
                for (int j = maxValueColumn + 1; j < columns; j++)
                {
                    erasedMatrix[i - 1, j - 1] = matrix[i, j];
                }
            }

            return erasedMatrix;
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
