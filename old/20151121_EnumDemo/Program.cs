using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _151121_EnumDemo
{
    class Program
    {
        // Single value
        enum Direction : byte
        { 
            Empty = 0,
            Top = 1,       // 1
            Bottom = 20,   //
            Left,          // 21
            Right
        }

        // Mult. value
        [Flags] // - указание компилятору использовать перечисление как набор флагов
        enum DirectionFlag : byte
        {
            Empty = 0x00,
            Top = 0x01,       
            Bottom = 0x02,   
            Left = 0x04,
            Right = 0x08
        }

        static void Main(string[] args)
        {
            // Приведение из byte --> enum
            //byte val = 0;
            //Direction d = (Direction)val;

            
            Direction d = Direction.Left;

            Console.WriteLine("Как байт: {0}", (byte)d);     // enum  -->  byte

            Console.WriteLine("Как строка: {0}", d);     

            switch (d)
            {
                case Direction.Top:
                    Console.WriteLine("Верх");
                    break;
                case Direction.Bottom:
                    Console.WriteLine("Низ");
                    break;
                case Direction.Left:
                    Console.WriteLine("Лево");
                    break;
                case Direction.Right:
                    Console.WriteLine("Право");
                    break;
                case Direction.Empty:
                default:
                    Console.WriteLine("Направление не определено");
                    break;
            }


            Direction d1;
            Console.Write("Enter direction: ");

            // Использование функциональности System.Enum
//            Enum.TryParse(Console.ReadLine(), out d1);
            d1 = Direction.Empty;

            Console.WriteLine("Как строка: {0}", d1.ToString());     

            switch (d1)
            {
                case Direction.Top:
                    Console.WriteLine("Верх");
                    break;
                case Direction.Bottom:
                    Console.WriteLine("Низ");
                    break;
                case Direction.Left:
                    Console.WriteLine("Лево");
                    break;
                case Direction.Right:
                    Console.WriteLine("Право");
                    break;
                case Direction.Empty:
                default:
                    Console.WriteLine("Направление не определено");
                    break;
            }

            // Вывод списка всех "полей" перечисления
            foreach (string item in Enum.GetNames(typeof(Direction)))
            {
                // item - имя очередного поля
                Console.WriteLine("Поле: {0}", item);
            }
            
            // ------------------------------------------------------------
            // Работа с флагами
            // ------------------------------------------------------------

            DirectionFlag dF = DirectionFlag.Right | DirectionFlag.Top;
            
            Console.WriteLine("Как байт: {0}", (byte)dF);     // enum  -->  byte

            Console.WriteLine("Как строка: {0}", dF);

            DirectionFlag dF1 = DirectionFlag.Left | DirectionFlag.Bottom;

            Console.WriteLine("Как байт: {0}", (byte)dF1);     // enum  -->  byte

            Console.WriteLine("Как строка: {0}", dF1);

            if (dF.HasFlag(DirectionFlag.Top | DirectionFlag.Right | DirectionFlag.Left))    //  if ((dF1 & DirectionFlag.Top) != 0)
            {
                Console.WriteLine("Верх, право");
            }            

            if (dF1.HasFlag(DirectionFlag.Top))    //  if ((dF1 & DirectionFlag.Top) != 0)
            {
                Console.WriteLine("Верх");
            }

            if (dF1.HasFlag(DirectionFlag.Right))
            {
                Console.WriteLine("право");
            }

            if (dF1.HasFlag(DirectionFlag.Left))
            {
                Console.WriteLine("Лево");
            }

            if (dF1.HasFlag(DirectionFlag.Bottom))
            {
                Console.WriteLine("Низ");
            }

            //switch (dF)
            //{
            //    case DirectionFlag.Top | DirectionFlag.Right:
            //        Console.WriteLine("Верх, право");
            //        break;
            //    case DirectionFlag.Bottom:
            //        Console.WriteLine("Низ");
            //        break;
            //    case DirectionFlag.Left:
            //        Console.WriteLine("Лево");
            //        break;
            //    case DirectionFlag.Right:
            //        Console.WriteLine("Право");
            //        break;
            //    case DirectionFlag.Empty:
            //    default:
            //        Console.WriteLine("Направление не определено");
            //        break;
            //}


            Console.ReadKey();
        }

        
    }
}
