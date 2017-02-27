using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace SingleLinkedListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<string> strList = new LinkedList<string>();
            //strList.AddFirst("bfg");
            //strList.AddFirst("xxx");
            //strList.AddFirst("yyy");

            //foreach (string item in strList)
            //{
            //    Console.WriteLine(item);
            //}

            //foreach (string item in strList)
            //{
            //    Console.WriteLine(item);
            //}

            //Console.WriteLine("End of list.");

            SingleLinkedList<string> list = new SingleLinkedList<string>();

            // 1) AddToBegin
            list.AddToBegin("aaa");
            list.AddToBegin("bbb");
            list.AddToBegin("ccc");
            list.PrintToConsole();

            // 2) RemoveByValue
            Console.WriteLine("Remove by value: " + list.RemoveByValue("bbb"));
            list.PrintToConsole();

            // 3) GetValueByPosition
            Console.WriteLine("Get value by position: " + list.GetValueByPosition(1));
            list.PrintToConsole();

            // 4) AddToEnd
            Console.WriteLine("Add to end:");
            list.AddToEnd("endstring");
            list.PrintToConsole();

            // 5) GetFromBegin
            Console.WriteLine("Get from begin: " + list.ExtractFromBegin());
            list.PrintToConsole();
            

            #region Enumerator explanation
            //Console.WriteLine();
            //if (list is IEnumerable)
            //{
            //    IEnumerator iter = list.GetEnumerator();

            //    while (iter.MoveNext())
            //    {
            //        Console.Write(iter.Current + "\t");
            //    }
            //}
            #endregion

            //Console.WriteLine("last = {0}", list.GetFromBegin());
            //Console.WriteLine("last = {0}", list.GetFromBegin());
            //Console.WriteLine("last = {0}", list.GetFromBegin());
            //Console.WriteLine("last = {0}", list.GetFromBegin());

            //Console.WriteLine();
            //list.PrintToConsole();
            //Console.WriteLine();
            //Console.WriteLine(list);
            //Console.WriteLine();

            //list.AddToEnd(25);
            //list.AddToEnd(250);
            //list.AddToEnd(2547);
            //list.AddToEnd(265);

            //list.PrintToConsole();
            //Console.WriteLine(list);

            Console.ReadKey();
        }
    }
}
