using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160702_CorrectNumbers
{
    public class NumberParser
    {
        private string restrictedSymbols = "!@#$%^&*()_+={}[]\\|:;\"'<>/`~";

        private int intMinValue = 0;
        private int intMaxValue = 0;

        private double doubleMinValue = 0.00;
        private double doubleMaxValue = 0.00;

        public bool ParseItegerForRange(string inputNumber)
        {
            bool isParsed = false;
            int number = 0;

            if ((intMaxValue == 0) && (intMinValue == 0))
            {
                intMinValue = int.MinValue;
                intMaxValue = int.MaxValue;
            }

            if (!IsRestrictedSymbol(inputNumber))
            {
                if (int.TryParse(inputNumber, out number))
                {
                    if (number >= intMinValue && number <= intMaxValue)
                    {
                        isParsed = true;
                        Logger.ShowMsg(string.Format("Number {0} parsed successfully!", number));
                     //   Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Number {0} must be in a range from {1} to {2} !", number, intMinValue, intMaxValue);
                    }
                }
                else
                {
                    if (intMinValue == int.MinValue && intMaxValue == int.MaxValue)
                    {
                        Console.WriteLine("Number {0} is not an integer number!", inputNumber);
                    }
                    else
                    {
                        Console.WriteLine(inputNumber + " - is not a number!");
                    }
                }
            }
            else
            {
                Console.WriteLine("Symbol {0} is restricted!", inputNumber);
            }

            return isParsed;
        }

        public bool ParseDoubleForRange(string inputNumber)
        {
            bool isParsed = false;
            double number = 0.00;

            if ((doubleMaxValue == 0.00) && (doubleMinValue == 0.00))
            {
                doubleMinValue = double.MinValue;
                doubleMaxValue = double.MaxValue;
            }

            if (!IsRestrictedSymbol(inputNumber))
            {
                if (double.TryParse(inputNumber, out number))
                {
                    if (number >= doubleMinValue && number <= doubleMaxValue)
                    {
                        isParsed = true;
                        Console.WriteLine("Number {0} parsed successfully!", number);
                    }
                    else
                    {
                        Console.WriteLine("Number {0} must be in a range from {1} to {2} !", number, doubleMinValue, doubleMaxValue);
                    }
                }
                else
                {
                    if (doubleMinValue == double.MinValue && doubleMaxValue == double.MaxValue)
                    {
                        Console.WriteLine("Number {0} is not an double number!", inputNumber);
                    }
                    else
                    {
                        Console.WriteLine(inputNumber + " - is not a number!");
                    }
                }
            }
            else
            {
                Console.WriteLine("Symbol {0} is restricted!", inputNumber);
            }

            return isParsed;
        }

        public void SetupRangeForInteger()
        {
            bool isParsed = false;
            string userInput = string.Empty;

            // Range From
            do
            {
                Console.Clear();
                Console.WriteLine("Enter range from: ");
                userInput = Console.ReadLine();

                if (!IsRestrictedSymbol(userInput))
                {
                    if (int.TryParse(userInput, out intMinValue))
                    {
                        Console.WriteLine("Number {0} added as minimum for int.", intMinValue);
                        isParsed = true;
                    }
                    else
                    {
                        Console.WriteLine("The symbol {0} is not a valid number!", userInput);
                    }
                }
                else
                {
                    Console.WriteLine("Number {0} is a restricted symbol!", userInput);    
                    Console.WriteLine("Restricted symbols: " + restrictedSymbols);
                }
            }
            while (!isParsed);

            isParsed = false;

            // Range To
            do
            {
                Console.Clear();
                Console.WriteLine("Enter range To: ");
                userInput = Console.ReadLine();

                if (!IsRestrictedSymbol(userInput))
                {
                    if (int.TryParse(userInput, out intMaxValue))
                    {
                        if (intMaxValue > intMinValue)
                        {
                            Console.WriteLine("Number {0} added as maximum for int.", intMaxValue);
                            isParsed = true;
                        }
                        else
                        {
                            Console.WriteLine("Number {0} must be greater than a minimum number {1} !", intMaxValue, intMinValue);
                        }
                    }
                    else
                    {
                        Console.WriteLine("The symbol {0} is not a valid number!", userInput);
                    }
                }
                else
                {
                    Console.WriteLine("Number {0} is a restricted symbol!", intMinValue);
                    Console.WriteLine("Restricted symbols: " + restrictedSymbols);
                }
            }
            while (!isParsed);
        }

        public void SetupRangeForDouble()
        {
            bool isParsed = false;
            string userInput = string.Empty;

            // Range From
            do
            {
                Console.Clear();
                Console.WriteLine("Enter range from: ");
                userInput = Console.ReadLine();

                if (!IsRestrictedSymbol(userInput))
                {
                    if (double.TryParse(userInput, out doubleMinValue))
                    {
                        Console.WriteLine("Number {0} added as minimum for double.", doubleMinValue);
                        isParsed = true;
                    }
                    else
                    {
                        Console.WriteLine("The symbol {0} is not a valid number!", userInput);
                    }
                }
                else
                {
                    Console.WriteLine("Number {0} is a restricted symbol!", userInput);
                    Console.WriteLine("Restricted symbols: " + restrictedSymbols);
                }
            }
            while (!isParsed);

            isParsed = false;

            // Range To
            do
            {
                Console.Clear();
                Console.WriteLine("Enter range To: ");
                userInput = Console.ReadLine();

                if (!IsRestrictedSymbol(userInput))
                {
                    if (double.TryParse(userInput, out doubleMaxValue))
                    {
                        if (doubleMaxValue > doubleMinValue)
                        {
                            Console.WriteLine("Number {0} added as maximum for double.", doubleMaxValue);
                            isParsed = true;
                        }
                        else
                        {
                            Console.WriteLine("Number {0} must be greater than a minimum number {1} !", doubleMaxValue, doubleMinValue);
                        }
                    }
                    else
                    {
                        Console.WriteLine("The symbol {0} is not a valid number!", userInput);
                    }
                }
                else
                {
                    Console.WriteLine("Number {0} is a restricted symbol!", userInput);
                    Console.WriteLine("Restricted symbols: " + restrictedSymbols);
                }
            }
            while (!isParsed);
        }

        public void ShowRestrictedSymbols()
        {
            Console.WriteLine(restrictedSymbols);
        }

        public bool AddRestrictedSymbol(string restrictedSymbol)
        {
            bool result = false;

            if (!IsRestrictedSymbol(restrictedSymbol))
            {
                result = true;
                restrictedSymbols += restrictedSymbol;
                Console.WriteLine("Successfully added restricted symbol: {0}", restrictedSymbol);
            }
            else
            {
                Console.WriteLine("Failed adding restricted symbol: {0}. Cause: Symbol already in use.", restrictedSymbol);
            }

            return result;
        }

        private bool IsRestrictedSymbol(string symbol)
        {
            bool result = false;

            for (int i = 0; i < restrictedSymbols.Length - 1; i++)
            {
                if (symbol.Contains(restrictedSymbols[i]))
                {
                    result = true;
                    break;
                }
            }
    
            return result;
        }
    }
}
