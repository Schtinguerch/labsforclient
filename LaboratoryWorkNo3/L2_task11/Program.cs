using System;
using static System.Console;
namespace L2_task11
{
    class Program
    {
        static void Main(string[] args)
        {
            const int count = 10;
            double[] array = new double[count] { 4, 6, 5, -7, 9, 1, 4, -6, -1, 0};
            for (int i = 0; i < count - 1; i++)
                WriteLine($"[{i}] = {array[i]}");

            Write("Введите число P, которое необходимо включить в массив: ");
            double p = double.Parse(ReadLine());

            int index = -1;
            for (int i = count -1; i >= 0; i--)
                if (array[i] > 0) { index = i; break; }
            
            for (int i = count -2; i > index; i--)
                array[i + 1] = array[i];

            array[index + 1] = p;

            WriteLine("\nМассив с включённым P:");
            for (int i = 0; i < count; i++)
                WriteLine($"[{i}] = {array[i]}");
        }
    }
}
