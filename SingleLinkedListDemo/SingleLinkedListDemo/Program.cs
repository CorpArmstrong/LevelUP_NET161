﻿using System;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SingleLinkedListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleLinkedList list = new SingleLinkedList();

            list.AddToBegin(18);
            list.AddToBegin(-18);
            list.AddToBegin(1118);

            //Console.WriteLine("last = {0}", list.ExtractFromEnd());
            //Console.WriteLine("last = {0}", list.ExtractFromEnd());
            //Console.WriteLine("last = {0}", list.ExtractFromEnd());
            //Console.WriteLine("last = {0}", list.ExtractFromEnd());

            foreach (int item in list)
            {
                Console.Write(item + "\t");
            }

            list.RemoveByValue(-18);

            Console.WriteLine();
            if (list is IEnumerable)
            {
                IEnumerator iter = list.GetEnumerator();

                while (iter.MoveNext())
                {
                    Console.Write(iter.Current + "\t");
                }
            }

            

            Console.WriteLine("last = {0}", list.GetFromBegin());
            Console.WriteLine("last = {0}", list.GetFromBegin());
            Console.WriteLine("last = {0}", list.GetFromBegin());
            Console.WriteLine("last = {0}", list.GetFromBegin());

            Console.WriteLine();
            list.PrintToConsole();
            Console.WriteLine();
            Console.WriteLine(list);
            Console.WriteLine();

            list.AddToEnd(25);
            list.AddToEnd(250);
            list.AddToEnd(2547);
            list.AddToEnd(265);

            list.PrintToConsole();
            Console.WriteLine(list);



            Console.ReadKey();
        }
    }
}