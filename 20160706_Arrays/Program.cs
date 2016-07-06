using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160706_Arrays
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            int[] a = new int[rnd.Next(10, 100)];
            PrintReverseArray(a);
            Console.WriteLine("---------------------------------------------");
            //FlipEvenAndNotEvenNumbers(a);
            //Console.WriteLine("---------------------------------------------");
            
            PrintArray(a);
            Console.WriteLine("---------------------------------------------");
            FlipMirrorEvenAndNotEvenNumbers(a);
            Console.WriteLine("---------------------------------------------");
            PrintArray(a);
            
            Console.ReadKey();
        }

        static void PrintArray(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
			{
                Console.WriteLine("arr[{0}] = {1,4}", i, arr[i]);
			}
        }

        static void PrintReverseArray(int[] arr)
        {
            for (int i = arr.Length-1; i >= 0; --i)
            {
                arr[i] = rnd.Next(10, 100);
                Console.WriteLine("arr[{0}] = {1,4}", i, arr[i]);
            }
        }

        static void FlipEvenAndNotEvenNumbers(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                // first number even, second not?
                if ((arr[i] % 2 == 0) && (arr[i + 1] % 2 != 0))
                {
                    int tmp = arr[i];
                    arr[i] = arr[i + 1];
                    arr[i + 1] = tmp;
                }

                Console.WriteLine("arr[{0}] = {1,4}", i, arr[i]);
            }
        }

        static void FlipMirrorEvenAndNotEvenNumbers(int[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if ((arr[i] % 2 == 0) && (arr[arr.Length - 1 - i] % 2 != 0))
                {
                    int tmp = arr[i];
                    arr[i] = arr[arr.Length - 1 - i];
                    arr[arr.Length - 1 - i] = tmp;
                    //Console.WriteLine("Test " + arr[i] + " -- " + arr[arr.Length - 1 - i]);
                }
            }
        }
    }
}
