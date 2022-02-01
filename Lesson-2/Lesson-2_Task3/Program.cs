using System;

namespace Lesson_2_Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Проверка числа на четность

            Console.WriteLine("Enter integer value:");

            string integerInput = Console.ReadLine();

            if (!int.TryParse(integerInput, out int value))
            {
                Console.WriteLine("Exception information: {0}", "Entered value is invalid.");
                Console.ReadLine();
                return;
            }

            if ((value & 1) == 0 || (value % 2) == 0)
            {
                Console.WriteLine($"Entered value {value} is even.");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine($"Entered value {value} is odd.");
                Console.ReadLine();
            }
        }
    }
}
