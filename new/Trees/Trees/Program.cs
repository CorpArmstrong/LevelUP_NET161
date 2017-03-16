using System;

namespace Trees
{
    class Program
    {
        static void Main(string[] args)
        {
            Tree<string, double> t = new Tree<string, double>();

            t.Add("abs", 1.21);
            t.Add("fabs", 31.21);
            t.Add("klklks", 11.21);
            t.Add("ыыы", 1.1);
            t.Add("asd", 21);
            t.Add("rrr", 1.1);
            t.Add("aaaa", 1.1);
            t.Add("12a", 1.1);

            //t.PrintToConsole();
            Console.WriteLine(t);
            Console.ReadKey();
        }
    }
}
