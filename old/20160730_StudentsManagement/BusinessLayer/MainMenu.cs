using System;

using _20160730_StudentsManagement.DataLayer.Entity;
using _20160730_StudentsManagement.DataLayer.TestData;
using _20160730_StudentsManagement.Utils;

namespace _20160730_StudentsManagement.BusinessLayer
{
    public class MainMenu
    {
        private StudentsGroup group = StudentsGroup.InitStudentsGroup();

        public void RunMainMenu()
        {
            UserCommands.group = group;
            bool isQuit = false;
            string userInput = null;
            bool labelPassed = false;

            do
            {
                CommonUtils.RefreshScreen();
                CommonUtils.ShowMessage("Enter SHOW to show all students.", ConsoleColor.Cyan);
                CommonUtils.ShowMessage("Enter ADD to add student.", ConsoleColor.Cyan);
                CommonUtils.ShowMessage("Enter MOD to modify student.", ConsoleColor.Cyan);
                CommonUtils.ShowMessage("Enter DEL to delete student.", ConsoleColor.Cyan);
                CommonUtils.ShowMessage("Enter BEST to find best student.", ConsoleColor.Cyan);
                CommonUtils.ShowMessage("Enter WORST to find worst student.", ConsoleColor.Cyan);
                CommonUtils.ShowMessage("Enter QUIT to quit the application.", ConsoleColor.Cyan);

                userInput = CommonUtils.GetUserInputStringToLower();
                CommonUtils.RefreshScreen();

                switch (userInput)
                {
                    case "show":
                        UserCommands.ShowCommand();
                        labelPassed = true;
                        break;
                    case "add":
                        UserCommands.AddCommand();
                        labelPassed = true;
                        break;
                    case "mod":
                        UserCommands.ModifyCommand();
                        labelPassed = true;
                        break;
                    case "del":
                        UserCommands.DeleteCommand();
                        labelPassed = true;
                        break;
                    case "best":
                        UserCommands.ShowBestStudentCommand();
                        CommonUtils.WaitForUserInput();
                        labelPassed = true;
                        break;
                    case "worst":
                        UserCommands.ShowWorstStudentCommand();
                        CommonUtils.WaitForUserInput();
                        labelPassed = true;
                        break;
                    case "quit":
                        CommonUtils.ShowMessage("Goodbye!", ConsoleColor.Cyan);
                        isQuit = true;
                        break;
                    default:
                        CommonUtils.ShowMessage("Incorrect command, please repeat!", ConsoleColor.Cyan);
                        break;
                }

                if (!labelPassed)
                {
                    CommonUtils.WaitForUserInput();
                }

                labelPassed = false;
            }
            while (!isQuit);
        }
    }
}
