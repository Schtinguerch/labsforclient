using System;
using static System.Console;

namespace L3_task01
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = InputArray();
            double[] maxValueIndexes = GetMaxValueIndexArray(array);

            WriteLine("Массив индексов с максимальными значениями массива:");
            PrintArray(maxValueIndexes);
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

        static double[] GetMaxValueIndexArray(double[] array)
        {
            if (array.Length == 0)
            {
                return array;
            }

            int maxValueIndex = 0;
            int maxValueCount = 1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == array[maxValueIndex])
                {
                    maxValueCount++;
                }

                if (array[i] > array[maxValueIndex])
                {
                    maxValueIndex = i;
                    maxValueCount = 1;
                }
            }

            double[] maxValueIndexes = new double[maxValueCount];
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == array[maxValueIndex])
                {
                    index++;
                    maxValueIndexes[index] = i;
                }
            }

            return maxValueIndexes;
        }
    }
}
