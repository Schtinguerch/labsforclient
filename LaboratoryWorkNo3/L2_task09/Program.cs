using System;
using static System.Console;

namespace L2_task09
{
    class Program
    {
        static void Main(string[] args)
        {
            const int count = 10;
            double[] array = new double[count] { 5, 7, -99, 1, 2, 3, 4, 5, 99, 6 };

            int minValueIndex = 0;
            int maxValueIndex = 0;

            for (int i = 0; i < count; i++)
            {
                if (array[i] < array[minValueIndex]) minValueIndex = i;
                if (array[i] > array[maxValueIndex]) maxValueIndex = i;
            }

            double summ = 0;
            int numCount = 0;

            for (int i = minValueIndex + 1; i < maxValueIndex; i++)
            {
                summ += array[i];
                numCount += 1;
            }

            double average = summ / numCount;
            WriteLine($"Ср. арифметическое = {average}");
        }
    }
}
