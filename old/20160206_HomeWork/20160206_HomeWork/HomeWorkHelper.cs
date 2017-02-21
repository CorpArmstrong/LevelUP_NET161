using System;

namespace _20160206_HomeWork
{
    /// <summary>
    /// This is homework helper.
    /// Most of numbers are integers for simplicity.
    /// </summary>
    class HomeWorkHelper
    {
        public void PrintHelloWorld(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Console.WriteLine("Hello, world!");
            }
        }

        public void Average(int num1, int num2)
        {
            Console.WriteLine("The average for {0} and {1} is {2}.", num1, num2, (num1 + num2) / 2);
        }

        public void ReturnNumberOfDigits(int num)
        {
            int digitsCounter = 0;
            int tempNumber = num;
            bool isEnded = false;

            while (!isEnded)
            {
                if ((tempNumber / 10) >= 0 && (tempNumber % 10) > 0)
                {
                    tempNumber /= 10;
                    digitsCounter++;
                }
                else
                {
                    isEnded = true;
                }
            }

            Console.WriteLine("The number of digits for number {0} is {1}", num, digitsCounter);
        }

        public void WriteNumberRange(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Console.Write(i + " ");
            }
        }

        public bool IsNumberNegative(int num)
        {
            bool isNegativeNumber = false;

            if (num == 0)
            {
                Console.WriteLine("The number '{0}' is zero.", num);
                return false;
            }

            if (num < 0)
            {
                isNegativeNumber = true;
            }

            Console.WriteLine("The number '{0}' negative? {1}", num, isNegativeNumber);

            return isNegativeNumber;
        }

        public void PlaySound(int num)
        {
            for (int i = 0; i < num; i++)
            {
                Console.Beep();
            }
        }

        public void FlipAbsForNumber(int num)
        {
            if (num <= 0)
            {
                Console.WriteLine(Math.Abs(num));
            }

            if (num > 0)
            {
                Console.WriteLine(num *= -1);
            }
        }

        public int ReturnAbsForNumber(int num)
        {
            int absNum = Math.Abs(num);
            Console.WriteLine("Abs for number '{0}' is '{1}'.", num, absNum);
            return absNum;
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

        public int ReturnRandomNumberForRange()
        {
            Random random = new Random();
            int result = random.Next(1, 13);
            Console.WriteLine("Random number for range from '{0}' to '{1}' is '{2}'.", 1, 13, result);
            return result;
        }

        public void ShowDivisionResult(int num1, int num2)
        {
            if (num2 != 0)
            {
                Console.WriteLine("Division result for numbers: '{0}' and '{1}' is {2}.", num1, num2, ((float)num1 / num2));
            }
            else
            {
                throw new Exception("Divide by zero error!\nCheck your data!");
            }
        }

        public int ReturnModuloForNumbers(int num1, int num2)
        {
            int result = 0;

            if (num1 == num2 && num1 == 0)
            {
                Console.WriteLine("Modulo for numbers: '{0}' and '{1}' is '{2}'.", num1, num2, 0);
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

            Console.WriteLine("Modulo for numbers: '{0}' and '{1}' is '{2}'.", num1, num2, result);
            return result;
        }
    }
}
