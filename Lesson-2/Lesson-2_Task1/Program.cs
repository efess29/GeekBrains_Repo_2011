using System;
using System.Linq;

namespace Lesson_2_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Запрос минимальной и максимальной температуры (в decimal) за сутки и вывод среднего значения.

            Console.WriteLine("Enter min day temperature:");
            string minInput = Console.ReadLine();

            if (!decimal.TryParse(minInput, out decimal minTemp))
            {
                Console.WriteLine("Exception information: {0}", "Invalid min temperature value.");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("Enter max day temperature:");
            string maxInput = Console.ReadLine();

            if (!decimal.TryParse(maxInput, out decimal maxTemp))
            {
                Console.WriteLine("Exception information: {0}", "Invalid max temperature value.");
                Console.ReadLine();
                return;
            }

            decimal[] tempsArray = new decimal[] { minTemp, maxTemp };

            decimal average = tempsArray.Average();
            Console.WriteLine($"Average day temperature: {average}.");
            Console.ReadLine();
        }
    }
}
