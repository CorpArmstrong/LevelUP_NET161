using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _20160622_PwdDemo
{
    class Program
    {
        const short PWD_MASK = 0x1234;    // маска для шифрования

        static void Main(string[] args)
        {
            string pwd = "my_pwd";    // Исходный пароль

            string pwd_ = string.Empty;    // string pwd_ = "";  -- модифицированный пароль 

            for (int i = 0; i < pwd.Length; i++)
            {
                Console.WriteLine("pwd[i] = {0} ({1:X}), xor = {2:X}", pwd[i], (short)pwd[i], (short)pwd[i] ^ PWD_MASK);

                int new_char  = (short)pwd[i] ^ PWD_MASK;

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

        }
    }
}
