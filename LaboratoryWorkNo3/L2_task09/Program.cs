using System;
using static System.Console;

namespace L2_task09
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = InputArray();
            double averageBetweenMinMax = FindAverageBetweenMinMax(numbers);

            WriteLine($"Среднее арифметическое между мин. и макс. элементами массива = {averageBetweenMinMax}");
        }

        static double[] InputArray()
        {
            Write("Введите размер массива: ");
            int itemCount = int.Parse(ReadLine());

            double[] array = new double[itemCount];

            WriteLine($"Введите {itemCount} элементов массива:");

            for (int i = 0; i < itemCount; i++)
            {
                Write($"{i + 1}-й элемент: ");
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
                    WriteLine($"{i + 1}-й элемент = {array[i]}");
                }
            }
        }

        static double FindAverageBetweenMinMax(double[] array)
        {
            int minValueIndex = GetMinValueIndex(array);
            int maxValueIndex = GetMaxValueIndex(array);

            if (minValueIndex > maxValueIndex)
            {
                int temp = minValueIndex;
                minValueIndex = maxValueIndex;
                maxValueIndex = temp;
            }

            int count = 0;
            double elementSum = 0;

            for (int i = minValueIndex + 1; i < maxValueIndex; i++)
            {
                count++;
                elementSum += array[i];
            }

            double average = elementSum / count;
            return average;
        }

        static int GetMinValueIndex(double[] array)
        {
            int minValueIndex = 0;
            double minValue = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < minValue)
                {
                    minValue = array[i];
                    minValueIndex = i;
                }
            }

            return minValueIndex;
        }

        static int GetMaxValueIndex(double[] array)
        {
            int maxValueIndex = 0;
            double maxValue = array[0];

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > maxValue)
                {
                    maxValue = array[i];
                    maxValueIndex = i;
                }
            }

            return maxValueIndex;
        }
    }
}
