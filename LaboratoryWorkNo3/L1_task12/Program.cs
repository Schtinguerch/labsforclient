using System;
using static System.Console;

namespace L1_task12
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = new double[10] { 7, 8, -90, 25, 9, 12, -6, 11, 24, 0 };
            PrintArray(numbers);

            int index = GetLastNegativeIndex(numbers);

            if (index == -1)
            {
                WriteLine("В массиве нет отрицательных чисел");
            }

            else
            {
                WriteLine("Последнее отрицательное число найдено:");
                WriteLine($"Индекс = {index} (он же {index + 1}-й элемент); значение = {numbers[index]}");
            }
        }

        static int GetLastNegativeIndex(double[] numbers)
        {
            for (int i = numbers.Length - 1; i >= 0; i--)
            {
                if (numbers[i] < 0)
                {
                    return i;
                }
            }

            return -1;
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
