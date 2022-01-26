using System;

namespace Lesson_2_Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Main info
            string welcome = "WELCOME!";
            string thx = "THANK YOU FOR BUYING!";
            DateTime dt = DateTime.Today;
            string currentDate = dt.ToShortDateString();
            #endregion

            #region Seller info
            string shopName = "OOO IMPERIYA";
            string inn = "00745434554";
            string cashier = "IVANOV I.I";
            string address = "ul. Baumana, d. 21";
            #endregion

            #region Goods info
            string item1 = "Kotleta";
            decimal amountItem1 = 90.50m;
            string item2 = "Lavash";
            decimal amountItem2 = 20.0m;
            string item3 = "Okroshka";
            decimal amountItem3 = 55.0m;

            decimal[] itemsArray = new decimal[] { amountItem1, amountItem2, amountItem3 };
            #endregion

            #region Separators
            string singleSeparator = "--------------------------";
            string doubleSeparator = "==========================";
            string lowerSeparator = "_________";
            #endregion

            Console.WriteLine($"|        {shopName}        |");
            Console.WriteLine($"|      INN: {inn}      |");
            Console.WriteLine($"|     {address}     |");
            Console.WriteLine($"| {singleSeparator} |");
            Console.WriteLine($"|         {welcome}           |");
            Console.WriteLine($"| {singleSeparator} |");
            Console.WriteLine($"|    {cashier}  {currentDate}  |");
            Console.WriteLine($"| {doubleSeparator} |");
            Console.WriteLine($"| 1. {item1} {lowerSeparator} {amountItem1} |");
            Console.WriteLine($"| 2. {item2} {lowerSeparator}   {amountItem2} |");
            Console.WriteLine($"| 3. {item3} {lowerSeparator} {amountItem3} |");
            Console.WriteLine($"| {doubleSeparator} |");
            Console.WriteLine($"| SUMMARY           = {countSumm(itemsArray)} |");
            Console.WriteLine($"| {doubleSeparator} |");
            Console.WriteLine($"|    {thx}   |");
            Console.WriteLine($"| {singleSeparator} |");

            Console.ReadLine();

            // Метод подсчета суммы элементов массива товаров
            decimal countSumm(decimal[] array)
            {
                decimal sum = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    sum += array[i];
                }

                return sum;
            }
        }
    }
}
