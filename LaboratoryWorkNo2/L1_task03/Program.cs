using System;
using static System.Console;

namespace L1_task03
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Введите a: ");
            int a = int.Parse(ReadLine());

            Write("Введите b: ");
            int b = int.Parse(ReadLine());

            WriteLine("Ответ: " + GetMinOrMax(a, b).ToString());
        }
        
        static int GetMinOrMax(int a, int b)
        {
            if (a > 0)
            {
                if (a > b)
                    return a;
                else
                    return b;
            }
            else
            {
                if (a < b)
                    return a;
                else
                    return b;
            }
        }
    }
}
