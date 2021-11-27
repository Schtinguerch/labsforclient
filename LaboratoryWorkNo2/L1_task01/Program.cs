using System;
using static System.Console;
using static System.Math;

namespace L1_task01
{
    class Program
    {
        static void Main(string[] args)
        {
            double radius = 2d;

            WriteLine($"Точка (0, 2) {IntoRussian(IsOnCircle(radius, 0, 2))} на окружности");
            WriteLine($"Точка (1.5, 0.7) {IntoRussian(IsOnCircle(radius, 1.5, 0.7))} на окружности");
            WriteLine($"Точка (1, 1) {IntoRussian(IsOnCircle(radius, 1, 1))} на окружности");
            WriteLine($"Точка (3, 0) {IntoRussian(IsOnCircle(radius, 3, 0))} на окружности");
        }

        static bool IsOnCircle(double circleRadius, double x, double y)
        {
            bool isOnCircle = Abs(x * x + y * y - circleRadius * circleRadius) <= 0.001;
            return isOnCircle;
        }

        static string IntoRussian(bool isOnCircle)
        {
            if (isOnCircle)
            {
                return "Лежит";
            }
            else
            {
                return "НЕ лежит";
            }
        }
    }
}
