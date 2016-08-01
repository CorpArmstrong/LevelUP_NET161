using System;

using _20160730_StudentsManagement.BusinessLayer;
using _20160730_StudentsManagement.Utils;

namespace _20160730_StudentsManagement
{
    class Program
    {
        static void Main()
        {
            MainMenu menu = new MainMenu();
            menu.RunMainMenu();
            CommonUtils.WaitForUserInput();
        }
    }
}
