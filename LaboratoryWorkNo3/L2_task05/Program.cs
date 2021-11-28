using System;
using static System.Console;

namespace L2_task05
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] startArray = InputArray();
            double[] necessaryArray = FindNegativeBetweenMinMax(startArray);

            WriteLine("Массив из отриц. элементов между мин. и макс. элементами:");
            PrintArray(necessaryArray);
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

        static double[] FindNegativeBetweenMinMax(double[] array)
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
            for (int i = minValueIndex + 1; i < maxValueIndex; i++)
            {
                if (array[i] < 0)
                {
                    count++;
                }
            }

            double[] negativeNumbers = new double[count];
            int index = -1;

            for (int i = minValueIndex + 1; i < maxValueIndex; i++)
            {
                if (array[i] < 0)
                {
                    index++;
                    negativeNumbers[index] = array[i];
                }
            }

            return negativeNumbers;
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
    }
}
