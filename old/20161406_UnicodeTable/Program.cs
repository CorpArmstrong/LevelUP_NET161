using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20161406_UnicodeTable
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().PrintUnicodeTable();
        }

        public void PrintUnicodeTable()
        {
            int rangeFrom, rangeTo;
            string inputString = null;
            bool isParsed = false;

            do
            {
                Console.Write("Enter range from (in between {0} and {1}): ", ushort.MinValue, ushort.MaxValue);
                inputString = Console.ReadLine();

                if (int.TryParse(inputString, out rangeFrom))
                {
                    if (rangeFrom >= ushort.MinValue && rangeFrom <= ushort.MaxValue)
                    {
                        isParsed = true;
                    }
                }
            }
            while (!isParsed);

            isParsed = false;

            do
            {
                Console.Write("Enter range to (in between {0} and {1}): ", rangeFrom, ushort.MaxValue);
                inputString = Console.ReadLine();

                if (int.TryParse(inputString, out rangeTo))
                {
                    if (rangeTo > rangeFrom && rangeTo <= ushort.MaxValue)
                    {
                        isParsed = true;
                    }
                }
            }
            while (!isParsed);

            isParsed = false;
            int numOfColumns = 0;
            const int STRING_LENGTH = 17;
            
            do
            {
                Console.Write("Enter number of columns (in between {0} and {1}): ", 1, Console.WindowWidth / STRING_LENGTH);
                inputString = Console.ReadLine();

                if (int.TryParse(inputString, out numOfColumns))
                {
                    if (numOfColumns >= 1 && numOfColumns <= Console.WindowWidth / STRING_LENGTH)
                    {
                        isParsed = true;
                    }
                }
            }
            while(!isParsed);
            

            int width = Console.WindowWidth;
            int diff = rangeTo - rangeFrom;
            
            int columnCharCount = diff / numOfColumns;
            if (diff % numOfColumns > 0) columnCharCount++;
                
            char[] arr = new char[diff+1];

            for (int i = 0; i <= diff; i++)
            {
                arr[i] = (char)rangeFrom;
                rangeFrom++;
            }

            int startPos = 0;
            int endPos = columnCharCount;

            Console.Clear();

            int cleft = 0;
            int ctop = 0;

            do
            {
                if (columnCharCount < arr.Length)
                {
                    for (int i = startPos; i < endPos; i++)
                    {
                        Console.SetCursorPosition(cleft, ctop);
                        Console.WriteLine("Code{0}:Char {1};", i, (char)arr[i]);
                        ctop++;
                    }

                    startPos += columnCharCount;

                    if (endPos + columnCharCount < arr.Length)
                        endPos += columnCharCount;
                    else
                        endPos = arr.Length;

                    cleft += STRING_LENGTH;    
                    ctop = 0;
                }
            }
            while (startPos < arr.Length);

            Console.ReadKey();
        }
    }
}
