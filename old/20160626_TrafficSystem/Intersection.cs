using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20160626_TrafficSystem
{
    class Intersection
    {
        private enum TrafficLightColor
        {
            Red,
            Yellow,
            Green
        }

        private enum TrafficLights
        {
            Empty,
            Down,
            Right,
            Top,
            Left
        }

        private const int TIME_RED_LIGHT = 20000;
        private const int TIME_YELLOW_LIGHT = 40000;
        private const int TIME_GREEN_LIGHT = 20000;

        private TrafficLightColor downTopColor = TrafficLightColor.Yellow;
        private TrafficLightColor rightLeftColor = TrafficLightColor.Yellow;

        private static bool isGreenTopDown = false;

        public Intersection()
        {
            DrawFrame();
            DrawIntersection();

            DrawLeftTrafficLight(TrafficLightColor.Yellow);
            DrawRightTrafficLight(TrafficLightColor.Yellow);
            DrawTopTrafficLight(TrafficLightColor.Yellow);
            DrawDownTrafficLight(TrafficLightColor.Yellow);

            ProcessTrafficLight();
        }

        private void ProcessTrafficLight()
        {
            Console.SetCursorPosition(2, 2);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("TIME : ");
            Console.ForegroundColor = ConsoleColor.White;
            
            while (true)
            {
                ProcessTimer();
            }
        }

        private void ProcessTimer()
        {
            bool isChanged = false;

            if (downTopColor == TrafficLightColor.Green &&
                rightLeftColor == TrafficLightColor.Red &&
                !isChanged)
            {
                downTopColor = TrafficLightColor.Yellow;
                rightLeftColor = TrafficLightColor.Yellow;
                isChanged = true;
            }

            if (downTopColor == TrafficLightColor.Red &&
                rightLeftColor == TrafficLightColor.Green &&
                !isChanged)
            {
                downTopColor = TrafficLightColor.Yellow;
                rightLeftColor = TrafficLightColor.Yellow;
                isChanged = true;
            }

            if (downTopColor == TrafficLightColor.Yellow &&
                rightLeftColor == TrafficLightColor.Yellow &&
                !isGreenTopDown &&
                !isChanged)
            {
                downTopColor = TrafficLightColor.Green;
                rightLeftColor = TrafficLightColor.Red;
                isGreenTopDown = true;
                isChanged = true;
            }

            if (downTopColor == TrafficLightColor.Yellow &&
                rightLeftColor == TrafficLightColor.Yellow &&
                isGreenTopDown &&
                !isChanged)
            {
                downTopColor = TrafficLightColor.Red;
                rightLeftColor = TrafficLightColor.Green;
                isGreenTopDown = false;
                isChanged = true;
            }

            int seconds = 0;
            int timer = 0;

            switch (downTopColor)
            {
                case TrafficLightColor.Red:
                    timer = TIME_RED_LIGHT;
                    break;
                case TrafficLightColor.Green:
                    timer = TIME_GREEN_LIGHT;
                    break;
                case TrafficLightColor.Yellow:
                    timer = TIME_YELLOW_LIGHT;
                    break;
                default:
                    timer = TIME_YELLOW_LIGHT;
                    break;
            }

            int showTimer = timer;

            while (seconds < timer)
            {
                seconds++;
                showTimer--;

                Console.SetCursorPosition(9, 2);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(showTimer);
                Console.ForegroundColor = ConsoleColor.White;
                
                if (seconds == timer)
                {
                    DrawDownTrafficLight(downTopColor);
                    DrawLeftTrafficLight(rightLeftColor);
                    DrawRightTrafficLight(rightLeftColor);
                    DrawTopTrafficLight(downTopColor);
                }
            }

            Console.Beep();
        }

        private void DrawFrame()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(1, 1);
            Console.Write("╔");

            for (int i = 1; i < Console.WindowWidth - 3; i++)
            {
                Console.SetCursorPosition(i + 1, 1);
                Console.Write("═");
            }

            for (int i = 1; i < Console.WindowHeight - 2; i++)
            {
                Console.SetCursorPosition(1, i + 1);
                Console.Write("║");
            }

            Console.SetCursorPosition(1, Console.WindowHeight - 1);
            Console.Write("╚");

            for (int i = 1; i < Console.WindowWidth - 3; i++)
            {
                Console.SetCursorPosition(i + 1, Console.WindowHeight - 1);
                Console.Write("═");
            }

            Console.SetCursorPosition(Console.WindowWidth - 2, Console.WindowHeight - 1);
            Console.Write("╝");

            Console.SetCursorPosition(Console.WindowWidth - 2, 1);
            Console.Write("╗");

            for (int i = 1; i < Console.WindowHeight - 2; i++)
            {
                Console.SetCursorPosition(Console.WindowWidth - 2, i + 1);
                Console.Write("║");
            }
        }

        private void DrawIntersection()
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;

            for (int i = 8; i < ((Console.WindowWidth / 2) - 7); i++)
            {
                Console.SetCursorPosition(i + 1, ((Console.WindowHeight / 2) - 3));
                Console.Write("═");
            }

            Console.Write("╝");

            for (int i = 2; i < ((Console.WindowHeight / 2) - 4); i++)
            {
                Console.SetCursorPosition(((Console.WindowWidth / 2) - 6), i + 1);
                Console.Write("║");
            }

            for (int i = 2; i < ((Console.WindowHeight / 2) - 4); i++)
            {
                Console.SetCursorPosition(((Console.WindowWidth / 2) + 4), i + 1);
                Console.Write("║");
            }

            Console.SetCursorPosition(((Console.WindowWidth / 2) + 4), ((Console.WindowHeight / 2) - 3));
            Console.Write("╚");

            for (int i = 8; i < ((Console.WindowWidth / 2) - 7); i++)
            {
                Console.SetCursorPosition(i + 1, ((Console.WindowHeight / 2) + 3));
                Console.Write("═");
            }

            Console.Write("╗");

            Console.SetCursorPosition(((Console.WindowWidth / 2) + 4), ((Console.WindowHeight / 2) + 3));
            Console.Write("╔");

            for (int i = ((Console.WindowHeight / 2) + 3); i < (Console.WindowHeight - 3); i++)
            {
                Console.SetCursorPosition(((Console.WindowWidth / 2) + 4), i + 1);
                Console.Write("║");
            }

            for (int i = ((Console.WindowWidth / 2) + 4); i < (Console.WindowWidth - 10); i++)
            {
                Console.SetCursorPosition(i + 1, ((Console.WindowHeight / 2) - 3));
                Console.Write("═");
            }

            for (int i = ((Console.WindowHeight / 2) + 3); i < (Console.WindowHeight - 3); i++)
            {
                Console.SetCursorPosition(((Console.WindowWidth / 2) - 6), i + 1);
                Console.Write("║");
            }

            for (int i = ((Console.WindowWidth / 2) + 4); i < (Console.WindowWidth - 10); i++)
            {
                Console.SetCursorPosition(i + 1, ((Console.WindowHeight / 2) + 3));
                Console.Write("═");
            }

            Console.ForegroundColor = ConsoleColor.White;
        }

        private void DrawLeftTrafficLight(TrafficLightColor colors)
        {
            switch (colors)
            {
                case TrafficLightColor.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 6), ((Console.WindowHeight / 2) - 2));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 6), ((Console.WindowHeight / 2) - 1));
                    Console.Write("@");
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 6), (Console.WindowHeight / 2));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case TrafficLightColor.Green:
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 6), ((Console.WindowHeight / 2) - 2));
                    Console.Write("@");
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 6), ((Console.WindowHeight / 2) - 1));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 6), (Console.WindowHeight / 2));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case TrafficLightColor.Yellow:
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 6), ((Console.WindowHeight / 2) - 2));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 6), ((Console.WindowHeight / 2) - 1));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 6), (Console.WindowHeight / 2));
                    Console.Write("@");
                    break;
                default:
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 6), ((Console.WindowHeight / 2) - 2));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 6), ((Console.WindowHeight / 2) - 1));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 6), (Console.WindowHeight / 2));
                    Console.Write("@");
                    break;
            }
        }

        private void DrawRightTrafficLight(TrafficLightColor colors)
        {
            switch (colors)
            {
                case TrafficLightColor.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(((Console.WindowWidth / 2) + 4), (Console.WindowHeight / 2));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(((Console.WindowWidth / 2) + 4), ((Console.WindowHeight / 2) + 1));
                    Console.Write("@");
                    Console.SetCursorPosition(((Console.WindowWidth / 2) + 4), ((Console.WindowHeight / 2) + 2));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case TrafficLightColor.Green:
                    Console.SetCursorPosition(((Console.WindowWidth / 2) + 4), (Console.WindowHeight / 2));
                    Console.Write("@");
                    Console.SetCursorPosition(((Console.WindowWidth / 2) + 4), ((Console.WindowHeight / 2) + 1));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(((Console.WindowWidth / 2) + 4), ((Console.WindowHeight / 2) + 2));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case TrafficLightColor.Yellow:
                    Console.SetCursorPosition(((Console.WindowWidth / 2) + 4), (Console.WindowHeight / 2));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(((Console.WindowWidth / 2) + 4), ((Console.WindowHeight / 2) + 1));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(((Console.WindowWidth / 2) + 4), ((Console.WindowHeight / 2) + 2));
                    Console.Write("@");
                    break;
                default:
                    Console.SetCursorPosition(((Console.WindowWidth / 2) + 4), (Console.WindowHeight / 2));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(((Console.WindowWidth / 2) + 4), ((Console.WindowHeight / 2) + 1));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(((Console.WindowWidth / 2) + 4), ((Console.WindowHeight / 2) + 2));
                    Console.Write("@");
                    break;
            }
        }

        private void DrawTopTrafficLight(TrafficLightColor colors)
        {
            switch (colors)
            {
                case TrafficLightColor.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 2), ((Console.WindowHeight / 2) - 3));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(((Console.WindowWidth / 2)), ((Console.WindowHeight / 2) - 3));
                    Console.Write("@");
                    Console.SetCursorPosition(((Console.WindowWidth / 2) + 2), ((Console.WindowHeight / 2) - 3));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case TrafficLightColor.Green:
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 2), ((Console.WindowHeight / 2) - 3));
                    Console.Write("@");
                    Console.SetCursorPosition(((Console.WindowWidth / 2)), ((Console.WindowHeight / 2) - 3));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(((Console.WindowWidth / 2) + 2), ((Console.WindowHeight / 2) - 3));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case TrafficLightColor.Yellow:
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 2), ((Console.WindowHeight / 2) - 3));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(((Console.WindowWidth / 2)), ((Console.WindowHeight / 2) - 3));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(((Console.WindowWidth / 2) + 2), ((Console.WindowHeight / 2) - 3));
                    Console.Write("@");
                    break;
                default:
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 2), ((Console.WindowHeight / 2) - 3));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(((Console.WindowWidth / 2)), ((Console.WindowHeight / 2) - 3));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(((Console.WindowWidth / 2) + 2), ((Console.WindowHeight / 2) - 3));
                    Console.Write("@");
                    break;
            }
        }

        private void DrawDownTrafficLight(TrafficLightColor colors)
        {
            switch (colors)
            {
                case TrafficLightColor.Red:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 5), ((Console.WindowHeight / 2) + 3));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 3), ((Console.WindowHeight / 2) + 3));
                    Console.Write("@");
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 1), ((Console.WindowHeight / 2) + 3));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case TrafficLightColor.Green:
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 5), ((Console.WindowHeight / 2) + 3));
                    Console.Write("@");
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 3), ((Console.WindowHeight / 2) + 3));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 1), ((Console.WindowHeight / 2) + 3));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
                case TrafficLightColor.Yellow:
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 5), ((Console.WindowHeight / 2) + 3));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 3), ((Console.WindowHeight / 2) + 3));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 1), ((Console.WindowHeight / 2) + 3));
                    Console.Write("@");
                    break;
                default:
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 5), ((Console.WindowHeight / 2) + 3));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 3), ((Console.WindowHeight / 2) + 3));
                    Console.Write("@");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(((Console.WindowWidth / 2) - 1), ((Console.WindowHeight / 2) + 3));
                    Console.Write("@");
                    break;
            }
        }
    }
}
