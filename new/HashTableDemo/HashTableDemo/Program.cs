using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashTableDemo
{
    class Program
    {
        static int hashSize;

        static void Main(string[] args)
        {
        //    char ch = Console.ReadKey().KeyChar;

            Console.Write("Enter line:");
            string s = Console.ReadLine();

            string[] words = s.Split(' ', ',');

            hashSize = char.MaxValue;

            string[] hashWords = new string[hashSize];

            foreach (string w in words)
            {
                if (w != "")
                {
                    hashWords[HashFunc(w)] = w;   /// Add
                }
            }

            Console.Write("Enter word:");
            string word = Console.ReadLine();

            Console.WriteLine("Line search:");
            foreach (string w in words)
            {
                if (w == word)
                {
                    Console.WriteLine("Word is exist");
                }
            }

            Console.WriteLine("Work with hash:");
            if (hashWords[HashFunc(word)] != null)
            {
                Console.WriteLine("Word is exist");
            }

            object o;

            Console.ReadKey();
        }

        static int HashFunc(string s)
        {
            return (s[0] + s[1]) % hashSize;
        }
    }
}
