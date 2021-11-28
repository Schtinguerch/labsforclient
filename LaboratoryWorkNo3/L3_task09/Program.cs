using System;
using static System.Console;
using static System.Math;

namespace L3_task09
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = InputArray();
            int orderLength = FindLongestOrder(array);

            WriteLine($"Длина самой длинной упорядоченной последовательности = {orderLength}");
        }

        static int FindLongestOrder(double[] array)
        {
            int orderLength = 1, maxOrderLength = 1;
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] >= array[i - 1])
                {
                    orderLength++;
                }

                else
                {
                    maxOrderLength = Max(orderLength, maxOrderLength); 
                    orderLength = 1;
                }
            }

            maxOrderLength = Max(orderLength, maxOrderLength);
            orderLength = 1;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] <= array[i - 1])
                {
                    orderLength++;
                }

                else
                {
                    maxOrderLength = Max(orderLength, maxOrderLength);
                    orderLength = 1;
                }
            }

            maxOrderLength = Max(orderLength, maxOrderLength);
            return maxOrderLength;
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
    }
}
