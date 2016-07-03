using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20161106
{
    public static class ConsoleGraphicsUtils
    {
        public static void DrawColoredText(string text, ConsoleColor cl)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = cl;
            Console.Write(text);
            Console.ForegroundColor = currentColor;
        }

        public static void DrawHeader(char symbolDelimeter, int numOfSymbolsInBorder)
        {
            for (int i = 0; i < numOfSymbolsInBorder; i++)
            {
                Console.Write(symbolDelimeter);
            }
            Console.WriteLine();
        }

        public static void DrawFrame(string text, int padding, char symbolDelimeter, ConsoleColor cl, int numOfRepeats = 0)
        {
            ConsoleColor currentColor = Console.ForegroundColor;

            int borderLength = text.Length + 2 * padding;

            for (int i = 0; i < borderLength; i++)
            {
                Console.Write(symbolDelimeter);
            }
            Console.WriteLine();

            do
            {
                Console.Write(symbolDelimeter);
                for (int i = 0; i < padding - 1; i++)
                {
                    Console.Write(" ");
                }

                DrawColoredText(text, cl);

                for (int i = 0; i < padding - 1; i++)
                {
                    Console.Write(" ");
                }
                Console.Write(symbolDelimeter);
                Console.WriteLine();

                numOfRepeats--;
            }
            while (numOfRepeats > 0);

            for (int i = 0; i < borderLength; i++)
            {
                Console.Write(symbolDelimeter);
            }
            Console.WriteLine();
        }
    }
}
