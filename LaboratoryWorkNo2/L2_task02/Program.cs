using System;
using static System.Console;
using static System.Math;

namespace L2_task02
{
    class Program
    {
        static void Main(string[] args)
        {
            GetPointsInsideCircle();
        }

        static void GetPointsInsideCircle()
        {
            WriteLine("Введите коодинаты центра круга: ");

            Write("X = ");
            double circleCenterX = double.Parse(ReadLine());

            Write("Y = ");
            double circleCenterY = double.Parse(ReadLine());

            Write("Введите радиус круга: ");
            double circleRadius = double.Parse(ReadLine());

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

                bool isInsideCircle = IsInsideCircle(circleRadius, circleCenterX, circleCenterY, x, y);
                WriteLine($"Точка ({x}, {y}) {IntoRussian(isInsideCircle)}");

                if (isInsideCircle)
                    suitPointCount++;
            }

            WriteLine($"{suitPointCount} точек попадает в круг");
        }

        static bool IsInsideCircle(double circleRadius, double centerX, double centerY, double x, double y)
        {
            double xArgument = Pow(x - centerX, 2);
            double yArgument = Pow(y - centerY, 2);

            bool isInsideCircle = xArgument + yArgument <= Pow(circleRadius, 2);
            return isInsideCircle;
        }

        static string IntoRussian(bool isInsideCircle)
        {
            if (isInsideCircle)
            {
                return "попадает в круг";
            }
            else
            {
                return "НЕ попадает в круг";
            }
        }
    }
}
