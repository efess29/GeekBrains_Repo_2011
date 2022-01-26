using System;
using System.Linq;

namespace Lesson_2_Task5
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ввод мин. и макс. температуры за сутки

            #region Avg temperature
            Console.WriteLine("Enter min day temperature:");
            string minInput = Console.ReadLine();
            Console.WriteLine("\n");

            if (!decimal.TryParse(minInput, out decimal minTemp))
            {
                Console.WriteLine("Exception information: {0}", "Invalid min temperature value.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Enter max day temperature:");
            string maxInput = Console.ReadLine();
            Console.WriteLine("\n");

            if (!decimal.TryParse(maxInput, out decimal maxTemp))
            {
                Console.WriteLine("Exception information: {0}", "Invalid max temperature value.");
                Console.ReadLine();
                return;
            }
            #endregion

            // Ввод порядкового номера месяца

            #region Month Number
            Console.WriteLine("Enter a month number (without 0):");
            string inputNumber = Console.ReadLine();
            Console.WriteLine("\n");

            if (!int.TryParse(inputNumber, out int selectedMonth))
            {
                Console.WriteLine("Exception information: {0}", "Selected month number is invalid.");
                Console.ReadLine();
                return;
            }

            if (selectedMonth > 12 || selectedMonth < 1)
            {
                Console.WriteLine("Exception information: {0}", "Selected month must be in 1 to 12 interval.");
                Console.ReadLine();
                return;
            }
            #endregion

            decimal averageTemp = CalcHelper.CountAvg(minTemp, maxTemp);
            bool isWinter = CalcHelper.FindIsWinter(selectedMonth);

            Console.WriteLine($"Average temperature: {averageTemp} C, winter month: {isWinter}.");

            if (averageTemp > 0 && isWinter)
            {
                Console.WriteLine("It's a rainy winter.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("It's not a rainy winter.");
                Console.ReadLine();
            }
        }
    }
}
