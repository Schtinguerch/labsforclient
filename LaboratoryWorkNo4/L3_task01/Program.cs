using System;
using static System.Console;

namespace L3_task01
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

            double[,] sortedMatrix = SortRowsByMinValue(matrix);

            WriteLine("Матрица, где строки сортированы по минимальному значению каждой строки:");
            PrintMatrix(sortedMatrix);

            WriteLine("\nБ) В виде одномерной последовательности:\n");

            double[] odMatrix = RandomOneDimensionalMatrix(7, 5);
            PrintOneDimensionalMatrix(odMatrix, 7, 5);

            double[] sortedOdMatrix = SortRowsByMinValueOneDimensional(odMatrix, 7, 5);

            WriteLine("Матрица, где строки сортированы по минимальному значению каждой строки:");
            PrintOneDimensionalMatrix(sortedOdMatrix, 7, 5);
        }

        static double[,] SortRowsByMinValue(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            double[][] raggedMatrix = new double[rows][];
            double[] minValues = new double[rows];

            for (int i = 0; i < rows; i++)
            {
                raggedMatrix[i] = new double[columns];
                double minValue = matrix[i, 0];

                for (int j = 0; j < columns; j++)
                {
                    raggedMatrix[i][j] = matrix[i, j];

                    if (matrix[i, j] < minValue)
                    {
                        minValue = matrix[i, j];
                    }
                }

                minValues[i] = minValue;
            }

            for (int i = 0; i < minValues.Length; i += 1)
            {
                for (int j = 0; j < minValues.Length - 1; j++)
                {
                    if (minValues[j] < minValues[j + 1])
                    {
                        double temp = minValues[j + 1];
                        minValues[j + 1] = minValues[j];
                        minValues[j] = temp;

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

        static double[] SortRowsByMinValueOneDimensional(double[] matrix, int rows, int columns)
        {
            double[][] raggedMatrix = new double[rows][];
            double[] minValues = new double[rows];

            for (int i = 0; i < rows; i++)
            {
                raggedMatrix[i] = new double[columns];
                double minValue = matrix[columns * i];

                for (int j = 0; j < columns; j++)
                {
                    int index = columns * i + j;
                    raggedMatrix[i][j] = matrix[index];

                    if (matrix[index] < minValue)
                    {
                        minValue = matrix[index];
                    }
                }

                minValues[i] = minValue;
            }

            for (int i = 0; i < minValues.Length; i += 1)
            {
                for (int j = 0; j < minValues.Length - 1; j++)
                {
                    if (minValues[j] < minValues[j + 1])
                    {
                        double temp = minValues[j + 1];
                        minValues[j + 1] = minValues[j];
                        minValues[j] = temp;

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
                    int index = columns * i + j;
                    Write($"{matrix[index]},\t");
                }

                Write("\n");
            }
        }
    }
}
