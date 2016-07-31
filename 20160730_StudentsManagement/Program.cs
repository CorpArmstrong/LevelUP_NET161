using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160730_StudentsManagement
{
    class Program
    {
        static void Main()
        {
            Program prg = new Program();
            prg.MainMenu();
            Console.ReadKey();
        }

        public void MainMenu()
        {
            bool isQuit = false;
            string userInput = null;
            bool labelPassed = false;

            Deanery deanery = new Deanery();

            do
            {
                Console.Clear();

                Console.WriteLine("Enter SHOW to show all students.");
                Console.WriteLine("Enter ADD to add student.");
                Console.WriteLine("Enter MOD to modify student.");
                Console.WriteLine("Enter DEL to delete student.");
                Console.WriteLine("Enter FIL to filter students.");
                Console.WriteLine("Enter QUIT to quit the application.");

                userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case "show":
                        deanery.ShowStudents();
                        labelPassed = true;
                        break;
                    case "add":
                        //SetupWorkDay();
                        labelPassed = true;
                        break;
                    case "mod":
                        //PrintWorkDay();
                        labelPassed = true;
                        break;
                    case "del":
                        //PrintSchedule();
                        labelPassed = true;
                        break;
                    case "fil":
                        //ProcessPassword();
                        labelPassed = true;
                        break;
                    case "quit":
                        Console.WriteLine("Goodbye!");
                        isQuit = true;
                        break;
                    default:
                        Console.WriteLine("Incorrect command, please repeat!");
                        break;
                }

                if (!labelPassed)
                {
                    Console.ReadKey();
                }
                labelPassed = false;
            }
            while (!isQuit);
        }
    }
}
