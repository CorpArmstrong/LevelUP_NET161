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
                Console.WriteLine("To check for Double num - type DLB");
                Console.WriteLine("To setup range for Integer - type SINT");
                Console.WriteLine("To setup range for Double - type SDLB");
                Console.WriteLine("To show restricted symbols - type RES");
                Console.WriteLine("To add restricted symbol - type ADD");
                Console.Write("To quit - type QUIT\n\n--> ");
                
                userInput = Console.ReadLine().ToUpper();

                switch (userInput)
                {
                    case "INT":
                        Console.Write("Enter integer number: ");
                        numberParser.ParseItegerForRange(Console.ReadLine());
                        break;
                    case "DLB":
                        Console.Write("Enter double number: ");
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
                        Console.Write("Enter restricted symbol to be added: ");
                        numberParser.AddRestrictedSymbol(Console.ReadLine());
                        break;
                    case "QUIT":
                        isQuit = true;
                        Console.WriteLine("\nGoodbye!!!");
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

            Console.WriteLine("...");
            Console.ReadKey();
        }
    }
}
