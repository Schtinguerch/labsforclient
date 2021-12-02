using System;
using static System.Console;

namespace L2_task15
{
    class Program
    {
        static void Main(string[] args)
        {
            const int n = 6, m = 4;
            double[] a = new double[n] { 1, 2, 3, 4, 5, 6 };
            double[] b = new double[m] { 111, 222, 333, 444 };

            WriteLine("Массив A:");
            for (int i = 0; i < n; i++) WriteLine($"[{i}] = {a[i]}");

            WriteLine("\nМассив B:");
            for (int i = 0; i < m; i++) WriteLine($"[{i}] = {b[i]}");

            Write("\nВведите K (индекс вставки массива B в A): ");
            int k = int.Parse(ReadLine());

            double[] c = new double[n + m];

            for (int i = 0; i <= k; i++) c[i] = a[i];
            for (int i = 0; i < b.Length; i++) c[k + 1 + i] = b[i];

            for (int i = k + 1; i < a.Length; i++)
            {
                int index = i + b.Length;
                c[index] = a[i];
            }

            WriteLine("Единый массив:");
            for (int i = 0; i < n + m; i++) WriteLine($"[{i}] = {c[i]}");
        }
    }
}
