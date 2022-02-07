using System;

namespace Lesson_4_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter user's first name: ");
            string firstName = Console.ReadLine();
            Console.WriteLine("\t");

            Console.WriteLine("Enter user's last name: ");
            string lastName = Console.ReadLine();
            Console.WriteLine("\t");

            Console.WriteLine("Enter user's patronymic name: ");
            string patronymic = Console.ReadLine();
            Console.WriteLine("\t");

            string fullName = GetFullName(firstName, lastName, patronymic);

            Console.WriteLine($"Entered full name is: {fullName}.");
            Console.ReadLine();
        }

        static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return lastName + " " + firstName + " " + patronymic;
        }
    }
}
