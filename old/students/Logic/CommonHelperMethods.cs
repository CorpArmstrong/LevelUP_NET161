using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProgress.Logic
{
    public static class CommonHelperMethods
    {
        public static void RemoveIntArrayElement(ref int[] arr, int index = 0)
        {
            int[] newArray = new int[arr.Length - 1];

            int j = 0;
            for (int i = 0; i < arr.Length; i++, j++)
            {
                if (index - 3 != i)
                {
                    newArray[j] = arr[i];
                }
                else
                {
                    j--;
                }
            }

            arr = newArray;
        }

        public static void AddIntArrayElement(ref int[] arr, int value)
        {
            int[] newArray = new int[arr.Length + 1];

            Array.Copy(arr, newArray, arr.Length);

            newArray[newArray.Length - 1] = value;

            arr = newArray;
        }

        public static int GetAverageValue(int[] arr)
        {
            int average = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                average += arr[i];
            }
            return average/arr.Length;
        }
    }
}
