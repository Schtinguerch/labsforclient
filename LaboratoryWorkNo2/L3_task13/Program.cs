using System;
using static System.Console;
using static System.Math;

namespace L3_task13
{
    class Program
    {
        static void Main(string[] args)
        {
            GetFigureAreas();
        }

        static void GetFigureAreas()
        {
            Write("Введите кол-во фигур: ");
            int figureCount = int.Parse(ReadLine());

            for (int i = 0; i < figureCount; i++)
            {
                Write("Введите A: ");
                int a = int.Parse(ReadLine());

                Write("Введите B: ");
                int b = int.Parse(ReadLine());

                Write(
                    "Выберите фигуру, площать которой требуется найти:\n" +
                    "1 - Прямоугольник\n" +
                    "2 - Кольцо\n" +
                    "3 - Равнобедренный треугольник\n\n> ");

                int chosenFigure = int.Parse(ReadLine());
                double area;

                switch (chosenFigure)
                {
                    case 1:
                        area = RectangleArea(a, b);
                        break;

                    case 2:
                        area = RingArea(a, b);
                        break;

                    case 3:
                        area = TriangleArea(a, b);
                        break;

                    default:
                        WriteLine("Ошибка: фигуры с таким номером нет");
                        continue;
                }

                WriteLine($"Площадь = {area}");
            }
        }

        static double RectangleArea(double a, double b)
        {
            return a * b;
        }

        static double RingArea(double a, double b)
        {
            return Abs(PI * (a * a - b * b));
        }

        static double TriangleArea(double a, double b)
        {
            double p = (a + b + b) / 2;
            return Sqrt(p * (p - a) * (p - b) * (p - b));
        }
    }
}
