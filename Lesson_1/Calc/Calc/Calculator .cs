using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
    static class Calculator
    {
        public static double Add(double num1, double num2)
        {
            return num1 + num2;
        }

        public static double Subtract(double num1, double num2)
        {
            return num1 - num2;
        }

        public static double Multiply(double num1, double num2)
        {
            return num1 * num2;
        }

        public static double Divide(double num1, double num2)
        {
            if (num2 != 0)
                return num1 / num2;
            else
            {
                Console.WriteLine("Error: Division by zero is not allowed.");
                return double.NaN;
            }
        }

        public static double FindSquareRoot(double num)
        {
            if (num >= 0)
                return Math.Sqrt(num);
            else
            {
                Console.WriteLine("Error: Cannot calculate the square root of a negative number.");
                return double.NaN;
            }
        }

        public static double FindSquare(double num)
        {
            return num * num;
        }

        public static double RankToPower(double num1, double num2)
        {
            return Math.Pow(num1, num2);
        }


        public static double FindPercent(double baseValue, double percentValue)
        {
            // validation that we have percents in range 1:100
            if (percentValue < 0 || percentValue > 100)
            {
                Console.WriteLine("Error: Percent value should be between 0 and 100.");
                return double.NaN;
            }

            return (baseValue * percentValue) / 100;
        }
    }
}
