using System;

namespace Lesson_2_Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            // Запрос порядкового номера месяца и вывод его наименования
            try
            {
                Console.WriteLine("Enter a month number (without 0):");
                string inputNumber = Console.ReadLine();

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

                string[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
                string msg = $"Entered month number: {selectedMonth}.";

                switch (selectedMonth)
                {
                    case 1:
                        {
                            Console.WriteLine(msg + " It's: " + months[0] + ".");
                            Console.ReadLine();
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine(msg + " It's: " + months[1] + ".");
                            Console.ReadLine();
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine(msg + " It's: " + months[2] + ".");
                            Console.ReadLine();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine(msg + " It's: " + months[3] + ".");
                            Console.ReadLine();
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine(msg + " It's: " + months[4] + ".");
                            Console.ReadLine();
                            break;
                        }
                    case 6:
                        {
                            Console.WriteLine(msg + " It's: " + months[5] + ".");
                            Console.ReadLine();
                            break;
                        }
                    case 7:
                        {
                            Console.WriteLine(msg + " It's: " + months[6] + ".");
                            Console.ReadLine();
                            break;
                        }
                    case 8:
                        {
                            Console.WriteLine(msg + " It's: " + months[7] + ".");
                            Console.ReadLine();
                            break;
                        }
                    case 9:
                        {
                            Console.WriteLine(msg + " It's: " + months[8] + ".");
                            Console.ReadLine();
                            break;
                        }
                    case 10:
                        {
                            Console.WriteLine(msg + " It's: " + months[9] + ".");
                            Console.ReadLine();
                            break;
                        }
                    case 11:
                        {
                            Console.WriteLine(msg + " It's: " + months[10] + ".");
                            Console.ReadLine();
                            break;
                        }
                    case 12:
                        {
                            Console.WriteLine(msg + " It's: " + months[11] + ".");
                            Console.ReadLine();
                            break;
                        }
                }
            }
            
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
