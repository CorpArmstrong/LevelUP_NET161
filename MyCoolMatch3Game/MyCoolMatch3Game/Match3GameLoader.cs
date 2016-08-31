using System;

namespace MyCoolMatch3Game
{
    class Match3GameLoader
    {
        public static void InitAndLoadGame()
        {
            GameField playersGameField = GameField.InitGameField();
            GameField.DrawGameField(playersGameField._cells);
            Console.SetCursorPosition(0, 0);
            //Match3GameManager.DeleteAndShift(playersGameField._cells);
            Player pl = new Player() { playersGameField = playersGameField };
            pl.Move();
        }
    }
}