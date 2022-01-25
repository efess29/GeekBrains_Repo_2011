using System;
using System.Linq;

namespace Lesson_2_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Choose an option: 1 - calculate avg with array and loop, 2 - calculate avg with LYNQ-expression.");
            string type = Convert.ToString(Console.ReadLine());

            Console.WriteLine("Enter min day temperature:");
            decimal minTemp = decimal.Parse(Console.ReadLine());

            Console.WriteLine("Enter max day temperature:");
            decimal maxTemp = decimal.Parse(Console.ReadLine());

            decimal[] tempsArray = new decimal[] { minTemp, maxTemp };

            switch (type)
            {
                // Подсчет сред. значения через массив и цикл
                case "1":
                {
                    decimal summ = 0;
                    
                    for (int i = 0; i < tempsArray.Length; i++)
                        summ += tempsArray[i];
                    decimal avg = summ / tempsArray.Length;
                    
                    Console.WriteLine($"Average day temperature: {avg}.");
                    Console.ReadLine();
                    
                    break;
                }

                // Подсчет сред. значения через lynq-выражение
                case "2":
                {
                    try
                    {
                    decimal average = tempsArray.Average();
                    Console.WriteLine($"Average day temperature: {average}.");
                    }
                
                    catch
                    {
                        Console.WriteLine("One of the temperatures is null!");
                    }
                
                    Console.ReadLine();
                
                    break;
                }
            }
        }
    }
}
