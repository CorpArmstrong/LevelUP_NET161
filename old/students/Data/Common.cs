using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentsProgress.Data
{
    public class Common
    {
        public static Random randomValue = new Random();

        public enum TaskIndex : int // коды задач
        {
            NONE = -1,
            REMOVE,
            ADD,
            EDIT,
            BEST_STUDENT,
            WORST_STUDENT,
            AVERAGE_GRADE
        }

        public struct Student
        {
            public int _recordBookNumber;

            public string _name;
            public string _secondName;

            public int[] _studentGrades;

            public string[] GetStudentInfo()
            {
                string[] summary = new string[3 + _studentGrades.Length];

                summary[0] = "Номер зачетной книжки: "+_recordBookNumber.ToString();
                summary[1] = "Имя: " + _name;
                summary[2] = "Фамилия: " + _secondName;

                for (int i = 0; i < _studentGrades.Length; i++)
                {
                    summary[3 + i] = string.Format("Оценка №{0}: {1}", i+1, _studentGrades[i]);
                }

                return summary;
            }

           
        }


    }
}
