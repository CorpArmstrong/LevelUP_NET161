using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20160730_StudentsManagement
{
    public struct Student
    {
        public int _cardNum;
        public string _name;
        public string _surname;
        public int[] _marks;

        public override string ToString()
        {
            string s = string.Format("Student: ({0}, {1}, {2}, {3})", _name, _surname, _cardNum, _marks);
            return s;
        }
    }
}
