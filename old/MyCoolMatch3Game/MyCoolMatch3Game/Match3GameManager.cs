using System;

namespace MyCoolMatch3Game
{
    class Match3GameManager
    {
        public static bool CheckNearestCellToReplace(Cell firstCell, Cell secondCell)
        {
            bool isNearest = false;

            if (Math.Abs(secondCell._xPosition - firstCell._xPosition) == 1)
            {
                if (Math.Abs(secondCell._yPosition - firstCell._yPosition) == 1 ||
                    (secondCell._yPosition - firstCell._yPosition) == 0)
                {
                    isNearest = true;
                }
            }

            if (Math.Abs(secondCell._yPosition - firstCell._yPosition) == 1)
            {
                if (Math.Abs(secondCell._xPosition - firstCell._xPosition) == 1 ||
                    (secondCell._xPosition - firstCell._xPosition) == 0)
                {
                    isNearest = true;
                }
            }

            return isNearest;
        }

        public static void DeleteAndShift(Cell[,] cells)
        {
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    if (!cells[i, j]._isEmpty)
                    {
                        Cell[] cellsForDelete = new Cell[17];
                        //cellsForDelete[0] = cells[i, j];

                        int lastDeletedIndex = 0;

                        GetCellsForDelete(GetHorizontalCells(cells, cells[i, j]), cells[i, j], cellsForDelete, ref lastDeletedIndex);
                        GetCellsForDelete(GetVerticalCells(cells, cells[i, j]), cells[i, j], cellsForDelete, ref lastDeletedIndex);
                        GetCellsForDelete(GetDiagonalCells(cells, cells[i, j]), cells[i, j], cellsForDelete, ref lastDeletedIndex);

                        // if we've minimum two elements to delete
                        if (lastDeletedIndex >= 2)
                        {
                            cellsForDelete[0] = cells[i, j];
                            DeleteSameBalls(cells, cellsForDelete, lastDeletedIndex);
                        }
                    }
                    ShiftBalls(cells);
                }
            }
        }

        private static void DeleteSameBalls(Cell[,] cells, Cell[] cellsForDelete, int lastDeletedIndex)
        {
            int deletedBallsCount = 0;

            for (int k = 0; k <= lastDeletedIndex; k++)
            {
                for (int l = 0; l < cells.GetLength(0); l++)
                {
                    for (int m = 0; m < cells.GetLength(1); m++)
                    {
                        if (cellsForDelete[k]._xPosition == cells[l, m]._xPosition &&
                            cellsForDelete[k]._yPosition == cells[l, m]._yPosition)
                        {
                            cells[l, m]._occupatingBall._isDeleted = true;
                            cells[l, m]._isEmpty = true;
                            deletedBallsCount++;
                        }
                    }
                }
            }
        }

        public static Cell[] GetHorizontalCells(Cell[,] cells, Cell currentCell)
        {
            Cell[] horisontalCells = new Cell[Utils.maxCountCellsInLine - 1];
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    for (int k = 0; k < horisontalCells.Length; k++)
                    {
                        if ((currentCell._yPosition - cells[i, j]._yPosition) == 0 && !cells[i, j]._isEmpty)
                        {
                            if (Math.Abs(currentCell._xPosition - cells[i, j]._xPosition) == 1 ||
                                Math.Abs(currentCell._xPosition - cells[i, j]._xPosition) == 2)
                            {
                                horisontalCells[k] = cells[i, j];
                            }
                        }
                    }
                }
            }

            return horisontalCells;
        }

        public static Cell[] GetVerticalCells(Cell[,] cells, Cell currentCell)
        {
            Cell[] verticalCells = new Cell[Utils.maxCountCellsInLine - 1];
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    for (int k = 0; k < verticalCells.Length; k++)
                    {
                        if ((currentCell._xPosition - cells[i, j]._xPosition) == 0 && !cells[i, j]._isEmpty)
                        {
                            if (Math.Abs(currentCell._yPosition - cells[i, j]._yPosition) == 1 ||
                                Math.Abs(currentCell._yPosition - cells[i, j]._yPosition) == 2)
                            {
                                verticalCells[k] = cells[i, j];
                            }
                        }
                    }
                }
            }

            return verticalCells;
        }

        public static Cell[] GetDiagonalCells(Cell[,] cells, Cell currentCell)
        {
            Cell[] leftDiagonalCells = new Cell[(Utils.maxCountCellsInLine - 1) * 2];
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1); j++)
                {
                    for (int k = 0; k < leftDiagonalCells.Length; k++)
                    {
                        if (!cells[i, j]._isEmpty)
                        {
                            if (Math.Abs(currentCell._yPosition - cells[i, j]._yPosition) == 1 &&
                                Math.Abs(currentCell._xPosition - cells[i, j]._xPosition) == 1)
                            {
                                leftDiagonalCells[k] = cells[i, j];
                            }

                            if (Math.Abs(currentCell._yPosition - cells[i, j]._yPosition) == 2 &&
                                Math.Abs(currentCell._xPosition - cells[i, j]._xPosition) == 2)
                            {
                                leftDiagonalCells[k] = cells[i, j];
                            }
                        }
                    }
                }
            }

            return leftDiagonalCells;
        }

        public static void GetCellsForDelete(Cell[] cellsForCheck, Cell currentCell, Cell[] cellsForDelete, ref int lastDeletedIndex)
        {
            for (int i = 0; i < cellsForCheck.Length; i++)
            {
                if (cellsForCheck[i]._occupatingBall._color == currentCell._occupatingBall._color)
                {
                    for (int j = lastDeletedIndex + 1; j < cellsForDelete.Length; j++)
                    {
                        cellsForDelete[j] = cellsForCheck[i];
                        lastDeletedIndex = j;
                    }
                }
            }
        }

        public static void ShiftBalls(Cell[,] cells)
        {
            for (int i = 0; i < cells.GetLength(0); i++)
            {
                for (int j = 0; j < cells.GetLength(1) - 1; j++) // Modified: for (int j = 0; j < cells.GetLength(1) - 1; j++)
                {
                    if (!cells[i, j]._isEmpty && cells[i, j + 1]._isEmpty && j + 1 < cells.GetLength(1))
                    {
                        cells[i, j + 1] = cells[i, j];
                        cells[i, j]._isEmpty = true;
                    }
                }
            }
        }
    }
}