using System;
using static System.Console;

namespace L3_task08
{
    class Program
    {
        static Random _random = new Random();
        const int MinValue = -30;
        const int MaxValue = 30;

        static void Main(string[] args)
        {
            WriteLine("A) В виде двумерного массива:\n");

            double[,] matrix = RandomMatrix(7, 5);
            PrintMatrix(matrix);

            double[,] sortedMatrix = SortRowsByPositiveCount(matrix);

            WriteLine("Матрица, где строки отсортированы по кол-ву положительных чисел по убыванию:");
            PrintMatrix(sortedMatrix);

            WriteLine("\nБ) В виде одномерной последовательности:\n");

            double[] odMatrix = RandomOneDimensionalMatrix(7, 5);
            PrintOneDimensionalMatrix(odMatrix, 7, 5);

            double[] sortedOdMatrix = SortRowsByPositiveCountOneDimensional(odMatrix, 7, 5);

            WriteLine("Матрица, где строки отсортированы по кол-ву положительных чисел по убыванию:");
            PrintOneDimensionalMatrix(sortedOdMatrix, 7, 5);
        }

        static double[,] SortRowsByPositiveCount(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            double[][] raggedMatrix = new double[rows][];
            double[] positiveCounts = new double[rows];

            for (int i = 0; i < rows; i++)
            {
                raggedMatrix[i] = new double[columns];
                double positiveCount = 0;

                for (int j = 0; j < columns; j++)
                {
                    raggedMatrix[i][j] = matrix[i, j];

                    if (matrix[i, j] > 0)
                    {
                        positiveCount++;
                    }
                }

                positiveCounts[i] = positiveCount;
            }

            for (int i = 0; i < positiveCounts.Length; i += 1)
            {
                for (int j = 0; j < positiveCounts.Length - 1; j++)
                {
                    if (positiveCounts[j] < positiveCounts[j + 1])
                    {
                        double temp = positiveCounts[j + 1];
                        positiveCounts[j + 1] = positiveCounts[j];
                        positiveCounts[j] = temp;

                        double[] tempArray = raggedMatrix[j + 1];
                        raggedMatrix[j + 1] = raggedMatrix[j];
                        raggedMatrix[j] = tempArray;
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    matrix[i, j] = raggedMatrix[i][j];
                }
            }

            return matrix;
        }

        static double[] SortRowsByPositiveCountOneDimensional(double[] matrix, int rows, int columns)
        {
            double[][] raggedMatrix = new double[rows][];
            double[] positiveCounts = new double[rows];

            for (int i = 0; i < rows; i++)
            {
                raggedMatrix[i] = new double[columns];
                double positiveCount = 0;

                for (int j = 0; j < columns; j++)
                {
                    int index = columns * i + j;
                    raggedMatrix[i][j] = matrix[index];

                    if (matrix[index] > 0)
                    {
                        positiveCount++;
                    }
                }

                positiveCounts[i] = positiveCount;
            }

            for (int i = 0; i < positiveCounts.Length; i += 1)
            {
                for (int j = 0; j < positiveCounts.Length - 1; j++)
                {
                    if (positiveCounts[j] < positiveCounts[j + 1])
                    {
                        double temp = positiveCounts[j + 1];
                        positiveCounts[j + 1] = positiveCounts[j];
                        positiveCounts[j] = temp;

                        double[] tempArray = raggedMatrix[j + 1];
                        raggedMatrix[j + 1] = raggedMatrix[j];
                        raggedMatrix[j] = tempArray;
                    }
                }
            }

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    int index = columns * i + j;
                    matrix[index] = raggedMatrix[i][j];
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
