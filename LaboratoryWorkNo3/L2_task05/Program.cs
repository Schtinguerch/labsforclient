using System;
using static System.Console;

namespace L2_task05
{
    class Program
    {
        static void Main(string[] args)
        {
            const int count = 12;
            double[] array = new double[count] { 2, -99, 8, 4, -5, 9, -13, -7, 99, 10, 11, 5 };

            WriteLine("Исходный массив: ");
            for (int i = 0; i < array.Length; i++)
                WriteLine($"[{i}] = {array[i]}");

            int minValueIndex = 0;
            int maxValueIndex = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < array[minValueIndex]) minValueIndex = i;
                if (array[i] > array[maxValueIndex]) maxValueIndex = i;
            }

            int negativeCount = 0;
            for (int i = minValueIndex + 1; i < maxValueIndex; i++)
                if (array[i] < 0) negativeCount++;

            double[] negativeNumbers = new double[negativeCount];
            int index = -1;

            for (int i = minValueIndex + 1; i < maxValueIndex; i++)
                if (array[i] < 0) negativeNumbers[++index] = array[i];

            WriteLine("\nМассив с отриц. числами: ");
            for (int i = 0; i < negativeCount; i++)
                WriteLine($"[{i}] = {negativeNumbers[i]}");
        }
    }
}
