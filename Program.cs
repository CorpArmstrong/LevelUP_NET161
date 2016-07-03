using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionHomework
{
	class Program
	{
		static int EnterInt(int minValue = int.MinValue, int maxValue = int.MaxValue, string request = "Введите целое число")
		{
			int result;
			string s;
            bool firstTry = true;
            //string limits = ((minValue == int.MinValue) ? "" : " от " + minValue.ToString())
            //    + ((maxValue == int.MaxValue) ? "" : " до " + maxValue.ToString())
            string limits = string.Empty;
            if (minValue != int.MinValue)
            {
                limits += " от " + minValue.ToString();
            }
            if (maxValue != int.MaxValue)
            {
                limits += " до " + maxValue.ToString();
            }
			do
			{
				if(!firstTry)
				{
					Console.Write("Некорректное число. ");
				}
				Console.Write("{0}{1}: ", request, limits);
				s = Console.ReadLine();
				firstTry = false;
			} while (!(int.TryParse(s, out result) && result >= minValue && result <= maxValue));
			return result;

		}

		static void Main(string[] args)
		{
            int number11 = EnterInt();
			int number1 = EnterInt(0, 100);
            int number3 = EnterInt(-10);
			int number2 = EnterInt(request: "Еще одно число, пожалуйста");
			Console.WriteLine("n1 = {0}, n2 = {1}", number1, number2);
			Console.WriteLine("Press any key");
			Console.ReadKey();
		}
	}
}
