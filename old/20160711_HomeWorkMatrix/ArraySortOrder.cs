using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160711_HomeWorkMatrix
{
    class ArraySortOrder
    {
        private static int SIZE = 10;
        private static Random random = new Random();
        public static void ProcessArray()
        {
            int[] arr = new int[SIZE];

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(-SIZE, SIZE);
            }


        }

        private static int[] FormArray(int[] arr)
        {
            int[] a = new int[arr.Length];

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < 0)
                {
                    a[i] = arr[i];
                }
            }

            //ForSortArray()

            return a;
        }

        private static void ForSortArray(int i, int[] ar1, ref int[] ar2)
        {
            if (ar1[i] < 0)
            {
                ar2[i] = ar1[i];
                i++;
            }
                
            if (ar1[i] > 0)
            {
                ar2[ar2.Length - 1 - i] = ar1[i];
                i++;
            }

            ForSortArray(i, ar1, ref ar2);
        }
    }
}
