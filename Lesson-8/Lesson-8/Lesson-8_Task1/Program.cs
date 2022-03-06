using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson_8_Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string greeting = Properties.Settings.Default.Greeting;

                Console.WriteLine(greeting);
                Console.WriteLine();

                Console.Write("User name: ");
                Console.WriteLine(Properties.Settings.Default.UserName);
                Console.Write("User age: ");
                Console.WriteLine(Properties.Settings.Default.UserAge);
                Console.Write("User occupation: ");
                Console.WriteLine(Properties.Settings.Default.UserOccupation);
                Console.WriteLine();

                Console.Write("Please, enter your name: ");
                Properties.Settings.Default.UserName = Console.ReadLine();


                Console.Write("Please, enter your age: ");
                Properties.Settings.Default.UserAge = Convert.ToInt32(Console.ReadLine());

                Console.Write("Please, enter your occupation: ");
                Properties.Settings.Default.UserOccupation = Console.ReadLine();

                Properties.Settings.Default.Save();

                Console.ReadLine();
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }
            
        }
    }
}
