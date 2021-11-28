using System;
using static System.Console;

namespace L3_task13
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = InputArray();
            double[] withoutDuplicates = DeleteDuplicates(array);

            WriteLine("Массив без повторяющихся элементов:");
            PrintArray(withoutDuplicates);
        }

        static double[] DeleteDuplicates(double[] array)
        {
            int differentItemsCount = 0;

            for (int i = 0; i < array.Length; i++)
            {
                bool hasDuplicates = false;
                for (int j = 0; j < i; j++)
                {
                    if (array[i] == array[j])
                    {
                        hasDuplicates = true;
                        break;
                    }
                }

                if (!hasDuplicates)
                {
                    differentItemsCount++;
                }
            }

            double[] uniqueItems = new double[differentItemsCount];
            int index = -1;

            for (int i = 0; i < array.Length; i++)
            {
                bool hasDuplicates = false;
                for (int j = 0; j < i; j++)
                {
                    if (array[i] == array[j])
                    {
                        hasDuplicates = true;
                        break;
                    }
                }

                if (!hasDuplicates)
                {
                    index++;
                    uniqueItems[index] = array[i];
                }
            }

            return uniqueItems;
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
