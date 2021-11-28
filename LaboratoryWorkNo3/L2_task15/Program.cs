using System;
using static System.Console;

namespace L2_task15
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Массив A, ");
            double[] a = InputArray();

            Write("Массив B, ");
            double[] b = InputArray();

            Write("Введите K (индекс вставки массива B в A): ");
            int k = int.Parse(ReadLine());

            double[] c = InsertArrayIntoArray(a, b, k);

            WriteLine("Склеенный массив:");
            PrintArray(c);
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

        static double[] InsertArrayIntoArray(double[] baseArray, double[] insertingArray, int k)
        {
            double[] bigArray = new double[baseArray.Length + insertingArray.Length];

            for (int i = 0; i <= k; i++)
            {
                bigArray[i] = baseArray[i];
            }

            for (int i = 0; i < insertingArray.Length; i++)
            {
                bigArray[k + 1 + i] = insertingArray[i];
            }

            for (int i = k + 1; i < baseArray.Length; i++)
            {
                int index = i + insertingArray.Length;
                bigArray[index] = baseArray[i];
            }

            return bigArray;
        }
    }
}
