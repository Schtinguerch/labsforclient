using System;
using static System.Console;

namespace L1_task13
{
    class Program
    {
        static void Main(string[] args)
        {
            //Индекс соответствует значению
            double[] baseArray = new double[10] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            double[] evenIndexArray = GetArrayWithEvenIndexes(baseArray);
            double[] notEvenIndexArray = GetArrayWithNotEvenIndexes(baseArray);

            WriteLine("Подмассив с чётными индексами:");
            PrintArray(evenIndexArray);

            WriteLine("Подмассив с нечётными индексами:");
            PrintArray(notEvenIndexArray);
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

        static double[] GetArrayWithEvenIndexes(double[] array)
        {
            double[] evenArray = new double[5];

            for (int i = 0; i < 10; i += 2)
            {
                evenArray[i / 2] = array[i];
            }

            return evenArray;
        }

        static double[] GetArrayWithNotEvenIndexes(double[] array)
        {
            double[] notEvenArray = new double[5];

            for (int i = 1; i < 10; i += 2)
            {
                notEvenArray[i / 2] = array[i];
            }

            return notEvenArray;
        }
    }
}
