using System;
using System.Threading;

namespace MyCoolMatch3Game
{
    public struct Player
    {
        public GameField playersGameField;

        public void Move()
        {
            bool isQuit = false;
            ConsoleKeyInfo keyInfo; 

            byte currentXPosition = 0;
            byte currentYPosition = 0;
            byte lastXPosition = 0;
            byte lastYPosition = 0;
            byte lastSelectedX = 0;
            byte lastSelectedY = 0;

            while (!isQuit)
            {
                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.DownArrow:
                        {
                            if (currentYPosition + 1 < playersGameField._cells.GetLength(1))
                            {
                                currentYPosition++;
                            }
                            break;
                        }
                    case ConsoleKey.LeftArrow:
                        {
                            if (currentXPosition - 1 >= 0)
                            {
                                currentXPosition--;
                            }
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (currentXPosition + 1 < playersGameField._cells.GetLength(0))
                            {
                                currentXPosition++;
                            }
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            if (currentYPosition - 1 >= 0)
                            {
                                currentYPosition--;
                            }
                            break;
                        }
                    case ConsoleKey.Spacebar:
                        {
                            CheckSelectedCells(currentXPosition, currentYPosition, lastXPosition, lastYPosition, 
                                               lastSelectedX, lastSelectedY);                               
                            break;
                        }
                    case ConsoleKey.Escape:
                        isQuit = true;
                        break;
                    default:
                        break;
                }
               

                if (playersGameField._cells[currentXPosition, currentYPosition]._isSelected)
                {
                    playersGameField._cells[currentXPosition, currentYPosition]._backCellsColor = ConsoleColor.DarkGray;
                    Console.SetCursorPosition(currentXPosition, currentYPosition);
                    Cell.DrawCell(playersGameField._cells[currentXPosition, currentYPosition]);
                }
                else
                {
                    if (!playersGameField._cells[lastXPosition, lastYPosition]._isSelected)
                    {
                        playersGameField._cells[lastXPosition, lastYPosition]._backCellsColor = ConsoleColor.Black;
                        Console.SetCursorPosition(lastXPosition, lastYPosition);
                        Cell.DrawCell(playersGameField._cells[lastXPosition, lastYPosition]);
                    }

                    playersGameField._cells[currentXPosition, currentYPosition]._backCellsColor = ConsoleColor.Gray;
                    Console.SetCursorPosition(currentXPosition, currentYPosition);
                    Cell.DrawCell(playersGameField._cells[currentXPosition, currentYPosition]);
                                        
                }

                if (!playersGameField._cells[lastSelectedX, lastSelectedY]._isSelected)
                {
                    playersGameField._cells[lastSelectedX, lastSelectedY]._backCellsColor = ConsoleColor.Black;
                    Console.SetCursorPosition(lastSelectedX, lastSelectedY);
                    Cell.DrawCell(playersGameField._cells[lastSelectedX, lastSelectedY]);
                }

                if (playersGameField._cells[currentXPosition, currentYPosition]._isSelected)
                {
                    lastSelectedX = currentXPosition;
                    lastSelectedY = currentYPosition;
                }
                
                lastXPosition = currentXPosition;
                lastYPosition = currentYPosition;

                Thread.Sleep(200);
            }

        }

        private void CheckSelectedCells(byte currentXPosition, byte currentYPosition, byte lastXPosition, byte lastYPosition,
                                        byte lastSelectedX, byte lastSelectedY)
        {
            if (!playersGameField._cells[currentXPosition, currentYPosition]._isSelected)
            {
                if (!playersGameField._cells[lastSelectedX, lastSelectedY]._isSelected)
                {
                    playersGameField._cells[currentXPosition, currentYPosition]._isSelected = true;
                }
                else
                {
                    if (Match3GameManager.CheckNearestCellToReplace(playersGameField._cells[lastSelectedX, lastSelectedY],
                                                   playersGameField._cells[currentXPosition, currentYPosition]))
                    {
                        GameField.ReplaceTwoSelectedBalls(ref playersGameField._cells[currentXPosition, currentYPosition],
                                                          ref playersGameField._cells[lastSelectedX, lastSelectedY]);
                        playersGameField._cells[currentXPosition, currentYPosition]._isSelected = false;
                        playersGameField._cells[lastSelectedX, lastSelectedY]._isSelected = false;

                        Match3GameManager.DeleteAndShift(playersGameField._cells);

                        // Modified:
                        //Console.Clear();
                        //Console.SetCursorPosition(0, 0);
                        
                        GameField.DrawGameField(playersGameField._cells);
                    }
                    else
                    {
                        playersGameField._cells[currentXPosition, currentYPosition]._isSelected = true;
                        playersGameField._cells[lastSelectedX, lastSelectedY]._isSelected = false;
                    }
                }
            }
            else
            {
                playersGameField._cells[currentXPosition, currentYPosition]._isSelected = false;
            }
        }
    }
}
