using System;
using static System.Console;
namespace L2_task11
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = InputArray();

            Write("Введите число P, которое необходимо вставить в массив: ");
            double p = double.Parse(ReadLine());

            double[] newArray = InsertAfterLastPositive(array, p);

            WriteLine("Новый массив:");
            PrintArray(newArray);
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

        static double[] InsertAfterLastPositive(double[] array, double p)
        {
            int lastPositiveIndex = GetLastPositiveIndex(array);

            if (lastPositiveIndex == -1)
            {
                WriteLine("В массиве нет положительных чисел");
                return array;
            }

            double[] biggerArray = new double[array.Length + 1];

            for (int i = 0; i <= lastPositiveIndex; i++)
            {
                biggerArray[i] = array[i];
            }

            biggerArray[lastPositiveIndex + 1] = p;

            for (int i = lastPositiveIndex + 1; i < array.Length; i++)
            {
                biggerArray[i + 1] = array[i];
            }

            return biggerArray;
        }

        static int GetLastPositiveIndex(double[] array)
        {
            int index = -1;
            
            for (int i = array.Length - 1; i > 0; i--)
            {
                if (array[i] > 0)
                {
                    index = i;
                    break;
                }
            }

            return index;
        }
    }
}
