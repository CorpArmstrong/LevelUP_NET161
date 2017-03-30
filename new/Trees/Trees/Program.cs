using System;
using System.Collections.Generic;

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

            t.RemoveKey("asd");
            Console.WriteLine(t);

            // Last edit:
            Console.WriteLine("Value for key: abs = " + t["abs"]);
            t["abs"] = 1.31;
            Console.WriteLine("New value for key: abs = " + t["abs"]);

            Console.WriteLine();
            Console.WriteLine("Keys:");

            // Get Keys:
            foreach (string item in t.Keys)
            {
                Console.Write("[{0}]\t", item);
            }

            Console.WriteLine();
            Console.WriteLine("Values:");

            // Get Values:
            foreach (double item in t.Values)
            {
                Console.Write("[{0}]\t", item);
            }

            // Contains Key:
            Console.WriteLine();
            Console.WriteLine("Dictionary t contains key {0} ? {1}", 21d, t.ContainsKey("21"));

            // Contains:
            Console.WriteLine();
            Console.WriteLine("Dictionary t contains KeyValuePair<{0}, {1}> ? {2}",
                "rrr", 1.8, t.Contains(new KeyValuePair<string, double>("rrr", 1.8)));

            Console.WriteLine();
            Console.WriteLine("Dictionary t contains KeyValuePair<{0}, {1}> ? {2}",
                "rrr", 1.1, t.Contains(new KeyValuePair<string, double>("rrr", 1.1)));

            // Count:
            Console.WriteLine();
            Console.WriteLine("Dictionary t consist of {0} elements", t.Count);

            // TryGetValue:
            Console.WriteLine();
            double hasValue = 0d;
            Console.WriteLine("Dictionary t has value {0} ? {1}", 31.21, t.TryGetValue("fabs", out hasValue));

            Console.ReadKey();
        }
    }
}
