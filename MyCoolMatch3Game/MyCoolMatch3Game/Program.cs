using System;
using System.Text;

namespace MyCoolMatch3Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false;
            Match3GameLoader.InitAndLoadGame();
        }
    }
}
