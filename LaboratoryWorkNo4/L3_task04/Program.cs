using System;
using static System.Console;

namespace L3_task04
{
    class Program
    {
        static int _length;

        static Random _random = new Random();
        const int MinValue = -30;
        const int MaxValue = 30;

        static void Main(string[] args)
        {
            WriteLine("A) В виде двумерного массива:\n");

            double[,] matrix = RandomUserMatrix();
            PrintMatrix(matrix);

            double[,] filledMatrix = FillDownAreaOnes(matrix);

            WriteLine("Матрица, заполненная единицами:");
            PrintMatrix(filledMatrix);

            WriteLine("\nБ) В виде одномерной последовательности:\n");

            double[] odMatrix = RandomUserOneDimensionalMatrix();
            PrintOneDimensionalMatrix(odMatrix, _length, _length);

            double[] filledOdMatrix = FillDownAreaOnesOneDimensional(odMatrix);

            WriteLine("Матрица, заполненная единицами:");
            PrintOneDimensionalMatrix(filledOdMatrix, _length, _length);
        }

        static double[,] FillDownAreaOnes(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int i = rows / 2; i < rows; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    matrix[i, j] = 1;
                }
            }

            return matrix;
        }

        static double[] FillDownAreaOnesOneDimensional(double[] matrix)
        {
            int rows = _length;

            for (int i = rows / 2; i < rows; i++)
            {
                for (int j = 0; j <= i; j++)
                {
                    matrix[Index(i, j, rows)] = 1;
                }
            }

            return matrix;
        }

        static double[,] RandomUserMatrix()
        {
            Write("Введите кол-во строк и столбцов: ");
            int sideLength = int.Parse(ReadLine());

            return RandomMatrix(sideLength, sideLength);
        }

        static double[] RandomUserOneDimensionalMatrix()
        {
            Write("Введите кол-во строк и столбцов: ");

            int sideLength = int.Parse(ReadLine());
            _length = sideLength;

            return RandomOneDimensionalMatrix(sideLength, sideLength);
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

        static int Index(int i, int j, int columns)
        {
            return columns * i + j;
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
                    int index = Index(i, j, columns);
                    Write($"{matrix[index]},\t");
                }

                Write("\n");
            }
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
    }
}
