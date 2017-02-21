using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160702_CorrectNumbers
{
    class Logger
    {
        public static void ShowMsg(string msg)
        {
            ConsoleColor oldClr = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ForegroundColor = oldClr;
        }
    }
}
