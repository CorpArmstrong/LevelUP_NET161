using System;

namespace MyCoolMatch3Game
{
    public struct GameField
    {
        int _countXPositions;   
        int _countYPositions;   
        public Cell[,] _cells;        

        public static Cell[,] InitCells()
        {
            Cell[,] cells = new Cell[Utils.countXPosition, Utils.countYPosition];

            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    cells[i, j] = Cell.InitCell(i, j);
                }
            }

            return cells;
        }

        public static GameField InitGameField()
        {
            GameField newField = new GameField();

            newField._countXPositions = Utils.countXPosition;
            newField._countYPositions = Utils.countYPosition;
            newField._cells = InitCells();

            return newField;
        }

        public static void DrawGameField(Cell[,] cells)
        {
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    //Console.SetCursorPosition(i, j);
                    Console.SetCursorPosition(cells[j, i]._xPosition, cells[j, i]._yPosition);
                    Console.BackgroundColor = cells[j, i]._backCellsColor;
                    Console.ForegroundColor = Ball.GetConsoleColor(cells[j, i]._occupatingBall._color);
                    Cell.DrawCell(cells[j, i]);
                }
                Console.WriteLine();
            }
        }

        public static bool CheckStrokeAccess(GameField currentField)
        {
            int[] ballColors = (int[])Enum.GetValues(typeof(Ball.BallColor));
            bool isStrokeAccess = false;

            for (int k = 0; k < ballColors.Length; k++)
            {
                byte sameBallsCounter = 0;
                for (int i = 0; i < currentField._cells.GetLength(0); i++)
                {
                    for (int j = 0; j < currentField._cells.GetLength(1); j++)
                    {
                        sameBallsCounter++;
                    }
                }
                if (sameBallsCounter >= 3)
                {
                    isStrokeAccess = true;
                    break;
                }
            }

            return isStrokeAccess;
        }

        public static void ReInitGameField(ref GameField currentField)
        {
            if (!CheckStrokeAccess(currentField))
            {
                currentField = InitGameField();
            }
        }

        public static void ReplaceTwoSelectedBalls(ref Cell firstCell, ref Cell secondCell)
        {
            if (firstCell._occupatingBall._color != secondCell._occupatingBall._color)
            {
                Ball.BallColor tempColor = firstCell._occupatingBall._color;
                firstCell._occupatingBall._color = secondCell._occupatingBall._color;
                secondCell._occupatingBall._color = tempColor;
            }
        }
    }
}
