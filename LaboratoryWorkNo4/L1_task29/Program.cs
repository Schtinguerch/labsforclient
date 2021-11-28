using System;
using static System.Console;
using static System.Math;

namespace L1_task29
{
    class Program
    {
        static Random _random = new Random();

        const int MinValue = -30;
        const int MaxValue = 30;

        static void Main(string[] args)
        {
            double[,] matrix = RandomMatrix(5, 7);
            PrintMatrix(matrix);

            double[,] withoutColumnMatrix = DeleteColumnAfterMinValueRow(matrix, 1);

            WriteLine("Матрица без столбца, после столбца с минимальным по модулю элементом во 2-й строке:");
            PrintMatrix(withoutColumnMatrix);
        }

        static double[,] DeleteColumnAfterMinValueRow(double[,] matrix, int rowIndex)
        {
            int minValueColumn = 0;
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int i = 0; i < columns; i++)
            {
                if (Abs(matrix[rowIndex, i]) < Abs(matrix[rowIndex, minValueColumn]))
                {
                    minValueColumn = i;
                }
            }

            if (minValueColumn == columns - 1)
            {
                Write("Столбец с минимальным значением является последним, удаление столбца невозможно");
                return matrix;
            }

            int deleteColumn = minValueColumn + 1;
            double[,] newMatrix = new double[rows, columns - 1];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < deleteColumn; j++)
                {
                    newMatrix[i, j] = matrix[i, j];
                }

                for (int j = deleteColumn + 1; j < columns; j++)
                {
                    newMatrix[i, j - 1] = matrix[i, j];
                }
            }

            return newMatrix;
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
