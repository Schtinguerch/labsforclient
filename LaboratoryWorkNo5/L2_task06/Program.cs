using System;
using static System.Console;

namespace L2_task06
{
    class Program
    {
        static Random _random = new Random();
        const int MinValue = -30;
        const int MaxValue = 30;

        static void Main(string[] args)
        {
            var a = RandomArray(7);
            PrintArray(a, "Массив А:");

            var b = RandomArray(8);
            PrintArray(b, "Массив B:");

            MergeArrays(ref a, ref b);
            PrintArray(a, "Объеденённые массивы в A:");
        }

        static void MergeArrays(ref double[] destination, ref double[] source)
        {
            RemoveMaxValue(ref destination);
            RemoveMaxValue(ref source);

            var mergedArray = new double[destination.Length + source.Length]; 

            for (int i = 0; i < mergedArray.Length; i++)
            {
                if (i >= destination.Length)
                {
                    mergedArray[i] = source[i - destination.Length];
                }

                else
                {
                    mergedArray[i] = destination[i];
                }
            }

            destination = mergedArray;
            source = new double[] { };
        }

        static void RemoveMaxValue(ref double[] array)
        {
            RemoveAt(ref array, MaxPosition(array));
        }

        static void RemoveAt(ref double[] array, int position)
        {
            var smallerArray = new double[array.Length - 1];
            int offset = 0;

            for (int i = 0; i < array.Length; i++)
            {
                if (i == position)
                {
                    offset++;
                    continue;
                }

                smallerArray[i - offset] = array[i];
            }

            array = smallerArray;
        }

        static int MaxPosition(double[] array)
        {
            int maxValuePosition = 0;

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > array[maxValuePosition])
                {
                    maxValuePosition = i;
                }
            }

            return maxValuePosition;
        }

        static double[] RandomArray(int itemCount)
        {
            var array = new double[itemCount];

            for (int i = 0; i < itemCount; i++)
            {
                array[i] = _random.Next(MinValue, MaxValue);
            }

            return array;
        }

        static void PrintArray(double[] array, string startMessage = "")
        {
            if (startMessage != "")
            {
                WriteLine(startMessage);
            }

            if (array.Length == 0)
            {
                WriteLine("* Массив пустой *");
            }

            else
            {
                WriteLine($"Массив из {array.Length} элементов:");

                for (int i = 0; i < array.Length; i++)
                {
                    WriteLine($"[{i}] = {array[i]}");
                }
            }
        }
    }
}
