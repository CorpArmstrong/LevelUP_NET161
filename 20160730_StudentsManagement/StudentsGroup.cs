using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160730_StudentsManagement
{
    public struct StudentsGroup
    {
        private const int NUM_STUDENTS = 8;
        private const int NUM_MARKS = 5;

        private string[] _names = new string[] { "James", "Lars", "Robert", "Kirk", "Jason", "Cliff", "Tom", "Kerry" };
        private string[] _surnames = new string[] { "Hetfield", "Ulrich", "Trujillo", "Hammett", "Newstead", "Burton", "Arraya", "King" };

        private Student[] _students = null;
        private Random _random = null;

        public StudentsGroup()
        {
            _random = new Random();
            _students = GenerateRandomStudents(NUM_STUDENTS);
        }

        public string[] ShowStudents()
        {
            string[] s = new string[_students.Length];

            for (int i = 0; i < _students.Length; i++)
            {
                s[i] = string.Format("Зачетка №{2}. {0} {1}", _students[i]._surname, _students[i]._name, _students[i]._cardNum);
            }

            return s;
        }

        public void AddStudent(int cardNum, string name, string surname, int[] marks)
        {
            Student[] newArray = new Student[arr.Length + 1];
            Array.Copy(arr, newArray, arr.Length);
            newArray[newArray.Length - 1] = element;
            arr = newArray;
        }

        public void ChangeStudent(int pos)
        {
            /*
            bool isQuit = false;
            string userInput = string.Empty;
            int[] marks = new int[NUM_MARKS];

            Student student = students[pos];

            do
            {
                Console.Clear();
                Console.WriteLine("Enter card number: ");
                userInput = Console.ReadLine();
            }
            while (!int.TryParse(userInput, out student.cardName));

            Console.WriteLine("Enter student name: ");
            student.name = Console.ReadLine();

            Console.WriteLine("Enter student surname: ");
            student.surname = Console.ReadLine();

            for (int i = 0; i < students.Count; i++)
            {
                //
            }

            do
            {
                Console.Clear();
                Console.WriteLine("Enter card number: ");
                userInput = Console.ReadLine();
            }
            while (!int.TryParse(userInput, out student._cardName));
            */
        }

        private Student[] GenerateRandomStudents(int num)
        {
            Student[] students = new Student[num];

            for (int i = 0; i < num; i++)
            {
                students[i] = new Student() { _cardNum = _random.Next(10000, 99999), 
                        _name = _names[i], _surname = _surnames[i], _marks = GenerateRandomMarks(NUM_MARKS) };
            }

            return students;
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
    }
}
