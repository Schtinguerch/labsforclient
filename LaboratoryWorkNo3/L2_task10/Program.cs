using System;
using static System.Console;
namespace L2_task10
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] numbers = InputArray();
            double[] necessaryNumbers = EraseMinPositive(numbers);

            WriteLine("Массив без минимального положительного элемента:");
            PrintArray(necessaryNumbers);
        }

        static double[] EraseMinPositive(double[] array)
        {
            int positiveNumberIndex = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > 0)
                {
                    positiveNumberIndex = i;
                    break;
                }
            }

            if (positiveNumberIndex == -1)
            {
                WriteLine("Положительных элементов нет");
                return array;
            }

            int minPositiveIndex = positiveNumberIndex;

            for (int i = minPositiveIndex; i < array.Length; i++)
            {
                if ((array[i] > 0) && (array[i] < array[minPositiveIndex]))
                {
                    minPositiveIndex = i;
                }
            }

            double[] newArray = new double[array.Length - 1];

            for (int i = 0; i < minPositiveIndex; i++)
            {
                newArray[i] = array[i];
            }

            for (int i = minPositiveIndex + 1; i < array.Length; i++)
            {
                newArray[i - 1] = array[i];
            }

            return newArray;
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
    }
}
