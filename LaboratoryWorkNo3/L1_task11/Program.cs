using System;
using static System.Console;

namespace L1_task11
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] allNumbers = new double[10] { 3, 4, 91, -7, 0, 18, 11, -99, 19, 0 };

            int count = 0;

            for (int i = 0; i < allNumbers.Length; i++)
                if (allNumbers[i] > 0) count++;
                
            double[] positiveNumbers = new double[count];
            int index = -1;

            for (int i = 0; i < allNumbers.Length; i++)
            {
                if (allNumbers[i] > 0)
                {
                    index++;
                    positiveNumbers[index] = allNumbers[i];
                }
            }

            for (int i = 0; i < positiveNumbers.Length; i++)
                WriteLine($"{i + 1}-й элемент = {positiveNumbers[i]}");
        }
    }
}
