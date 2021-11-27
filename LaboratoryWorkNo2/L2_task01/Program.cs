using System;
using static System.Console;

namespace L2_task01
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAverageAge();
        }

        static void GetAverageAge()
        {
            Write("Введите кол-во учеников: ");
            int studentCount = int.Parse(ReadLine());

            int ageSum = 0;

            for (int i = 0; i < studentCount; i++)
            {
                Write($"Возраст {i + 1}-го ученика: ");
                ageSum += int.Parse(ReadLine());
            }

            double averageAge = (double) ageSum / studentCount;
            WriteLine($"Средний возраст учеников = {averageAge} лет.");
        }
    }
}
