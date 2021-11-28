using System;
using static System.Console;

namespace L1_task06
{
    class Program
    {
        static Random _random = new Random();

        const int MinValue = -30;
        const int MaxValue = 30;

        static void Main(string[] args)
        {
            double[,] matrix = RandomMatrix(4, 7);
            PrintMatrix(matrix);

            double[] minValueArray = GetMinValueArray(matrix);

            WriteLine("Массив с минимальными значениями из каждой строки:");
            PrintArray(minValueArray);
        }

        static double[] GetMinValueArray(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            double[] minValueArray = new double[rows];

            for (int i = 0; i < rows; i++)
            {
                double minValue = matrix[i, 0];

                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] < minValue)
                    {
                        minValue = matrix[i, j];
                    }
                }

                minValueArray[i] = minValue;
            }

            return minValueArray;
        }

        static void PrintArray(double[] array)
        {
            if (array.Length == 0)
            {
                WriteLine("* Массив пустой *");
            }

            else
            {
                WriteLine($"Массив из {array.Length} элементов:");

                for (int i = 0; i < array.Length; i++)
                {
                    WriteLine($"[{i}] = {array[i]}");
                }
            }
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
