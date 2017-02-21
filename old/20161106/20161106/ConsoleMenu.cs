using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace _20161106
{
    public class ConsoleMenu
    {
        private int selectedPosition;
        private ConsoleColor selectedColor = ConsoleColor.DarkYellow;
        private Dictionary<string, string> positionsMenu = new Dictionary<string, string>();
        private HomeWorkHelper hwHelper;
        private bool isQuit;
        private bool isExitInput;

        public ConsoleMenu()
        {
            hwHelper = new HomeWorkHelper();

            positionsMenu.Add("1) Print 'Hello, World!' number of times.", "PrintHelloWorld");
            positionsMenu.Add("2) Average for two numbers.", "Average");
            positionsMenu.Add("3) Number of digits.", "ReturnNumberOfDigits");
            positionsMenu.Add("4) Print numbers for range.", "WriteNumberRange");
            positionsMenu.Add("5) Determination of a number negativity.", "IsNumberNegative");
            positionsMenu.Add("6) Beep sound number of times.", "PlaySound");
            positionsMenu.Add("7) Flip sign for number.", "FlipAbsForNumber");
            positionsMenu.Add("8) Module of number.", "ReturnAbsForNumber");
            positionsMenu.Add("9) Check number by number division.", "IsNumberCanBeDividedByNumber");
            positionsMenu.Add("10) Print random number from range.", "ReturnRandomNumberForRange");
            positionsMenu.Add("11) Division result.", "ShowDivisionResult");
            positionsMenu.Add("12) Division remainder.", "ReturnModuloForNumbers");
            positionsMenu.Add("Exit", "Exit");

            InitAndRunMainMenu();
        }

        private void InitAndRunMainMenu()
        {
            while (!isQuit)
            {
                ShowMenu(0);
                UserSelection();
            }
        }

        private void BackToMenu(ref bool isExitInput)
        {
            Console.WriteLine("\nPress any key to return to main menu...");
            Console.ReadKey();
            isExitInput = true;
        }

        public void ShowMenu(int selectedPosition)
        {
            Console.Clear();

            Console.Write("<");
            for (int i = 0; i < Console.WindowWidth - 2; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine(">");

            string outString;

            for (int i = 0; i < positionsMenu.Count; i++)
            {
                if (i == selectedPosition)
                {
                    ConsoleGraphicsUtils.DrawColoredText("* " + positionsMenu.Keys.ElementAt(i), selectedColor);
                }
                else
                {
                    ConsoleGraphicsUtils.DrawColoredText("* " + positionsMenu.Keys.ElementAt(i), ConsoleColor.Cyan);
                }
                
                Console.WriteLine();
                outString = "* " + positionsMenu.Keys.ElementAt(i);
                ConsoleGraphicsUtils.DrawHeader('-', outString.Length);
            }

            Console.Write("<");
            for (int i = 0; i < Console.WindowWidth - 2; i++)
            {
                Console.Write("=");
            }
            Console.WriteLine(">");    
            Console.WriteLine("\nUse arrows to navigate and ENTER to select.");
        }

        public void UserSelection()
        {
            ConsoleKeyInfo keyInfo;
            selectedPosition = 0;

            do
            {
                keyInfo = Console.ReadKey(true);

                switch (keyInfo.Key)
                {
                    case ConsoleKey.Enter:
                        Console.Clear();
                        string methodName = positionsMenu.Values.ElementAt(selectedPosition);
                        if (methodName.Equals("Quit"))
                        {
                            isExitInput = true;
                            isQuit = true;
                        }
                        else
                        {
                            MethodInfo mi = hwHelper.GetType().GetMethod(methodName);
                            mi.Invoke(hwHelper, null);
                            BackToMenu(ref isExitInput);
                        }
                        break;
                    case ConsoleKey.DownArrow:
                        if (selectedPosition >= 0 && selectedPosition < (positionsMenu.Count - 1))
                        {
                            selectedPosition++;
                            ShowMenu(selectedPosition);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (selectedPosition > 0 && selectedPosition <= positionsMenu.Count)
                        {
                            selectedPosition--;
                            ShowMenu(selectedPosition);
                        }
                        break;
                    case ConsoleKey.Escape:
                        isExitInput = true;
                        isQuit = true;
                        break;
                    default:
                        Console.WriteLine("Wrong key!");
                        break;
                }
            }
            while (!isExitInput);
        }
    }
}
