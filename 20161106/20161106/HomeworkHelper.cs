using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20161106
{
    class HomeWorkHelper
    {
        public void PrintHelloWorld()
        {
            int num = 0;

            string entryString = "Enter number of repeats for 'Hello, World': ";
            string helloString = "Hello, world!";
            string inputString;

            do
            {
                ConsoleGraphicsUtils.DrawHeader('#', entryString.Length);
                ConsoleGraphicsUtils.DrawColoredText(entryString, ConsoleColor.Yellow);
                inputString = Console.ReadLine();
            }
            while (!int.TryParse(inputString, out num));

            ConsoleGraphicsUtils.DrawHeader('#', entryString.Length);
            ConsoleGraphicsUtils.DrawFrame(helloString, 2, '*', ConsoleColor.Cyan, num);
        }

        public void Average()
        {
            int num1, num2;
            string entryStr1 = "Enter the first number: ";
            string entryStr2 = "Enter the second number: ";
            string inputString;

            do
            {
                ConsoleGraphicsUtils.DrawHeader('#', entryStr1.Length);
                ConsoleGraphicsUtils.DrawColoredText(entryStr1, ConsoleColor.Yellow);
                inputString = Console.ReadLine();
            }
            while(!int.TryParse(inputString, out num1));

            do
            {
                ConsoleGraphicsUtils.DrawHeader('#', entryStr2.Length);
                ConsoleGraphicsUtils.DrawColoredText(entryStr2, ConsoleColor.Yellow);
                inputString = Console.ReadLine();
            }
            while (!int.TryParse(inputString, out num2));

            string outString = String.Format("The average for {0} and {1} is {2}.", num1, num2, (num1 + num2) / 2);
            ConsoleGraphicsUtils.DrawHeader('#', entryStr1.Length);
            ConsoleGraphicsUtils.DrawFrame(outString, 2, '*', ConsoleColor.Cyan);
        }

        public void ReturnNumberOfDigits()
        {
            int num = 0;
            int digitsCounter = 0;
            string entryString = "Enter number for count: ";
            string inputString;

            do
            {
                ConsoleGraphicsUtils.DrawHeader('#', entryString.Length);
                ConsoleGraphicsUtils.DrawColoredText(entryString, ConsoleColor.Yellow);
                inputString = Console.ReadLine();
            }
            while (!int.TryParse(inputString, out num));

            int tempNumber = num;

            while ((tempNumber / 10) >= 0 && (tempNumber % 10) > 0)
            {
                tempNumber /= 10;
                digitsCounter++;
            }

            string outString = String.Format("The number of digits for number {0} is {1}", num, digitsCounter);
           
            ConsoleGraphicsUtils.DrawHeader('#', entryString.Length);
            ConsoleGraphicsUtils.DrawFrame(outString, 2, '*', ConsoleColor.Cyan);
            Console.WriteLine();
        }

        public void WriteNumberRange()
        {
            int num = 0;
            string entryString = "Enter number for count range: ";
            string inputString;

            do
            {
                ConsoleGraphicsUtils.DrawHeader('#', entryString.Length);
                ConsoleGraphicsUtils.DrawColoredText(entryString, ConsoleColor.Yellow);
                inputString = Console.ReadLine();
            }
            while (!int.TryParse(inputString, out num));

            ConsoleGraphicsUtils.DrawHeader('#', entryString.Length);

            for (int i = 0; i < num; i++)
            {
                ConsoleGraphicsUtils.DrawColoredText(Convert.ToString(i) + " ", ConsoleColor.Cyan);
            }
            Console.WriteLine();
        }

        public bool IsNumberNegative()
        {
            bool isNegativeNumber = false;

            int num = 0;
            string entryString = "Enter number for sign check: ";
            string inputString;

            do
            {
                ConsoleGraphicsUtils.DrawHeader('#', entryString.Length);
                ConsoleGraphicsUtils.DrawColoredText(entryString, ConsoleColor.Yellow);
                inputString = Console.ReadLine();
            }
            while (!int.TryParse(inputString, out num));

            ConsoleGraphicsUtils.DrawHeader('#', entryString.Length);

            if (num == 0)
            {
                ConsoleGraphicsUtils.DrawFrame(String.Format("The number '{0}' is zero.", num), 2, '*', ConsoleColor.Cyan);
                return false;
            }

            if (num < 0)
            {
                isNegativeNumber = true;
            }

            string outString = String.Format("The number '{0}' negative? {1}", num, isNegativeNumber);
            ConsoleGraphicsUtils.DrawFrame(outString, 2, '*', ConsoleColor.Cyan);

            return isNegativeNumber;
        }

        public void PlaySound()
        {
            int num = 0;
            string entryString = "Enter number of repeats for beep: ";
            string inputString;

            do
            {
                ConsoleGraphicsUtils.DrawHeader('#', entryString.Length);
                ConsoleGraphicsUtils.DrawColoredText(entryString, ConsoleColor.Yellow);
                inputString = Console.ReadLine();
            }
            while (!int.TryParse(inputString, out num));

            ConsoleGraphicsUtils.DrawHeader('#', entryString.Length);
            
            for (int i = 0; i < num; i++)
            {
                Console.Beep();
            }
            Console.WriteLine();
        }

        public void FlipAbsForNumber()
        {
            int num = 0;
            string entryString = "Enter number to flip Abs: ";
            string inputString;

            do
            {
                ConsoleGraphicsUtils.DrawHeader('#', entryString.Length);
                ConsoleGraphicsUtils.DrawColoredText(entryString, ConsoleColor.Yellow);
                inputString = Console.ReadLine();
            }
            while (!int.TryParse(inputString, out num));

            if (num <= 0)
            {
                ConsoleGraphicsUtils.DrawColoredText(Convert.ToString(Math.Abs(num)), ConsoleColor.Cyan);
            }

            if (num > 0)
            {
                ConsoleGraphicsUtils.DrawColoredText(Convert.ToString(num *= -1), ConsoleColor.Cyan);
            }

            Console.WriteLine();
        }

        public void ReturnAbsForNumber()
        {
            int num = 0;
            string entryString = "Enter number to perform Abs: ";
            string inputString;

            do
            {
                ConsoleGraphicsUtils.DrawHeader('#', entryString.Length);
                ConsoleGraphicsUtils.DrawColoredText(entryString, ConsoleColor.Yellow);
                inputString = Console.ReadLine();
            }
            while (!int.TryParse(inputString, out num));

            ConsoleGraphicsUtils.DrawHeader('#', entryString.Length);

            int absNum = Math.Abs(num);
            string outString = String.Format("Abs for number '{0}' is '{1}'.", num, absNum);
            ConsoleGraphicsUtils.DrawFrame(outString, 2, '*', ConsoleColor.Cyan);
        }

        public bool IsNumberCanBeDividedByNumber(int num1, int num2)
        {
            bool result = false;

            if (num2 != 0)
            {
                result = num1 / num2 > 0;
                Console.WriteLine("The number '{0}' can be divided by number '{1}'? {2}.", num1, num2, result);
            }
            else
            {
                throw new Exception("Division by zero error!\nCheck your data!");
            }

            return result;
        }

        public void ReturnRandomNumberForRange()
        {
            Random random = new Random();
            int result = random.Next(1, 13);
            string outString = String.Format("Random number for range from '{0}' to '{1}' is '{2}'.", 1, 13, result);
            ConsoleGraphicsUtils.DrawFrame(outString, 2, '#', ConsoleColor.Cyan);
        }

        public void ShowDivisionResult()
        {
            int num1, num2;
            string entryStr1 = "Enter the first number: ";
            string entryStr2 = "Enter the second number: ";
            string inputString;

            do
            {
                ConsoleGraphicsUtils.DrawHeader('#', entryStr1.Length);
                ConsoleGraphicsUtils.DrawColoredText(entryStr1, ConsoleColor.Yellow);
                inputString = Console.ReadLine();
            }
            while (!int.TryParse(inputString, out num1));

            do
            {
                ConsoleGraphicsUtils.DrawHeader('#', entryStr2.Length);
                ConsoleGraphicsUtils.DrawColoredText(entryStr2, ConsoleColor.Yellow);
                inputString = Console.ReadLine();
            }
            while (!int.TryParse(inputString, out num2));

            ConsoleGraphicsUtils.DrawHeader('#', entryStr2.Length);

            if (num2 != 0)
            {
                string outString = String.Format("Division result for numbers: '{0}' and '{1}' is {2}.", num1, num2, (1.0 * num1 / num2));
                ConsoleGraphicsUtils.DrawFrame(outString, 2, '*', ConsoleColor.Cyan);
            }
            else
            {
                throw new Exception("Divide by zero error!\nCheck your data!");
            }
        }

        public int ReturnModuloForNumbers()
        {
            int result = 0;

            int num1, num2;
            string entryStr1 = "Enter the first number: ";
            string entryStr2 = "Enter the second number: ";
            string inputString;
            string outString;

            do
            {
                ConsoleGraphicsUtils.DrawHeader('#', entryStr1.Length);
                ConsoleGraphicsUtils.DrawColoredText(entryStr1, ConsoleColor.Yellow);
                inputString = Console.ReadLine();
            }
            while (!int.TryParse(inputString, out num1));

            do
            {
                ConsoleGraphicsUtils.DrawHeader('#', entryStr2.Length);
                ConsoleGraphicsUtils.DrawColoredText(entryStr2, ConsoleColor.Yellow);
                inputString = Console.ReadLine();
            }
            while (!int.TryParse(inputString, out num2));

            ConsoleGraphicsUtils.DrawHeader('#', entryStr2.Length);

            if (num1 == num2 && num1 == 0)
            {
                outString = String.Format("Modulo for numbers: '{0}' and '{1}' is '{2}'.", num1, num2, 0);
                ConsoleGraphicsUtils.DrawFrame(outString, 2, '*', ConsoleColor.Cyan);
                return 0;
            }

            if (num1 > num2)
            {
                if (num2 != 0)
                {
                    result = num1 % num2;
                }
                else
                {
                    throw new Exception("Divide by zero error!\nCheck your data!");
                }
            }

            if (num2 > num1)
            {
                if (num1 != 0)
                {
                    result = num2 % num1;
                }
                else
                {
                    throw new Exception("Divide by zero error!\nCheck your data!");
                }
            }

            outString = String.Format("Modulo for numbers: '{0}' and '{1}' is '{2}'.", num1, num2, result);
            ConsoleGraphicsUtils.DrawFrame(outString, 2, '*', ConsoleColor.Cyan);
            return result;
        }
    }
}
