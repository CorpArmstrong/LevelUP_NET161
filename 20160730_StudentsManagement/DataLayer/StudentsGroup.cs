using System;
using System.Text;

using _20160730_StudentsManagement.Utils;
using _20160730_StudentsManagement.DataLayer.Entity;
using _20160730_StudentsManagement.DataLayer.TestData;

namespace _20160730_StudentsManagement
{
    public struct StudentsGroup
    {
        private Student[] _students;
        private Random _random;

        public void SetRandom(Random random)
        {
            this._random = random;
        }

        public static StudentsGroup InitStudentsGroup
        {
            get
            {
                StudentsGroup group = new StudentsGroup();
                group.SetRandom(new Random());
                group.GenerateAndSetRandomStudents(TestStudentsData.NUM_STUDENTS);
                return group;
            }
        }

        public Student[] GetStudents()
        {
            return _students;
        }

        #region "Students Methods"

        public string ShowStudents()
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < _students.Length; i++)
            {
                builder.Append(_students[i].PrintStudentInfo());
            }

            return builder.ToString();
        }

        public void AddStudent(Student studentToAdd)
        {
            Student[] newArray = new Student[_students.Length + 1];
            Array.Copy(_students, newArray, _students.Length);
            newArray[newArray.Length - 1] = studentToAdd;
            _students = newArray;
        }

        public void ModifyStudent(int pos, Student modifiedStudent)
        {
            _students[pos] = modifiedStudent;
        }

        public void RemoveStudent(int pos = 0)
        {
            Student[] newArray = new Student[_students.Length - 1];

            int j = 0;

            for (int i = 0; i < _students.Length; i++, j++)
            {
                if (pos != i)
                {
                    newArray[j]._name = _students[i]._name;
                    newArray[j]._cardNumber = _students[i]._cardNumber;
                    newArray[j]._surname = _students[i]._surname;
                    newArray[j]._marks = new int[_students[i]._marks.Length];
                    Array.Copy(_students[i]._marks, newArray[j]._marks, _students[i]._marks.Length);
                }
                else
                {
                    j--;
                }
            }

            _students = newArray;
        }

        public string GetBestStudentAsString()
        {
            int[] averageArr = new int[_students.Length];

            int indexOfHighestAverage = 0;
            int maxVal = int.MinValue;

            for (int i = 0; i < _students.Length; i++)
            {
                int av = CommonUtils.GetAverageValue(_students[i]._marks);
                
                if (maxVal < av)
                {
                    maxVal = av;
                    indexOfHighestAverage = i;
                }
            }

            return _students[indexOfHighestAverage].PrintStudentInfo();
        }

        public string GetWorstStudentAsString()
        {
            int[] averageArr = new int[_students.Length];

            int indexOfLowestAverage = 0;
            int minVal = int.MaxValue;

            for (int i = 0; i < _students.Length; i++)
            {
                int av = CommonUtils.GetAverageValue(_students[i]._marks);
                
                if (minVal > av)
                {
                    minVal = av;
                    indexOfLowestAverage = i;
                }
            }

            return _students[indexOfLowestAverage].PrintStudentInfo();
        }

        private void GenerateAndSetRandomStudents(int num)
        {
            Student[] students = new Student[num];

            for (int i = 0; i < num; i++)
            {
                students[i] = new Student() { _cardNumber = _random.Next(10000, 99999),
                                              _name = TestStudentsData.names[i],
                                              _surname = TestStudentsData.surnames[i],
                                              _marks = GenerateRandomMarks(TestStudentsData.NUM_MARKS)
                };
            }

            _students = students;
        }

        private int[] GenerateRandomMarks(int num)
        {
            int[] arr = new int[num];

            for (int i = 0; i < num; i++)
            {
                arr[i] = _random.Next(1, 12);
            }

            return arr;
        }

        #endregion
    }
}
