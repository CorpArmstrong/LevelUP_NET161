using System;

namespace MyCoolMatch3Game
{
    public struct Cell
    {
        public bool _isEmpty;
        public Ball _occupatingBall;
        public bool _isSelected;
        public int _xPosition;
        public int _yPosition;
        public ConsoleColor _backCellsColor;

        public static Cell InitCell(int xPosition, int yPosition)
        {
            Cell newCell = new Cell();
            newCell._isEmpty = false;
            newCell._occupatingBall = Ball.InitBall();
            newCell._isSelected = false;
            newCell._backCellsColor = ConsoleColor.Black;
            newCell._xPosition = xPosition;
            newCell._yPosition = yPosition;

            return newCell;
        }

        public static void DrawCell(Cell currentCell)
        {
            if (!currentCell._isEmpty)
            {
                Console.BackgroundColor = currentCell._backCellsColor;
                Console.ForegroundColor = Ball.GetConsoleColor(currentCell._occupatingBall._color);
                Console.Write('☻');
                Console.ResetColor();
            }
            else
            {
                Console.BackgroundColor = currentCell._backCellsColor;
                Console.ForegroundColor = Ball.GetConsoleColor(currentCell._occupatingBall._color);
                Console.Write(' ');
                Console.ResetColor();
            }
            Console.ResetColor();
        }
    }
}