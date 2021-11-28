using System;
using static System.Console;

namespace L3_task08
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = InputArray();
            double[] sortedArray = SortNegativeNumbers(array);

            WriteLine("Массив с упорядоченными отрицательными элементами:");
            PrintArray(sortedArray);
        }

        static double[] SortNegativeNumbers(double[] array)
        {
            int negativeNumberCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    negativeNumberCount++;
                }   
            }

            if (negativeNumberCount == 0)
            {
                WriteLine("В массиве нет отрицательных чисел");
                return array;
            }

            int[] negativeNumberIndexes = new int[negativeNumberCount];
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < 0)
                {
                    index++;
                    negativeNumberIndexes[index] = i;
                }
            }

            for (int i = 0; i < negativeNumberIndexes.Length; i += 1)
            {
                for (int j = 0; j < negativeNumberIndexes.Length - 1; j++)
                {
                    if (array[negativeNumberIndexes[j]] > array[negativeNumberIndexes[j + 1]])
                    {
                        double temp = array[negativeNumberIndexes[j + 1]];
                        array[negativeNumberIndexes[j + 1]] = array[negativeNumberIndexes[j]];
                        array[negativeNumberIndexes[j]] = temp;
                    }
                }
            }

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
