using System;
using static System.Console;
using static System.Math;

namespace L1_task02
{
    class Program
    {
        static int _orderNumber = 0;

        static void Main(string[] args)
        {
            double firstTriangleArea = TriangleAreaUserInput();
            double secondTriangleArea = TriangleAreaUserInput();

            if (firstTriangleArea > secondTriangleArea)
            {
                WriteLine($"\nПлощадь 1-го треугольника максимальна = {firstTriangleArea}");
            }

            else if (secondTriangleArea > firstTriangleArea)
            {
                WriteLine($"\nПлощадь 2-го треугольника максимальна = {secondTriangleArea}");
            }

            else
            {
                WriteLine("\nПлощади обоих треугольников равны");
            }
        }

        static double TriangleAreaUserInput()
        {
            _orderNumber++;
            WriteLine($"{_orderNumber}-й треугольник:\n");

            Write("Введите длину A: ");
            double a = double.Parse(ReadLine());

            Write("Введите длину A: ");
            double b = double.Parse(ReadLine());

            Write("Введите длину A: ");
            double c = double.Parse(ReadLine());

            double area = GetTriangleArea(a, b, c);
            WriteLine($"Площадь треугольника = {area}");

            return area;
        }

        static double GetTriangleArea(double a, double b, double c)
        {
            double p = (a + b + c) / 2;
            return Sqrt(p * (p - a) * (p - b) * (p - c));
        }
    }
}
