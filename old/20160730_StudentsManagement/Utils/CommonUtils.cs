using System;

namespace _20160730_StudentsManagement.Utils
{
    public class CommonUtils
    {
        public static void ShowMessage(string str, ConsoleColor newColor)
        {
            ConsoleColor currentColor = Console.ForegroundColor;
            Console.ForegroundColor = newColor;
            Console.WriteLine(str);
            Console.ForegroundColor = currentColor;
        }

        public static void WaitForUserInput()
        {
            Console.ReadKey();
        }

        public static void RefreshScreen()
        {
            Console.Clear();
        }

        public static string GetUserInputString()
        {
            return Console.ReadLine();
        }

        public static string GetUserInputStringToLower()
        {
            return GetUserInputString().ToLower();
        }

        public static int GetAverageValue(int[] arr)
        {
            int average = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                average += arr[i];
            }

            return average/arr.Length;
        }
    }
}
