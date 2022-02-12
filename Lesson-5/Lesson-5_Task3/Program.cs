using System;
using System.IO;
using System.Linq;
using System.Threading;

namespace Lesson_5_Task3
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string rootPath = AppDomain.CurrentDomain.BaseDirectory;
                string fileName = "binary.bin";
                string fullPath = Path.Combine(rootPath, fileName);

                Console.Write("Enter an integer value (from 0 to 255): ");
                string stringNumbers = Console.ReadLine();
                Console.WriteLine();

                if (!String.IsNullOrEmpty(stringNumbers))
                {
                    int[] intArray = stringNumbers.Split(" ").Select(n => Convert.ToInt32(n)).ToArray();

                    Console.WriteLine($"Trying to add numbers to a \"{fileName}\" file...");
                    Console.WriteLine();
                    Thread.Sleep(1000);

                    for (int i = 0; i < intArray.Length; i++)
                    {
                        if (intArray[i] > 255 || intArray[i] < 0)
                        {
                            Console.WriteLine("Exception information: {0}", "Entered values must be from 0 to 255!");
                            Console.WriteLine($"Invalid value at \"{i + 1}\" element, value \"{intArray[i]}\".");
                            Console.ReadLine();
                            return;
                        }
                    }

                    byte[] bytes = intArray.SelectMany(BitConverter.GetBytes).ToArray();

                    Console.WriteLine("Entered values are correct...");
                    Thread.Sleep(1000);
                    Console.WriteLine($"Adding numbers to a \"{fileName}\" file...");
                    Console.WriteLine();
                    Thread.Sleep(1000);
                    File.WriteAllBytes(fullPath, bytes);
                    Console.WriteLine($"Numbers added to a \"{fileName}\" file!");
                }

                else
                {
                    Console.WriteLine("Enter some numbers!");
                    Console.ReadLine();
                    return;
                }

                Console.ReadLine();
            }

            catch (Exception e)
            {
                Console.WriteLine("Exception information: {0}", e.Message);
                Console.ReadLine();
            }
        }
    }
}
