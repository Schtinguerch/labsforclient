using System;
using static System.Console;

namespace L1_task10
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] array = new double[10] { 3, 8, 9, 4, 0, 12, 6, 15, 29, 1 };

            for (int i = 0; i < array.Length; i++)
                WriteLine($"{i + 1}-й элемент = {array[i]}");

            Write("Введите значение P: ");
            double p = double.Parse(ReadLine());

            Write("Введите значение Q: ");
            double q = double.Parse(ReadLine());

            int count = 0;

            for (int i = 0; i < array.Length; i++)
                if (array[i] > p && array[i] < q) count++;

            WriteLine($"Кол-во чисел между P и Q = {count}");
        }
    }
}
