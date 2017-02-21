using System;

namespace DurakGame
{
    class Program
    {
        static void Main(string[] args)
        {
            DurakGameManager durakGameManager = new DurakGameManager();
            durakGameManager.InitGame();

            Console.ReadKey();
        }
    }
}
