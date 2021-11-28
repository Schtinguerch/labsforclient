using System;
using static System.Console;

namespace L3_task03
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

            double[] sums = GetDiagonalSumms(matrix);

            WriteLine("Суммы диагоналей:");
            PrintArray(sums);

            WriteLine("\nБ) В виде одномерной последовательности:\n");

            double[] odMatrix = RandomUserOneDimensionalMatrix();
            PrintOneDimensionalMatrix(odMatrix, _length, _length);

            double[] odSums = GetDiagonalSummsOneDimensional(odMatrix);

            WriteLine("Суммы диагоналей:");
            PrintArray(odSums);
        }

        static double[] GetDiagonalSumms(double[,] matrix)
        {
            int sideLength = matrix.GetLength(0);
            double[] results = new double[2 * sideLength - 1];

            int index = -1;

            for (int i = 0; i < sideLength; i++)
            {
                index++;
                double sum = 0;

                for (int j = 0; j + i < sideLength; j++)
                {
                    sum += matrix[j, j + i];
                }

                results[index] = sum;
            }

            for (int i = 1; i < sideLength; i++)
            {
                index++;
                double sum = 0;

                for (int j = 0; j + i < sideLength; j++)
                {
                    sum += matrix[j + i, j];
                }

                results[index] = sum;
            }

            return results;
        }

        static double[] GetDiagonalSummsOneDimensional(double[] matrix)
        {
            int sideLength = _length;
            double[] results = new double[2 * sideLength - 1];

            int index = -1;

            for (int i = 0; i < sideLength; i++)
            {
                index++;
                double sum = 0;

                for (int j = 0; j + i < sideLength; j++)
                {
                    sum += matrix[Index(j, j + i, sideLength)];
                }

                results[index] = sum;
            }

            for (int i = 1; i < sideLength; i++)
            {
                index++;
                double sum = 0;

                for (int j = 0; j + i < sideLength; j++)
                {
                    sum += matrix[Index(j + i, j, sideLength)];
                }

                results[index] = sum;
            }

            return results;
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