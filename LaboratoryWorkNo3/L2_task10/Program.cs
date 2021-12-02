using System;
using static System.Console;
namespace L2_task10
{
    class Program
    {
        static void Main(string[] args)
        {
            const int count = 12;
            double[] array = new double[count] { -5, -9, 2, 7, 5, 4, -9, -1, 6, 8, 3, -8 };

            WriteLine("Базовый массив:");
            for (int i = 0; i < count; i++)
                WriteLine($"[{i}] = {array[i]}");

            int minPositiveIndex = -1;
            for (int i = 0; i < count; i++)
                if (array[i] > 0)
                    if ((minPositiveIndex == -1) || array[i] < array[minPositiveIndex])
                        minPositiveIndex = i;

            for (int i = minPositiveIndex; i < count - 1; i++)
                array[i] = array[i + 1];

            array[count - 1] = 0;
            WriteLine("\nМассив без мин. поз. числа:");
            for (int i = 0; i < count - 1; i++)
                WriteLine($"[{i}] = {array[i]}");
        }
    }
}
