using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsProgress.Logic;
using StudentsProgress.GUI;
using StudentsProgress.Data;

namespace StudentsProgress.Logic
{
    public static class ConsoleMenu
    {

        /// <summary>
        /// Функция отображает меню на основе переданного массива и уточняющих данных
        /// </summary>
        /// <param name="menuHeader">Заголовок окна меню</param>
        /// <param name="menuElements">Перечень элементов меню</param>
        /// <param name="taskIndex">Выходной параметр. Определяет действие над выбранным элементом</param>
        /// <param name="cursor">Позиция выбранного элемента меню</param>
        /// <param name="printOver">Выводить меню поверх предыдущего или вместо</param>
        /// <param name="verticalMiddle">Выводить меню по центру или по заданному отступу по горизонтали</param>
        /// <returns></returns>
        public static int NavigateMenu(string menuHeader, string[] menuElements, out Common.TaskIndex taskIndex, int cursor = 0, bool printOver = false, bool verticalMiddle = false)
        {
            taskIndex = Common.TaskIndex.NONE;
            while (menuElements.Length > 0)
            {
                ConsoleGraphic.OutputTextInFrame(menuHeader, menuElements, cursor, printOver, verticalMiddle);
                printOver = true;

                ConsoleKeyInfo key = Console.ReadKey(true);

                if (key.Key == ConsoleKey.Escape)
                {
                    return -1;
                }

                if (key.Key == ConsoleKey.Enter)
                {
                    break;
                }

                if (key.Key == ConsoleKey.Delete)
                {
                    taskIndex = Common.TaskIndex.REMOVE;
                    break;
                }

                if (key.Key == ConsoleKey.OemPlus)
                {
                    taskIndex = Common.TaskIndex.ADD;
                    break;
                }

                if (key.Key == ConsoleKey.E)
                {
                    taskIndex = Common.TaskIndex.EDIT;
                    break;
                }

                if (key.Key == ConsoleKey.S)
                {
                    taskIndex = Common.TaskIndex.AVERAGE_GRADE;
                    break;
                }

                if (key.Key == ConsoleKey.B)
                {
                    taskIndex = Common.TaskIndex.BEST_STUDENT;
                    break;
                }

                if (key.Key == ConsoleKey.W)
                {
                    taskIndex = Common.TaskIndex.WORST_STUDENT;
                    break;
                }

                if (key.Key == ConsoleKey.UpArrow)
                {
                    if (cursor > 0)
                        cursor--;

                    continue;
                }

                if (key.Key == ConsoleKey.DownArrow)
                {
                    if (cursor < menuElements.Length-1)
                        cursor++;

                    continue;
                }

            }

            return cursor;
        }

        public static int ReadIntValueFromConsole(string message)
        {
            int inputValue = 0;
            do
            {
                ConsoleGraphic.OutputTextInFrame(message, new string[] { "" }, -1, false, true);
            } 
            while (!int.TryParse(Console.ReadLine(), out inputValue));
            return inputValue;
        }

        public static string ReadStringValueFromConsole(string message)
        {
            string inputValue = "";
            ConsoleGraphic.OutputTextInFrame(message, new string[] { "" }, -1, false, true);
            inputValue = Console.ReadLine();
            return inputValue;
        }
    }


}
