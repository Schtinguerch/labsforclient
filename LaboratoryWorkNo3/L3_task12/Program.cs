using System;
using static System.Console;

namespace L3_task12
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = InputArray();
            double[] withoutNegativeArray = DeleteNegativeNumbers(array);

            Write("Массив без отрицательных элементов:");
            PrintArray(withoutNegativeArray);
        }

        static double[] DeleteNegativeNumbers(double[] array)
        {
            int negativeCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    negativeCount++;
                }
            }

            if (negativeCount == 0)
            {
                WriteLine("В массиве нет отрицательных чисел");
                return array;
            }

            double[] withoutNegative = new double[array.Length - negativeCount];
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] >= 0)
                {
                    index++;
                    withoutNegative[index] = array[i];
                }
            }

            return withoutNegative;
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
