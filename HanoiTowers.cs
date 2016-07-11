using System.IO;
using System;

/**
 * Created by CorArmstrong on 11.07.2016.
 */

class Program
{
    
/*
 Данная процедура переносит N дисков со стержня A на стержень C
 пользуясь B как вспомогательным, соблюдая правила.
 процедура "Перенести" (A, B, C, N)

     начало

        если N=1

        // Если диск всего один, то надо его перенести напрямую

        то

            снять диск со стержня A и положить на стержень C;

            возврат из процедуры;

        иначе

            // Переносим все диски, кроме самого большога со стежня

            // A на стержень B

            Перенести (A,C,B,N-1);

            // Переносим самый большой диск со стержня A на стержень C

            снять диск со стержня A и положить на стержень C;

            // Переносим все диски со стержня B на стержень C поверх

            // самого большого диска

            Перенести (B,A,C,N-1);

            возврат из процедуры;

        конец если;

     конец процедуры "Перенести";
*/

    public static char a = 'A';
    public static char b = 'B';
    public static char c = 'C';
    public static int num = 0;

    static void Main()
    {
        Console.Write("Enter number of rings: ");
        //num = int.TryParse//Console.ReadLine();
        int.TryParse(Console.ReadLine(), out num);
        
        Console.WriteLine();
        ProcessHanoi(num, a, b, c);
    }
    
    static void ProcessHanoi(int num, char a, char b, char c)
    {
        if(num > 0)
        {
            ProcessHanoi(num - 1, a, c, b);
            Console.WriteLine("{0}--->{1}\n", a, c);
            ProcessHanoi(num - 1, b, a, c);
        }
    }
}