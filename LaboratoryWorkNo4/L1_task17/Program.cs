using System;
using static System.Console;

namespace L1_task17
{
    class Program
    {
        static Random _random = new Random();

        const int MinValue = -30;
        const int MaxValue = 30;

        static void Main(string[] args)
        {
            double[,] matrix = RandomMatrixUserCount();
            PrintMatrix(matrix);

            double[,] minValueFirstColumnMatrix = SetMinValuesToFirstColumn(matrix);

            WriteLine("Матрица со строками, где первый элемент = мин. значению:");
            PrintMatrix(minValueFirstColumnMatrix);
        }

        static double[,] SetMinValuesToFirstColumn(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int i = 0; i < rows; i++)
            {
                int minValueIndex = 0;

                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] < matrix[i, minValueIndex])
                    {
                        minValueIndex = j;
                    }
                }

                double minValue = matrix[i, minValueIndex];

                for (int j = minValueIndex; j > 0; j--)
                {
                    matrix[i, j] = matrix[i, j - 1];
                }

                matrix[i, 0] = minValue;
            }

            return matrix;
        }

        static double[,] RandomMatrixUserCount()
        {
            Write("Введите кол-во строк: ");
            int rows = int.Parse(ReadLine());

            Write("Введите кол-во столбцов: ");
            int columns = int.Parse(ReadLine());

            return RandomMatrix(rows, columns);
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
