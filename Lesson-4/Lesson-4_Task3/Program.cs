using System;

namespace Lesson_4_Task3
{
    class Program
    {
        /// <summary>
        /// Представляет перечисление для времен год
        /// </summary>
        [Flags]
        public enum Seasons
        {
            Winter = 1,
            Spring = 2,
            Summer = 3,
            Fall = 4,
            InvalidSeason = 5
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter a month number: ");
            string month = Console.ReadLine();
            Console.WriteLine("\n");

            if (!int.TryParse(month, out int number))
            {
                Console.WriteLine("Exception information: {0}", "Invalid month number - not an int value.");
                Console.ReadLine();
                return;
            }

            if (number < 1 || number > 12)
            {
                Console.WriteLine("Exception information: {0}", "Invalid month number - should be from 1 to 12.");
                Console.ReadLine();
                return;
            }

            Seasons seasonNameEnum = DetermineSeasonEnum(number);
            string seasonName = DetermineSeasonString(seasonNameEnum);

            Console.WriteLine($"Entered month number is: {number}. Season's name is: {seasonName}.");
            Console.ReadLine();
        }

        /// <summary>
        /// Представляет метод определения времени года по введенному номеру месяца
        /// </summary>
        /// <param name="monthNumber"></param>
        /// <returns></returns>
        static Seasons DetermineSeasonEnum(int monthNumber)
        {
            switch (monthNumber)
            {
                case 12: case 1: case 2:
                    return Seasons.Winter;

                case 3: case 4: case 5:
                    return Seasons.Spring;
                
                case 6: case 7: case 8:
                    return Seasons.Summer;
                
                case 9: case 10: case 11:
                    return Seasons.Fall;
                
                default:
                    Console.WriteLine("Enter a month number.");
                    Console.ReadLine();
                    break;
            }

            return Seasons.InvalidSeason;
        }

        /// <summary>
        /// Представляет метод вывода времени года в текстовом виде из входящего Enum перечисления 
        /// </summary>
        /// <param name="season"></param>
        /// <returns></returns>
        static string DetermineSeasonString(Seasons season)
        {
            Seasons currentSeason = season;

            switch (currentSeason)
            {
                case Seasons.Winter:
                    return "Winter";
                case Seasons.Spring:
                    return "Spring";
                case Seasons.Summer:
                    return "Summer";
                case Seasons.Fall:
                    return "Fall";
                default:
                    Console.WriteLine("Season is invalid or null.");
                    Console.ReadLine();
                    break;
            }

            return "";
        }
    }
}