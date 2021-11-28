using System;
using static System.Console;

namespace L1_task10
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = new double[10] { 3, 8, 9, 4, 0, 12, 6, 15, 29, 1 };
            PrintArray(array);

            Write("Введите значение P: ");
            double p = double.Parse(ReadLine());

            Write("Введите значение Q: ");
            double q = double.Parse(ReadLine());

            int count = CountOfElementsBetween(array, p, q);
            WriteLine($"Кол-во элементов между {p} и {q} = {count}");
        }

        static int CountOfElementsBetween(double[] array, double p, double q)
        {
            int count = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] > p && array[i] < q)
                {
                    count++;
                }
            }

            return count;
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
