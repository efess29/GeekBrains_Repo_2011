using System;
using System.Linq;

namespace Lesson_2_Task5
{
    class CalcHelper
    {
        // Возвращает среднесуточную температуру в decimal
        public static decimal CountAvg(decimal min, decimal max)
        {
            decimal[] tempsArray = new decimal[] { min, max };
            decimal average = tempsArray.Average();
            
            return average;
        }
        
        // Возвращает true, если месяц = зимний
        public static bool FindIsWinter(int month)
        {
            bool isWinter = false;
        
            switch (month)
            {
                case int m when (m == 12 || m <= 2):
                    isWinter = true;
                    break;
            }
        
            return isWinter;
        }
    }
}
