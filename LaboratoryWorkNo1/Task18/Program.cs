using System;
using static System.Console;

namespace Task18
{
    class Program
    {
        static void Main(string[] args)
        {
            ShowAmoebaCount(10);
        }

        static void ShowAmoebaCount(int startCount)
        {
            int elapsedHours = 0;
            WriteLine("0ч: " + startCount);

            long totalCount = startCount;
            while (elapsedHours < 24)
            {
                elapsedHours += 3;
                totalCount *= 2;

                WriteLine(elapsedHours + "ч: " + totalCount);
            }
        }
    }
}
