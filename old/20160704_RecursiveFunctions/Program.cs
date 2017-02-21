using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160704_RecursiveFunctions
{
    class Program
    {
        static void f()
        {
            f();
        }

        static void Main(string[] args)
        {
            // Infinite recursion!
            //f();

            int n = 10;
            int s = 0;

            MyFor(0, n, ref s);

            Console.WriteLine("Factorial of {0} is {1}", n, Factorial(n));
            Console.ReadKey();
        }

        static void MyFor(int i, int n, ref int s)
        {
            if (i >= n)
            {
                // break recursion
                return;
            }
            else
            {
                // loop body
                s += i;
                Console.WriteLine(s);
                MyFor(i + 1, n, ref s);
            }
        }

        static int Factorial(int n)
        {
            //int fact = 0;
            
            if (n == 0)
            {
                return 1;
            }
            
            return n * Factorial(n - 1);
        }
    }
}
