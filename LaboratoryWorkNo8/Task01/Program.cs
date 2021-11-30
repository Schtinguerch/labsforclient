using System;
using static System.Console;

namespace Task01
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Введите текст, с которым будет производиться работа:");
            var text = ReadLine();

            Write("Введите символ, который нужно найти: ");
            char character = char.Parse(ReadLine());

            double percentage = EntryPercentage(text, character);
            WriteLine("\n" + ConvertToMessage(percentage));
        }

        static double EntryPercentage(string text, char character)
        {
            int entryCount = 0;

            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == character)
                {
                    entryCount++;
                }
            }

            double percentage = (double) entryCount / text.Length;
            return percentage;
        }

        static string ConvertToMessage(double percentage)
        {
            if (percentage == 0)
            {
                return "* Символ не найден *";
            }

            return $"Символ состявляет {(percentage * 100):N2}% от всего текста";
        } 
    }
}
