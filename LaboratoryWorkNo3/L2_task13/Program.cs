using System;
using static System.Console;

namespace L2_task13
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = InputArray();
            double[] swappedArray = SwapMaxEvenAndIndex(array);

            WriteLine("Новый массив:");
            PrintArray(swappedArray);
        }

        static double[] SwapMaxEvenAndIndex(double[] array)
        {
            int maxIndex = 0;
            for (int i = 0; i < array.Length; i += 2)
            {
                if (array[i] > array[maxIndex])
                {
                    maxIndex = i;
                }
            }

            WriteLine($"Замена A[{maxIndex}] = {array[maxIndex]} На индекс = {maxIndex}");
            array[maxIndex] = maxIndex;
            return array;
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
