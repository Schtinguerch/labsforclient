using System;
using static System.Console;

namespace L3_task05
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = InputArray();
            double[] sortedArray = SortEvenIndexes(array);

            WriteLine("Массив с упорядоченными чётными индексами:");
            PrintArray(sortedArray);
        }

        static double[] SortEvenIndexes(double[] array)
        {
            for (int i = 0; i < array.Length; i += 2)
            {
                for (int j = 0; j < array.Length - 2; j++)
                {
                    if (((array.Length - j) >= 2) && (array[j] > array[j + 2]))
                    {
                        double temp = array[j + 2];
                        array[j + 2] = array[j];
                        array[j] = temp;
                    }
                }
            }

            return array;
        }

        static double[] InputArray()
        {
            Write("Введите размер массива: ");
            int itemCount = int.Parse(ReadLine());

            double[] array = new double[itemCount];

            WriteLine($"Введите {itemCount} элементов массива:");

            for (int i = 0; i < itemCount; i++)
            {
                Write($"элемент [{i}]: ");
                array[i] = double.Parse(ReadLine());
            }

            return array;
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
