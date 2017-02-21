using System;

using _20160730_StudentsManagement.Utils;
using _20160730_StudentsManagement.DataLayer;
using _20160730_StudentsManagement.DataLayer.Entity;
using _20160730_StudentsManagement.DataLayer.TestData;

namespace _20160730_StudentsManagement.BusinessLayer
{
    public static class UserCommands
    {
        public static StudentsGroup group;

        public static void ShowCommand()
        {
            CommonUtils.ShowMessage("Showing all students:\n", ConsoleColor.DarkCyan);
            CommonUtils.ShowMessage(group.ShowStudents(), ConsoleColor.DarkCyan);
            CommonUtils.WaitForUserInput();
        }
        
        public static void AddCommand()
        {
            group.AddStudent(new Student() { _cardNumber = 34343434, _marks = new int[TestStudentsData.NUM_MARKS], _name = "Dibilozavr", _surname = "Arseniy" });
        }
        
        public static void ModifyCommand()
        {
            int pos = 0;
            string inputStr = string.Empty;
            bool isDoneParse = false;
            Student[] studs = group.GetStudents();

            do
            {
                CommonUtils.RefreshScreen();
                CommonUtils.ShowMessage("Students:", ConsoleColor.Cyan);

                for (int i = 0; i < studs.Length; i++)
                {
                    CommonUtils.ShowMessage(string.Format("№{0} - {1}", i + 1, studs[i].PrintStudentInfo()), ConsoleColor.Cyan);
                }

                CommonUtils.ShowMessage("\nEnter student number: ", ConsoleColor.Cyan);
                inputStr = CommonUtils.GetUserInputString();

                if (int.TryParse(inputStr, out pos))
                {
                    if ((pos - 1 >= 0) && (pos - 1 < studs.Length))
                    {
                        isDoneParse = true;
                    }
                }
            }
            while (!isDoneParse);

            Student currentStudent = new Student();

            do
            {
                CommonUtils.RefreshScreen();
                CommonUtils.ShowMessage("Enter card number: ", ConsoleColor.Cyan);
                inputStr = CommonUtils.GetUserInputString();
            }
            while (!int.TryParse(inputStr, out currentStudent._cardNumber));

            CommonUtils.ShowMessage("Enter student name: ", ConsoleColor.Cyan);
            currentStudent._name = CommonUtils.GetUserInputString();

            CommonUtils.ShowMessage("Enter student surname: ", ConsoleColor.Cyan);
            currentStudent._surname = CommonUtils.GetUserInputString();

            isDoneParse = false;

            bool isDoneMarks = false;
            int mark = 0;
            int markCounter = 1;

            currentStudent._marks = new int[TestStudentsData.NUM_MARKS];

            do
            {
                do
                {
                    CommonUtils.RefreshScreen();
                    CommonUtils.ShowMessage(string.Format("Enter mark (Range from 1 to 12) {0}:", markCounter), ConsoleColor.Cyan);
                    inputStr = CommonUtils.GetUserInputString();

                    if (int.TryParse(inputStr, out mark))
                    {
                        if ((mark >= 1) && (mark <= 12))
                        {
                            isDoneParse = true;
                        }
                    }
                }
                while (!isDoneParse);

                currentStudent._marks[markCounter] = mark;
                ++markCounter;
                isDoneParse = false;

                if (markCounter == TestStudentsData.NUM_MARKS)
                {
                    isDoneMarks = true;
                }
            }
            while (!isDoneMarks);

            group.ModifyStudent(pos - 1, currentStudent);
        }
        
        public static void DeleteCommand()
        {
            int pos = 0;
            string inputStr = string.Empty;
            bool isDoneParse = false;
            Student[] studs = group.GetStudents();

            do
            {
                CommonUtils.RefreshScreen();
                CommonUtils.ShowMessage("Students:", ConsoleColor.Cyan);

                for (int i = 0; i < studs.Length; i++)
                {
                    CommonUtils.ShowMessage(string.Format("№{0} - {1}", i + 1, studs[i].PrintStudentInfo()), ConsoleColor.Cyan);
                }

                CommonUtils.ShowMessage("\nEnter student number to delete: ", ConsoleColor.Cyan);
                inputStr = CommonUtils.GetUserInputString();

                if (int.TryParse(inputStr, out pos))
                {
                    if ((pos - 1 >= 0) && (pos - 1 < studs.Length))
                        isDoneParse = true;
                }
            }
            while (!isDoneParse);
            // End of show students;
            group.RemoveStudent(pos - 1);
            CommonUtils.ShowMessage("Student deleted!", ConsoleColor.Cyan);
        }
                
        public static void ShowBestStudentCommand()
        {
            CommonUtils.ShowMessage(string.Format("The best student is:\n{0}", group.GetBestStudentAsString()), ConsoleColor.Cyan);
        }
        public static void ShowWorstStudentCommand()
        {
            CommonUtils.ShowMessage(string.Format("The worst student is:\n{0}", group.GetWorstStudentAsString()), ConsoleColor.Cyan);
        }
    }
}
