using System;
using static System.Console;

namespace L3_task04
{
    class Program
    {
        static void Main(string[] args)
        {
            GetPointsInsideRing();
        }

        static void GetPointsInsideRing()
        {
            Write("Введите внутренний радиус кольца: ");
            double insideRingRadius = double.Parse(ReadLine());

            Write("Введите внешний радиус кольца: ");
            double outsideRingRadius = double.Parse(ReadLine());

            Write("Введите кол-во точек: ");
            int pointCount = int.Parse(ReadLine());
            int suitPointCount = 0;
            
            for (int i = 0; i < pointCount; i++)
            {
                WriteLine($"{1}-я точка:");

                Write("X = ");
                double x = double.Parse(ReadLine());

                Write("Y = ");
                double y = double.Parse(ReadLine());

                bool isInRing = IsInRing(insideRingRadius, outsideRingRadius, x, y);
                WriteLine($"Точка ({x}, {y}) {IntoRussian(isInRing)}");

                if (isInRing)
                    suitPointCount++;
            }

            WriteLine($"{suitPointCount} точек попадает в кольцо");
        }

        static bool IsInRing(double insideRadius, double outsideRadius, double x, double y)
        {
            bool isInRing = 
                IsInsideCircle(outsideRadius, x, y) && 
                !IsInsideCircle(insideRadius, x, y);

            return isInRing;
        }

        static bool IsInsideCircle(double circleRadius, double x, double y)
        {
            bool isOnCircle = x * x + y * y <= circleRadius * circleRadius;
            return isOnCircle;
        }

        static string IntoRussian(bool isInsideCircle)
        {
            if (isInsideCircle)
            {
                return "попадает в кольцо";
            }
            else
            {
                return "НЕ попадает в кольцо";
            }
        }
    }
}
