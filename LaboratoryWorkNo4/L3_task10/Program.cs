using System;
using static System.Console;

namespace L3_task10
{
    class Program
    {
        static int _rows, _columns;

        static Random _random = new Random();
        const int MinValue = -30;
        const int MaxValue = 30;

        static void Main(string[] args)
        {
            WriteLine("A) В виде двумерного массива:\n");

            double[,] matrix = RandomUserMatrix();
            PrintMatrix(matrix);

            double[,] sortedMatrix = SortRowsEvenOdd(matrix);

            WriteLine("Матрица, где чётные индексы в строках отсортированы по убыванию, нечётные - по возрастанию:");
            PrintMatrix(sortedMatrix);

            WriteLine("\nБ) В виде одномерной последовательности:\n");

            double[] odMatrix = RandomUserOneDimensionalMatrix();
            PrintOneDimensionalMatrix(odMatrix, _rows, _columns);

            double[] sortedOdMatrix = SortRowsEvenOddOneDimensional(odMatrix, _rows, _columns);

            WriteLine("Матрица, где чётные индексы в строках отсортированы по убыванию, нечётные - по возрастанию:");
            PrintOneDimensionalMatrix(sortedOdMatrix, _rows, _columns); 
        }

        static double[,] SortRowsEvenOdd(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            for (int k = 0; k < rows; k++)
            {
                for (int i = 0; i < columns; i += 2)
                {
                    for (int j = 0; j < columns - 2; j += 2)
                    {
                        if ((matrix[k, j] < matrix[k, j + 2]))
                        {
                            double temp = matrix[k, j + 2];
                            matrix[k, j + 2] = matrix[k, j];
                            matrix[k, j] = temp;
                        }
                    }

                    for (int j = 0; j + 1 < columns - 2; j += 2)
                    {

                        j += 1;

                        if ((matrix[k, j] > matrix[k, j + 2]))
                        {
                            double temp = matrix[k, j + 2];
                            matrix[k, j + 2] = matrix[k, j];
                            matrix[k, j] = temp;
                        }

                        j -= 1;
                    }
                }
            }

            return matrix;
        }

        static double[] SortRowsEvenOddOneDimensional(double[] matrix, int rows, int columns)
        {
            for (int k = 0; k < rows; k++)
            {
                for (int i = 0; i < columns; i += 2)
                {
                    for (int j = 0; j < columns - 2; j += 2)
                    {
                        if ((matrix[Index(k, j, columns)] < matrix[Index(k, j + 2, columns)]))
                        {
                            double temp = matrix[Index(k, j + 2, columns)];
                            matrix[Index(k, j + 2, columns)] = matrix[Index(k, j, columns)];
                            matrix[Index(k, j, columns)] = temp;
                        }
                    }

                    for (int j = 0; j + 1 < columns - 2; j += 2)
                    {
                        j += 1;

                        if ((columns - j >= 2) && (matrix[Index(k, j, columns)] > matrix[Index(k, j + 2, columns)]))
                        {
                            double temp = matrix[Index(k, j + 2, columns)];
                            matrix[Index(k, j + 2, columns)] = matrix[Index(k, j, columns)];
                            matrix[Index(k, j, columns)] = temp;
                        }

                        j -= 1;
                    }
                }
            }

            return matrix;
        }

        static double[,] RandomUserMatrix()
        {
            Write("Введите кол-во строк: ");
            int rows = int.Parse(ReadLine());

            Write("Введите кол-во столбцов: ");
            int columns = int.Parse(ReadLine());

            return RandomMatrix(rows, columns);
        }

        static double[] RandomUserOneDimensionalMatrix()
        {
            Write("Введите кол-во строк: ");
            int rows = int.Parse(ReadLine());
            _rows = rows;

            Write("Введите кол-во столбцов: ");
            int columns = int.Parse(ReadLine());
            _columns = columns;

            return RandomOneDimensionalMatrix(rows, columns);
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
