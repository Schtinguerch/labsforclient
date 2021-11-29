using System;
using static System.Console;

namespace L3_task02
{
    class Program
    {
        delegate bool Comparer(double a, double b);
        delegate void SortMatrix(ref double[,] matrix, int rowIndex, Comparer comparer);

        static Random _random = new Random();
        const int MinValue = -30;
        const int MaxValue = 30;

        static void Main(string[] args)
        {
            var matrix = RandomUserMatrix();
            PrintMatrix(matrix, "Исходная матрица:");

            SortByIsRowEven(ref matrix);
            PrintMatrix(matrix, "Упорядоченная матрица: ");
        }

        static bool IsMoreComparer(double a, double b)
        {
            return a > b;
        }

        static bool IsLessComparer(double a, double b)
        {
            return a < b;
        }

        static void SortMatrixRow(ref double[,] matrix, int rowIndex, Comparer comparer)
        {
            int columns = matrix.GetLength(1);

            for (int i = 0; i < columns; i++)
            {
                for (int j= 0; j < columns - 1; j++)
                {
                    if (comparer(matrix[rowIndex, j], matrix[rowIndex, j + 1]))
                    {
                        double temp = matrix[rowIndex, j + 1];
                        matrix[rowIndex, j + 1] = matrix[rowIndex, j];
                        matrix[rowIndex, j] = temp;
                    }
                }
            }
        }

        static void SortByIsRowEven(ref double[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if ((i + 1) % 2 == 0)
                {
                    SortMatrixRow(ref matrix, i, IsMoreComparer);
                }

                else
                {
                    SortMatrixRow(ref matrix, i, IsLessComparer);
                }
            }
        }

        static double[,] RandomUserMatrix()
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
                    int value = _random.Next(MinValue, MaxValue);
                    matrix[i, j] = value;
                }
            }

            return matrix;
        }

        static void PrintMatrix(double[,] matrix, string message = "")
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            if (message != "")
            {
                WriteLine(message);
            }

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
