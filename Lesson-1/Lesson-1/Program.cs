using System;

namespace Lesson_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter username:");

            // получаем имя пользователя из ввода в консоли
            string userName = Convert.ToString(Console.ReadLine());

            // получаем значение текущей даты
            DateTime currenDate = DateTime.Now;

            // выводим имя пользователя и текущую дату в коротком строковом представлении
            Console.WriteLine($"Hello, {userName}, today is {currenDate.ToShortDateString()}.");
            Console.ReadLine();
        }
    }
}