using System;
using static System.Console;
using static System.Math;

namespace L2_task06
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = InputArray();

            Write("Введите число P, которое необходимо вставить в массив: ");
            double p = double.Parse(ReadLine());

            double[] newNumbers =  InsertNearestToAverage(numbers, p);

            WriteLine("Новый массив:");
            PrintArray(newNumbers);
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

        static double[] InsertNearestToAverage(double[] numbers, double p)
        {
            double averageValue = 0;
            double elementSum = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                elementSum += numbers[i];
            }

            averageValue = elementSum / numbers.Length;
            int nearestToAverageIndex = 0;

            for (int i = 0; i < numbers.Length; i++)
            {
                if (Abs(numbers[i] - averageValue) < Abs(numbers[nearestToAverageIndex] - averageValue))
                {
                    nearestToAverageIndex = i;
                }
            }

            double[] newNumbers = new double[numbers.Length + 1];

            for (int i = 0; i <= nearestToAverageIndex; i++)
            {
                newNumbers[i] = numbers[i];
            }

            //Вставка числа P после числа наиболее близкого к среднему арифметическому
            newNumbers[nearestToAverageIndex + 1] = p;

            for (int i = nearestToAverageIndex + 1; i < numbers.Length; i++)
            {
                newNumbers[i + 1] = numbers[i];
            }

            return newNumbers;
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
