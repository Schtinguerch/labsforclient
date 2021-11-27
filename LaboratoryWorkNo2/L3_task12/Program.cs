using System;
using static System.Console;
using static System.Math;

namespace L3_task12
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
                Write("Введите R: ");
                int r = int.Parse(ReadLine());

                Write(
                    "Выберите фигуру, площать которой требуется найти:\n" +
                    "1 - Квадрат\n" +
                    "2 - Круг\n" +
                    "3 - Равносторонний треугольник\n\n> ");

                int chosenFigure = int.Parse(ReadLine());
                double area;

                switch (chosenFigure)
                {
                    case 1:
                        area = SquareArea(r);
                        break;

                    case 2:
                        area = CircleArea(r);
                        break;

                    case 3:
                        area = TriangleArea(r);
                        break;

                    default:
                        WriteLine("Ошибка: фигуры с таким номером нет");
                        continue;
                }

                WriteLine($"Площадь = {area}");
            }
        }

        static double SquareArea(double a)
        {
            return a * a;
        }

        static double CircleArea(double a)
        {
            return PI * a * a;
        }

        static double TriangleArea(double a)
        {
            return a * a * Sqrt(3) / 4;
        }
    }
}
