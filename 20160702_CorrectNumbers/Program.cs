using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160702_CorrectNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            NumberParser numberParser = new NumberParser();

            string userInput = string.Empty;
            bool isQuit = false;

            do
	        {
                Console.Clear();
                Console.WriteLine("To check for Integer num - type INT");
                Console.WriteLine("To check for Integer num - type DLB");
                Console.WriteLine("To setup range for Integer - type SINT");
                Console.WriteLine("To setup range for Double - type SDLB");
                Console.WriteLine("To show restricted symbols - type RES");
                Console.WriteLine("To add restricted symbol - type ADD");
                Console.WriteLine("To quit - type QUIT");
                
                userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "INT":
                        numberParser.ParseItegerForRange(Console.ReadLine());
                        break;
                    case "DLB":
                        numberParser.ParseDoubleForRange(Console.ReadLine());
                        break;
                    case "SINT":
                        numberParser.SetupRangeForInteger();
                        break;
                    case "SDLB":
                        numberParser.SetupRangeForDouble();
                        break;
                    case "RES":
                        numberParser.ShowRestrictedSymbols();
                        break;
                    case "ADD":
                        numberParser.AddRestrictedSymbol(Console.ReadLine());
                        break;
                    case "QUIT":
                        isQuit = true;
                        Console.WriteLine("Goodbye!!!");
                        break;
                    default:
                        Console.WriteLine("Incorrect command! Try again!");
                        break;
                }
                
                if (!isQuit)
                {
                    Console.ReadKey();
                }
                
	        }
            while (!isQuit);

            Console.WriteLine("Good Luck!");
            Console.ReadKey();
        }
    }
}
