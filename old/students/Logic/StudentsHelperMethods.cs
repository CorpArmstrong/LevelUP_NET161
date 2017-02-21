using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentsProgress.Data;

namespace StudentsProgress.Logic
{
    public static class StudentsHelperMethods
    {

        public static string[] GetStudents(Data.Common.Student[] students)
        {
            string[] s = new string[students.Length];

            for (int i = 0; i < students.Length; i++)
            {
                s[i] = string.Format("Зачетка №{2}. {0} {1}", students[i]._secondName, students[i]._name, students[i]._recordBookNumber);
            }

            return s;
        }

        public static void StudentsInit(Data.Common.Student[] students)
        {
            #region InitData
            string[] names = new string[]{
                "Петя",
                "Вася",
                "Дима",
                "Юля",
                "Света",
                "Денис",
                "Юра",
                "Коля",
                "Саша",
                "Анжела",
                "Костя",
                "Виталик",
                "Маша"
                };

            string[] secondNames = new string[]{
                "Когут",
                "Цобак",
                "Борщ",
                "Шпак",
                "Миллер",
                "Кличко",
                "Матвиенко",
                "Петренко",
                "Бондаренко"
                };
            #endregion

            for (int i = 0; i < students.Length; i++)
            {
                students[i]._recordBookNumber =Data.Common.randomValue.Next(10000, 99999);
                students[i]._name = names[Data.Common.randomValue.Next(0, names.Length)];
                students[i]._secondName = secondNames[Data.Common.randomValue.Next(0, secondNames.Length)];

                students[i]._studentGrades = new int[Data.Common.randomValue.Next(9, 20)];
                for (int j = 0; j < students[i]._studentGrades.Length; j++)
                {
                    students[i]._studentGrades[j] = Data.Common.randomValue.Next(1, 12);
                }
            }
        }

        public static void RemoveArrayElement(ref Data.Common.Student[] arr, int index = 0)
        {
            Data.Common.Student[] newArray = new Data.Common.Student[arr.Length - 1];

            int j = 0;
            for (int i = 0; i < arr.Length; i++,j++)
            {

                if (index != i)
                {
                    newArray[j]._name = arr[i]._name;
                    newArray[j]._recordBookNumber = arr[i]._recordBookNumber;
                    newArray[j]._secondName = arr[i]._secondName;

                    newArray[j]._studentGrades = new int[arr[i]._studentGrades.Length];
                    Array.Copy(arr[i]._studentGrades,newArray[j]._studentGrades,arr[i]._studentGrades.Length);
                    
                }
                else
                {
                    j--;
                }
            }

            arr = newArray;

        }

        public static void AddArrayElement(ref Data.Common.Student[] arr, Data.Common.Student element)
        {
            Data.Common.Student[] newArray = new Data.Common.Student[arr.Length + 1];
            Array.Copy(arr, newArray, arr.Length);
            newArray[newArray.Length - 1] = element;
            arr = newArray;
        }

        public static int GetBestStudent(Common.Student[] students)
        {
            int[] averageArr = new int[students.Length];

            int indexOfHighestAverage = 0;
            int maxVal = int.MinValue;

            for (int i = 0; i < students.Length; i++)
            {
                int av = CommonHelperMethods.GetAverageValue(students[i]._studentGrades);
                if (maxVal < av)
                {
                    maxVal = av;
                    indexOfHighestAverage = i;
                }
            }

            return indexOfHighestAverage;
        }

        public static int GetWorstStudent(Common.Student[] students)
        {
            int[] averageArr = new int[students.Length];

            int indexOfLowestAverage = 0;
            int minVal = int.MaxValue;

            for (int i = 0; i < students.Length; i++)
            {
                int av = CommonHelperMethods.GetAverageValue(students[i]._studentGrades);
                if (minVal > av)
                {
                    minVal = av;
                    indexOfLowestAverage = i;
                }
            }

            return indexOfLowestAverage;
        }
    }
}
