using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProgress.GUI
{
    public static class ConsoleGraphic
    {
        public static int menuVerticalPadding = 5; // вертикальный отступ меню

        public static void OutputTextInFrame(string header, string[] text, int highlight = -1, bool printOver = false,bool verticalMiddle=false)
        {
            int VerticalPadding = 0;
            if (!verticalMiddle)
            {
                VerticalPadding = menuVerticalPadding;
            }
            else
            {
                VerticalPadding = Console.WindowHeight / 2 - text.Length / 2+2;
            }


            if (!printOver)
                DrawFrame();
            
            Console.BackgroundColor = ConsoleColor.DarkGreen;
            string[] splittedString = new string[text.Length];

            Array.Copy(text, splittedString, text.Length);



            int windowWidth; // ширина окна равна длине наибольшей строки
            if (header.Length <= splittedString[0].Length)
            {
                windowWidth = splittedString[0].Length;
                for (int i = 1; i < splittedString.Length; i++)
                {
                    if (windowWidth < splittedString[i].Length)
                    {
                        windowWidth = splittedString[i].Length;
                    }
                }

            }
            else
            {
                windowWidth = header.Length;
            }

            while (header.Length <= windowWidth)
            {
                header += " ";
            }

            Console.SetCursorPosition((Console.WindowWidth / 2 - windowWidth / 2), VerticalPadding - 2);
            Console.Write("┌");
            for (int i = 0; i <= windowWidth; i++)
                Console.Write("─");
            Console.Write("┐");

            Console.SetCursorPosition((Console.WindowWidth / 2 - windowWidth / 2), VerticalPadding - 1);
            Console.Write("│" + header + "│");

            Console.SetCursorPosition((Console.WindowWidth / 2 - windowWidth / 2), VerticalPadding);
            Console.Write("├");
            for (int i = 0; i <= windowWidth; i++)
                Console.Write("─");
            Console.Write("┤");



            for (int i = 0; i < splittedString.Length; i++)
            {
                Console.SetCursorPosition((Console.WindowWidth / 2 - windowWidth / 2), VerticalPadding + 1 + i);

                while (splittedString[i].Length <= windowWidth)
                {
                    splittedString[i] += " ";
                }

                if (i == highlight)
                {
                    Console.Write("│");
                    ConsoleColor buf = Console.BackgroundColor;
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Write(splittedString[i]);
                    Console.BackgroundColor = buf;
                    Console.Write("│");
                }
                else
                {
                    Console.Write("│" + splittedString[i] + "│");
                }
            }


            Console.SetCursorPosition((Console.WindowWidth / 2 - windowWidth / 2), VerticalPadding + 1 + splittedString.Length);

            Console.Write("└");
            for (int i = 0; i <= windowWidth; i++)
                Console.Write("─");
            Console.Write("┘");

            Console.SetCursorPosition((Console.WindowWidth / 2 - windowWidth / 2) +1, VerticalPadding + 1);
        }

        static void DrawFrame()
        {
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;

            Console.Write("╔");
            Console.SetCursorPosition(1, 0);
            for (int i = 0; i < Console.WindowWidth - 2; i++)
                Console.Write("═");
            Console.Write("╗");

            for (int i = 1; i < Console.WindowHeight - 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("║");
                Console.SetCursorPosition(Console.WindowWidth - 1, i);
                Console.Write("║");
            }


            Console.SetCursorPosition(0, Console.WindowHeight - 1);
            Console.Write("╚");
            Console.SetCursorPosition(1, Console.WindowHeight - 1);
            for (int i = 0; i < Console.WindowWidth - 2; i++)
                Console.Write("═");
            Console.Write("╝");


            Console.SetCursorPosition(0, 0);
            Console.SetCursorPosition(1, 1);
        }

        public static void InitConsole(int width,int height,bool add=false)
        {
            if (add)
            {
                Console.WindowWidth += width;
                Console.WindowHeight += height;
            }
            else
            {
                Console.WindowWidth = width;
                Console.WindowHeight = height;
            }

            Console.CursorVisible = false;
            DrawFrame();
        }

        public static void Wait()
        {
            Console.ReadKey(true);
        }
    }
}
