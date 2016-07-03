using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle_Fedykovich
{
    class Settings
    {
        public static enum direction { HORIZONTAL, VERTICAL };
        public static const int CELL_SIZE = 10;
        public static char[] numbers = new char[CELL_SIZE] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    }
}
