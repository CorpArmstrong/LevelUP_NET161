using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _20161406_NumberSystemConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            
            string hex = program.ConvertDecToHex();
            string bin = program.ConvertHexToBin(hex);
            Console.ReadKey();
        }

        public string ConvertDecToHex()
        {
            string[] digits = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };
            string inputString = String.Empty;

            int dec = 0x16;
            int chex = 0x16;

            do
            {
                Console.Write("Enter dec number: ");
                inputString = Console.ReadLine();
            }
            while (!int.TryParse(inputString, out dec));

            string hex = String.Empty;

            do
            {
                hex = hex.Insert(0, digits[dec % 16]);
                dec /= 16;
            }
            while (dec != 0);

            int.TryParse(hex, System.Globalization.NumberStyles.HexNumber, null, out chex);
            Console.WriteLine("Result for hex is: {0}", hex);

            //return chex;
            return hex;
        }

        public string ConvertHexToBin(string num)
        {
            //string inputString = Convert.ToString(num);
            string inputString = num;
            char[] hexaDecimal = inputString.ToCharArray();
            string outputString = String.Empty;
            
            Console.Write("Equivalent binary value: ");

            for (int i = 0; i < hexaDecimal.Length; i++)
            {
                switch (hexaDecimal[i])
                {
                    case '0': outputString += "0000"; break;
                    case '1': outputString += "0001"; break;
                    case '2': outputString += "0010"; break;
                    case '3': outputString += "0011"; break;
                    case '4': outputString += "0100"; break;
                    case '5': outputString += "0101"; break;
                    case '6': outputString += "0110"; break;
                    case '7': outputString += "0111"; break;
                    case '8': outputString += "1000"; break;
                    case '9': outputString += "1001"; break;
                    case 'A': outputString += "1010"; break;
                    case 'B': outputString += "1011"; break;
                    case 'C': outputString += "1100"; break;
                    case 'D': outputString += "1101"; break;
                    case 'E': outputString += "1110"; break;
                    case 'F': outputString += "1111"; break;
                    case 'a': outputString += "1010"; break;
                    case 'b': outputString += "1011"; break;
                    case 'c': outputString += "1100"; break;
                    case 'd': outputString += "1101"; break;
                    case 'e': outputString += "1110"; break;
                    case 'f': outputString += "1111"; break;
                    default: Console.Write("Invalid hexadecimal digit {0}", hexaDecimal[i]);
                        break;
                }
            }
            Console.WriteLine("The result in bin: " + outputString);
            return outputString;
        }
    }
}
