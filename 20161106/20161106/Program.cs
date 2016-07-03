using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20161106
{
    class Program
    {
        static void Main(string[] args)
        {
            ConsoleMenu consoleMenu = new ConsoleMenu();
            HomeWorkHelper homeWorkHelper = new HomeWorkHelper();

            try
            {
                //homeWorkHelper.PrintHelloWorld();
                //homeWorkHelper.Average();
                //homeWorkHelper.ReturnNumberOfDigits();
                //homeWorkHelper.WriteNumberRange();
                //homeWorkHelper.IsNumberNegative();
                //homeWorkHelper.PlaySound();
                //homeWorkHelper.FlipAbsForNumber();
                //homeWorkHelper.ReturnAbsForNumber();
                //-homeWorkHelper.IsNumberCanBeDividedByNumber(3, 1);
                //homeWorkHelper.ReturnRandomNumberForRange();
                //homeWorkHelper.ShowDivisionResult();
                //-homeWorkHelper.ReturnModuloForNumbers(5, 4);
            }
            catch (Exception ignored)
            {
                Console.WriteLine("General exception occured!\nCause: {0}", ignored.Message);
            }

            ConsoleGraphicsUtils.DrawColoredText("\nPress any key to quit...", ConsoleColor.Red);
            Console.ReadKey();
        }
    }
}
