using System;
using static System.Console;

namespace L1_task02
{
    class Program
    {
        static void Main(string[] args)
        {
            Write("Введите x: ");
            double x = double.Parse(ReadLine());

            Write("Введите y: ");
            double y = double.Parse(ReadLine());

            bool isInsideTriangle = IsInsileTriangle(x, y);
            WriteLine($"Точка ({x}, {y}) находится {IntoRussian(isInsideTriangle)} треугольника");
        }

        static bool IsInsileTriangle(double x, double y)
        {
            bool isUnderLeftEdge = y <= 1 + x;
            bool isUnderRightEdge = y <= 1 - x;
            bool isAboveAbcissa = y >= 0;

            return isUnderLeftEdge && isUnderRightEdge && isAboveAbcissa;
        }

        static string IntoRussian(bool isOnCircle)
        {
            if (isOnCircle)
            {
                return "внутри";
            }
            else
            {
                return "ВНЕ";
            }
        }
    }
}
