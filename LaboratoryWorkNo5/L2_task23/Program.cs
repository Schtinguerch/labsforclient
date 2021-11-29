using System;
using static System.Console;

namespace L2_task23
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

            MultipleMaxAndDivideAll(ref matrix);
            PrintMatrix(matrix, "Матрица, где 5 наибольших элементов умножено на 2, а остальные - поделены на 2");
        }

        static void MultipleMaxAndDivideAll(ref double[,] matrix)
        {
            int rows = matrix.GetLength(0);
            int columns = matrix.GetLength(1);

            int[,] maxValuePositions = new int[5, 2];

            for (int k = 0; k < maxValuePositions.GetLength(0); k++)
            {
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < columns; j++)
                    {
                        if (k == 0)
                        {
                            if (matrix[i, j] > matrix[maxValuePositions[k, 0], maxValuePositions[k, 1]])
                            {
                                maxValuePositions[k, 0] = i;
                                maxValuePositions[k, 1] = j;

                                continue;
                            }
                        }

                        else if ((matrix[i, j] > matrix[maxValuePositions[k, 0], maxValuePositions[k, 1]]) &&
                            (matrix[i, j] < matrix[maxValuePositions[k - 1, 0], maxValuePositions[k - 1, 1]]))
                        {
                            maxValuePositions[k, 0] = i;
                            maxValuePositions[k, 1] = j;

                            continue;
                        }
                    }
                }
            }

            WriteLine("5 максимальных элементов: ");
            for (int i = 0; i < maxValuePositions.GetLength(0); i++)
            {
                WriteLine($"[{i}] = {matrix[maxValuePositions[i, 0], maxValuePositions[i, 1]]}");
            }
            
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    bool isOneOfMax = false;

                    for (int k = 0; k < maxValuePositions.GetLength(0); k++)
                    {
                        if ((i == maxValuePositions[k, 0]) && (j == maxValuePositions[k, 1]))
                        {
                            isOneOfMax = true;
                            break;
                        }
                    }

                    if (isOneOfMax)
                    {
                        matrix[i, j] *= 2;
                    }

                    else
                    {
                        matrix[i, j] /= 2;
                    }
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
