using System;
using static System.Console;

namespace L2_task10
{
    class Program
    {
        static Random _random = new Random();
        const int MinValue = -30;
        const int MaxValue = 30;

        static void Main(string[] args)
        {
            var matrix = RandomUserMatrix();
            PrintMatrix(matrix, "Сформированная матрица:");

            RemoveMinMaxColumns(ref matrix);
            PrintMatrix(matrix, "Матрица без 2-х столбцов:");
        }

        static void RemoveMinMaxColumns(ref double[,] matrix)
        {
            int maxValueColumn = ColumnMaxValueUnderDiagonal(matrix);
            int minValueColumn = ColumnMinValueAboveDiagonal(matrix);

            RemoveColumnAt(ref matrix, maxValueColumn);
            
            if (maxValueColumn > minValueColumn)
            {
                RemoveColumnAt(ref matrix, minValueColumn);
            }
            else if (maxValueColumn < minValueColumn)
            {
                RemoveColumnAt(ref matrix, minValueColumn - 1);
            }
        }

        static int ColumnMaxValueUnderDiagonal(double[,] matrix)
        {
            int sideLength = matrix.GetLength(0);

            double maxValue = matrix[1, 0];
            int maxValueColumn = 1;

            for (int i = 0; i < sideLength; i++)
            {
                for (int j = 0; j + i < sideLength; j++)
                {
                    if (matrix[j, j + i] > maxValue)
                    {
                        maxValue = matrix[j + i, j];
                        maxValueColumn = j;
                    }
                }
            }

            WriteLine($"Столбец с максимальным значением под диагональю = {maxValueColumn + 1}");
            return maxValueColumn;
        }

        static int ColumnMinValueAboveDiagonal(double[,] matrix)
        {
            int sideLength = matrix.GetLength(0);

            double minValue = matrix[0, 1];
            int minValueColumn = 1;

            for (int i = 1; i < sideLength; i++)
            {
                for (int j = 0; j + i < sideLength; j++)
                {
                    if (matrix[j, j + i] < minValue)
                    {
                        minValue = matrix[j, j + i];
                        minValueColumn = j + i;
                    }
                }
            }

            WriteLine($"Столбец с минимальным значением над диагональю = {minValueColumn + 1}");
            return minValueColumn;
        }

        static void RemoveColumnAt(ref double[,] matrix, int columnPosition)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            var smallerMatrix = new double[rows, columns - 1];

            for (int i = 0; i < rows; i++)
            {
                int offset = 0;

                for (int j = 0; j < columns; j++)
                {
                    if (j == columnPosition)
                    {
                        offset++;
                        continue;
                    }

                    smallerMatrix[i, j - offset] = matrix[i, j];
                }
            }

            matrix = smallerMatrix;
        }

        static double[,] RandomUserMatrix()
        {
            Write("Введите кол-во строк и столбцов: ");
            int rows = int.Parse(ReadLine());

            return RandomMatrix(rows, rows);
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
