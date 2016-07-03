using System;

namespace _20160206_HomeWork
{
    class Program
    {
        static void Main(string[] args)
        {
            HomeWorkHelper homeWorkHelper = new HomeWorkHelper();

            try
            {
                //homeWorkHelper.PrintHelloWorld(5);
                //homeWorkHelper.Average(1, 5);
                //homeWorkHelper.ReturnNumberOfDigits(15257);
                //homeWorkHelper.WriteNumberRange(45);
                //homeWorkHelper.IsNumberNegative(-10);
                //homeWorkHelper.PlaySound(6);
                //homeWorkHelper.FlipAbsForNumber(-10);
                //homeWorkHelper.ReturnAbsForNumber(-22);
                //homeWorkHelper.IsNumberCanBeDividedByNumber(3, 1);
                //homeWorkHelper.ReturnRandomNumberForRange();
                //homeWorkHelper.ShowDivisionResult(3, 2);
                //homeWorkHelper.ReturnModuloForNumbers(5, 4);
            }
            catch (Exception ignored)
            {
                Console.WriteLine("General exception occured!\nCause: {0}", ignored.Message);
            }
            
            Console.WriteLine("\nPress any key to quit...");
            Console.ReadKey();
        }
    }
}
