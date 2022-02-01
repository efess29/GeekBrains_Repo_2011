using System;

namespace Lesson_2_Task6
{
    class Program
    {
        [Flags]
        public enum Weekdays
        {
            Monday = 0b_0000001,
            Tuesday = 0b_0000010,
            Wednesday = 0b_0000100,
            Thursday = 0b_0001000,
            Friday = 0b_0010000,
            Saturday = 0b_0100000,
            Sunday = 0b_1000000,
        }

        static void Main(string[] args)
        {
            Console.Write("Enter an office number: ");

            string integerNumber = Console.ReadLine();

            if (!int.TryParse(integerNumber, out int number))
            {
                Console.WriteLine("Exception information: {0}", "Entered value is invalid.");
                Console.ReadLine();
                return;
            }
            Console.Write("\n");

            // Расписание офисов
            Weekdays workingDaysOffice1 = Weekdays.Monday | Weekdays.Wednesday | Weekdays.Friday;
            Weekdays workingDaysOffice2 = Weekdays.Monday | Weekdays.Tuesday;
            Weekdays workingDaysOffice3 = Weekdays.Saturday | Weekdays.Sunday;

            switch (number)
            {
                case 1:
                    Console.WriteLine($"Working days for office {number} are: {workingDaysOffice1}.");
                    Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine($"Working days for office {number} are: {workingDaysOffice2}.");
                    Console.ReadLine();
                    break;
                case 3:
                    Console.WriteLine($"Working days for office {number} are: {workingDaysOffice3}.");
                    Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Enter a correct office number!");
                    Console.ReadLine();
                    break;
            }
        }
    }
}
