using System;
using System.Collections;
using System.Text;

namespace SingleLinkedListDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleLinkedList<string> list = new SingleLinkedList<string>();

            list.AddToBegin("abc");
            list.AddToBegin("dcv");
            list.AddToBegin("dxf");

            list.PrintToConsole();

            list.RemoveByValue("dxf");
            list.PrintToConsole();

            // Bug!
            //list.GetValueByPosition(1);
            //list.PrintToConsole();

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
