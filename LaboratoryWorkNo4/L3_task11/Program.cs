using System;
using static System.Console;

namespace L3_task11
{
    class Program
    {
        static int _rows, _columns;

        static Random _random = new Random();
        const int MinValue = -5;
        const int MaxValue = 30;

        static void Main(string[] args)
        {
            WriteLine("A) В виде двумерного массива:\n");

            double[,] matrix = RandomUserMatrix();
            PrintMatrix(matrix);

            double[,] sortedMatrix = RowsWithoutZeroes(matrix);

            WriteLine("Матрица, без строк с нулевыми элементами:");
            PrintMatrix(sortedMatrix);

            WriteLine("\nБ) В виде одномерной последовательности:\n");

            double[] odMatrix = RandomUserOneDimensionalMatrix();
            PrintOneDimensionalMatrix(odMatrix, _rows, _columns);

            double[] sortedOdMatrix = RowsWithoutZeroesOneDimensional(odMatrix, _rows, _columns);

            WriteLine("Матрица, без строк с нулевыми элементами:");
            PrintOneDimensionalMatrix(sortedOdMatrix, _rows, _columns);
        }

        static double[,] RowsWithoutZeroes(double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            bool[] hasZeroes = new bool[rows];
            int withZeroCount = 0;

            for (int i = 0; i < rows; i++)
            {
                bool hasZero = false;
                
                for (int j = 0; j < columns; j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        withZeroCount++;
                        hasZero = true;
                        break;
                    }
                }

                hasZeroes[i] = hasZero;
            }

            double[,] withoutZeroMatrix = new double[rows - withZeroCount, columns];
            int index = -1;

            for (int i = 0; i < rows; i++)
            {
                if (!hasZeroes[i])
                {
                    index++;

                    for (int j = 0; j < columns; j++)
                    {
                        withoutZeroMatrix[index, j] = matrix[i, j];
                    }
                }
            }

            return withoutZeroMatrix;
        }

        static double[] RowsWithoutZeroesOneDimensional(double[] matrix, int rows, int columns)
        {
            bool[] hasZeroes = new bool[rows];
            int withZeroCount = 0;

            for (int i = 0; i < rows; i++)
            {
                bool hasZero = false;

                for (int j = 0; j < columns; j++)
                {
                    if (matrix[Index(i, j, columns)] == 0)
                    {
                        withZeroCount++;
                        hasZero = true;
                        break;
                    }
                }

                hasZeroes[i] = hasZero;
            }

            double[] withoutZeroMatrix = new double[(rows - withZeroCount) * columns];
            _rows -= withZeroCount;
            int index = -1;

            for (int i = 0; i < rows; i++)
            {
                if (!hasZeroes[i])
                {
                    index++;

                    for (int j = 0; j < columns; j++)
                    {
                        withoutZeroMatrix[Index(index, j, columns)] = matrix[Index(i, j, columns)];
                    }
                }
            }

            return withoutZeroMatrix;
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
                    int value = _random.Next(MinValue, MaxValue);
                    matrix[i, j] = value > 0? value : 0;
                }
            }

            return matrix;
        }

        static double[] RandomOneDimensionalMatrix(int rows, int columns)
        {
            double[] matrix = new double[rows * columns];

            for (int i = 0; i < matrix.Length; i++)
            {
                int value = _random.Next(MinValue, MaxValue);
                matrix[i] = value > 0 ? value : 0;
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
