using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160622_EnumsDayOfWeekBitOperation
{
    class Program
    {
        private const short PWD_MASK = 0x1234;    // маска для шифрования
        private string PWD_STRING = "MyWordIsMyPassword123";

        private static byte schedule = 0x00;    // 00000000

        private const byte MONDAY = 0x01;       // 00000001;
        private const byte TUESDAY = 0x02;      // 00000010;
        private const byte WEDNESDAY = 0x04;    // 00000100;
        private const byte THURSDAY = 0x08;     // 00001000;
        private const byte FRIDAY = 0x10;       // 00010000;
        private const byte SATURNDAY = 0x20;    // 00100000;
        private const byte SUNDAY = 0x40;       // 01000000;

        private static string[] days = new string[] { "1", "2", "3", "4", "5", "6", "7" };
        private static byte[] bdays = new byte[] { MONDAY, TUESDAY, WEDNESDAY, THURSDAY, FRIDAY, SATURNDAY, SUNDAY };

        private static byte password = 0x33;    // 00110011 //51
        private static byte mask = 0x24;        // 00100100 //36

        private static byte convertedPwd = (byte)(password ^ mask);

        private enum DaysOfWeek
        {
            Monday,
            Tuesday,
            Wednesday,
            Thursday,
            Friday,
            Saturday,
            Sunday
        }

        static void Main(string[] args)
        {
            Program prg = new Program();
            prg.MainMenu();
        }

        public void MainMenu()
        {
            bool isQuit = false;
            string userInput = null;
            bool labelPassed = false;

            do
            {
                Console.Clear();

                Console.WriteLine("Enter SETUP to set school day.");
                Console.WriteLine("Enter PRINT to print is there is a lesson on that day.");
                Console.WriteLine("Enter SCHEDULE to set school day.");
                Console.WriteLine("Enter PASSWORD to show password demo.");
                Console.WriteLine("Enter QUIT to quit the application.");

                userInput = Console.ReadLine().ToLower();

                switch (userInput)
                {
                    case "setup":
                        SetupWorkDay();
                        labelPassed = true;
                        break;
                    case "print":
                        PrintWorkDay();
                        labelPassed = true;
                        break;
                    case "schedule":
                        PrintSchedule();
                        labelPassed = true;
                        break;
                    case "password":
                        //CheckPassword();
                        ProcessPassword();
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

        private void ProcessPassword()
        {
            Console.Clear();
            string pwd_ = string.Empty;    // string pwd_ = "";  -- модифицированный пароль 

            for (int i = 0; i < PWD_STRING.Length; i++)
            {
                Console.WriteLine("pwd[i] = {0} ({1:X}), xor = {2:X}", PWD_STRING[i], (short)PWD_STRING[i], (short)PWD_STRING[i] ^ PWD_MASK);

                int new_char = (short)PWD_STRING[i] ^ PWD_MASK;

                pwd_ += (char)new_char;

            }

            Console.WriteLine("pwd_ = {0}", pwd_);


            string pwd__ = string.Empty;

            for (int i = 0; i < pwd_.Length; i++)
            {
                Console.WriteLine("pwd[i] = {0} ({1:X}), xor = {2:X}", pwd_[i], (short)pwd_[i], (short)pwd_[i] ^ PWD_MASK);

                int new_char = (short)pwd_[i] ^ PWD_MASK;

                pwd__ += (char)new_char;

            }

            Console.WriteLine("pwd__ = {0}", pwd__);
            Console.ReadKey();
        }

        public void SetupWorkDay()
        {
            bool isQuitSetupWorkDay = false;
            bool isFound = false;
            string userInput = null;

            do
            {
                Console.Clear();
                Console.WriteLine("Enter number from 1 to 7 to setup a lesson on that day.");
                Console.WriteLine("Enter return - to return to main menu.");

                userInput = Console.ReadLine().ToLower();

                if (userInput.Equals("return"))
                {
                    isQuitSetupWorkDay = true;
                }
                else
                {
                    for (int i = 0; i < days.Length; i++)
                    {
                        if (userInput.Equals(days[i]))
                        {
                            isFound = true;
                            schedule |= bdays[i];
                            Console.WriteLine("On day {0} lesson is set!", userInput);
                        }
                    }
                }

                if (!isFound && !userInput.Equals("return"))
                {
                    Console.WriteLine("Incorrect command, please repeat!");
                }

                isFound = false;

                if (!isQuitSetupWorkDay)
                {
                    Console.ReadKey();
                }
            }
            while (!isQuitSetupWorkDay);
        }

        public void PrintWorkDay()
        {
            bool isQuitPrintWorkDay = false;
            bool isFound = false;
            string userInput = null;

            do
            {
                Console.Clear();
                Console.WriteLine("Enter number from 1 to 7 to setup a lesson on that day.");
                Console.WriteLine("Enter return - to return to main menu.");

                userInput = Console.ReadLine().ToLower();

                if (userInput.Equals("return"))
                {
                    isQuitPrintWorkDay = true;
                }
                else
                {
                    for (int i = 0; i < days.Length; i++)
                    {
                        if (userInput.Equals(days[i]))
                        {
                            isFound = true;
                            CheckWorkDay(userInput, i);
                        }
                    }
                }

                if (!isFound && !userInput.Equals("return"))
                {
                    Console.WriteLine("Incorrect command, please repeat!");
                }

                isFound = false;

                if (!isQuitPrintWorkDay)
                {
                    Console.ReadKey();
                }
            }
            while (!isQuitPrintWorkDay);
        }

        public void CheckWorkDay(string userInput, int index)
        {
            if ((schedule & bdays[index]) > 0)
            {
                Console.WriteLine("On day {0} is a work day!", userInput);
            }
            else
            {
                Console.WriteLine("On day {0} is not a work day!", userInput);
            }
        }

        public void PrintSchedule()
        {
            Console.Clear();
            StringBuilder sb = new StringBuilder();
            
            for (int i = 0; i < bdays.Length - 1; i++)
            {
                if ((schedule & bdays[i]) > 0)
                {
                    sb.Append((DaysOfWeek)i + "\n");
                }
            }

            Console.WriteLine("There are work days:\n\n" + sb.ToString());
            Console.ReadKey();
        }

        public void CheckPassword()
        {
            string userInput = null;
            bool isQuitCheckPassword = false;

            do
            {
                Console.Clear();
                Console.WriteLine("Enter mask to reveal a password\nOr type return to return to main menu.");
                userInput = Console.ReadLine().ToLower();

                if (userInput.Equals(mask.ToString()))
                {
                    Console.WriteLine("Mask correct!");
                    Console.WriteLine("Encrypted password: {0}", convertedPwd);
                    Console.WriteLine("Decrypted password: {0}", (byte)(convertedPwd ^ mask));
                }
                else
                {
                    Console.WriteLine("Password incorrect!\nTry Again!");
                }

                if (userInput.Equals("return"))
                {
                    isQuitCheckPassword = true;
                }

                if (!isQuitCheckPassword)
                {
                    Console.ReadKey();
                }
            }
            while (!isQuitCheckPassword);
        }
    }
}
