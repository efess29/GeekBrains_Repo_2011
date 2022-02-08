using System;

namespace Lesson_4_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter numbers with space splitter: ");
            string sourceString = Console.ReadLine();
            int result = FindSum(sourceString);

            Console.WriteLine();
            Console.WriteLine($"Source string is: {sourceString}.\nSum of all number in source string is: {result}.");
            Console.ReadLine();
        }

        /// <summary>
        /// Представляет метод для подсчета суммы всех найденных чисел в строке
        /// </summary>
        /// <param name = "s"></param>
        /// <returns></returns>
        static int FindSum(string s)
        {
            string tempString = "0";
            int sum = 0;
            try
            {
                for (int i = 0; i < s.Length; i++)
                {
                    char currentSymbol = s[i];

                    if (char.IsDigit(currentSymbol))
                    {
                        tempString += currentSymbol;
                    }
                    else
                    {
                        sum += int.Parse(tempString);
                        tempString = "0";
                    }
                }

                return sum + int.Parse(tempString);
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e.Message.ToString());
            }

            return 0;
        } 
    }
}
