using System.Text;
using _20160730_StudentsManagement.Utils;

namespace _20160730_StudentsManagement.DataLayer.Entity
{
    public struct Student
    {
        public int _cardNumber;
        public string _name;
        public string _surname;
        public int[] _marks;

        public string PrintStudentInfo()
        {
            return string.Format("Record book №{0}. {1} {2}, Marks: {3}\n", _cardNumber, _surname, _name, ShowIntArrayAsString(_marks));
        }

        private string ShowIntArrayAsString(int[] arr)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < arr.Length; i++)
            {
                if (i != arr.Length - 1)
                {
                    builder.Append(arr[i] + ", ");
                }
                else
                {
                    builder.Append(arr[i] + ".");
                }
            }

            return builder.ToString();
        }
    }
}
