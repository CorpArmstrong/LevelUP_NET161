using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20161906_Homework
{
    class Program
    {
        public void SwapThreeVariables()
        {
            int a = 2;
            int b = 4;
            int c = 7;

            Console.WriteLine("Initial values: a = {0}, b = {1}, c = {2}.", a, b, c);

            c = a + b + c;
            a = c - a - b;
            b = c - a - b;
            c = c - a - b;

            Console.WriteLine("Swapped values: a = {0}, b = {1}, c = {2}.", a, b, c);
        }

        public void FindMinMaxNumber()
        {
            string inputString = null;

            int num1, num2, num3, num4;

            do
            {
                Console.Write("Enter number for num1: ");
                inputString = Console.ReadLine();
            }
            while (!int.TryParse(inputString, out num1));

            do
            {
                Console.Write("Enter number for num2: ");
                inputString = Console.ReadLine();
            }
            while (!int.TryParse(inputString, out num2));

            do
            {
                Console.Write("Enter number for num3: ");
                inputString = Console.ReadLine();
            }
            while (!int.TryParse(inputString, out num3));

            do
            {
                Console.Write("Enter number for num4: ");
                inputString = Console.ReadLine();
            }
            while (!int.TryParse(inputString, out num4));

            // Find max value:
            if (num1 > num2 && num1 > num3 && num1 > num4)
            {
                Console.WriteLine("Min value is: num1 = {0}", num1);
            }
            else
            {
                if (num2 > num1 && num2 > num3 && num2 > num4)
                {
                    Console.WriteLine("Min value is: num2 = {0}", num2);
                }
                else
                {
                    if (num3 > num1 && num3 > num2 && num3 > num4)
                    {
                        Console.WriteLine("Min value is: num3 = {0}", num3);
                    }
                    else
                    {
                        Console.WriteLine("Min value is: num4 = {0}", num4);
                    }
                }
            }

            // Find min value:
            if (num1 < num2 && num1 < num3 && num1 < num4)
            {
                Console.WriteLine("Min value is: num1 = {0}", num1);
            }
            else
            {
                if (num2 < num1 && num2 < num3 && num2 < num4)
                {
                    Console.WriteLine("Min value is: num2 = {0}", num2);
                }
                else
                {
                    if (num3 < num1 && num3 < num2 && num3 < num4)
                    {
                        Console.WriteLine("Min value is: num3 = {0}", num3);
                    }
                    else
                    {
                        Console.WriteLine("Min value is: num4 = {0}", num4);
                    }
                }
            }
        }

        public void ShowNumberOfWeek()
        {
            string inputString = null;
            int dayOfWeek = -1;

            do
            {
                Console.WriteLine("Enter day of week as a number: ");
                inputString = Console.ReadLine();
            }
            while (!int.TryParse(inputString, out dayOfWeek));

            switch (dayOfWeek)
            {
                case 1:
                    Console.WriteLine("MONDAY");
                    break;
                case 2:
                    Console.WriteLine("TUESDAY");
                    break;
                case 3:
                    Console.WriteLine("WEDNESDAY");
                    break;
                case 4:
                    Console.WriteLine("THURSDAY");
                    break;
                case 5:
                    Console.WriteLine("FRIDAY");
                    break;
                case 6:
                    Console.WriteLine("SATURDAY");
                    break;
                case 7:
                    Console.WriteLine("SUNDAY");
                    break;
                default:
                    Console.WriteLine("Incorrect number! There is not such day in a week!");
                    break;
            }
        }

        static void Main(string[] args)
        {
            Program prg = new Program();
            
            prg.SwapThreeVariables();
            prg.FindMinMaxNumber();
            prg.ShowNumberOfWeek();

            Console.ReadKey();
        }
    }
}
