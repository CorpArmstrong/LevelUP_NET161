using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle_Fedykovich
{
    class Program
    {
        Player human;
        Player computer;
        public Map battleMap;

        // ââîä êîîðäèíàò
        int CheckInput(char character, char digit)
        {
            character = Console.ReadKey(true);//_getche(); // ââîä "ãîðèçîíòàëüíîé" êîîðäèíàòû
	        int match = 0;
	
	        for (int i = 0; i < Settings.CELL_SIZE; i++)
		    if (Settings.numbers[i] == character)
		    {
			    match = 1;
		    	character = i;
		    }
	        if (match == 0)	
	    	return 1;
	
	        Console.Write("-");
        	match = 0;
            digit = Console.ReadKey(true);//_getche(); // ââîä "âåðòèêàëüíîé" êîîðäèíàòû
	
	        for (int i = 0; i < Settings.CELL_SIZE; i++)
		        if (Settings.numbers[i] == digit)
		        {
			        match = 1;
		        	digit = i;
		        }
	        if (match == 0)
		        return 1;
	        return 0;	
        }

        // Â ôóíêöèè óñòàíàâëèâàþòñÿ è ïðîâåðÿþòñÿ ôëàãè defeat_flag èãðîêîâ.
        int CheckEnding()
        {
	        int flag = 0;
        	int human_flag = 0;
	        int computer_flag = 0;

	        for (int i = 0; i < Settings.CELL_SIZE; i++)
	        {
		        for (int j = 0; j < Settings.CELL_SIZE; j++)
	        	{
			        if (human.ships[i, j] == 2)
			        	human_flag = 1; // ó ïîëüçîâàòåëÿ åù¸ îñòàëèñü íåïîâðåæä¸ííûå êîðàáëè
			        if (computer.ships[i, j] == 2)
			        	computer_flag = 1; // ó êîìïüþòåðà åù¸ îñòàëèñü íåïîâðåæä¸ííûå êîðàáëè
		        }
	        }

	        if (human_flag == 0)
		        flag = 2;
	        if (computer_flag == 0)
		        flag = 1;
	        if (flag == 1)
	        {
                Console.WriteLine("Ïîáåäèë èãðîê!");
		        return 2;
	        }
	        if (flag == 2)
	        {
                Console.WriteLine("Ïîáåäèë êîìïüþòåð!");
		        return 2;
            }
        }

        static void Main(string[] args)
        {
            Program program = new Program();
            program.battleMap = new Map();

	        int message = 0; // ïåðåìåííàÿ õðàíèò êîäû ñîîáùåíèé

	        program.human.ShipsInit(); // èíèöèàëèçàöèÿ ìàññèâîâ ÷åëîâåêà
	        program.computer.ShipsInit(); // èíèöèàëèçàöèÿ ìàññèâîâ êîìïüþòåðà

            // Added!
            program.battleMap.SetPlayers(program.human, program.computer);

            program.battleMap.MapInit(); // äîáàâëåíèå â ìàññèâ map èíôîðàöèè èçè human.ships

	        /*
	        message ìîæåò ñîäåðæàòü òðè çíà÷åíèÿ:
	        0 - âñ¸ íîðìàëüíî
	        1 - ïîëüçîâàòåëü íàæàë íåâåðíóþ êëàâèøó
	        2 - êòî-òî ïîáåäèë, êîíåö èãðû
	        */
        	while (message != 2)
	        {
		        int user_input = 0;
                Console.Clear();
		        
                program.battleMap.ShowMap();
		
		        if (message == 1) // êîä ñîîáùåíèÿ 1 - ââåäåíî íåâåðíîå çíà÷åíèå
                    Console.WriteLine("Âû ââåëè íåâåðíîå çíà÷åíèå!");
		
		        message = 0;   // îáíóëåíèå message

		        char character, digit;
		        user_input = program.CheckInput(character, digit); // !!!ïåðåìåííûå ïåðåäàþòñÿ ïî ññûëêå
		
		        if (user_input == 1)
	        	{
			        message = 1;
			        continue; 
		        }

		        program.human.Turn(program.computer, character, digit);
		        program.computer.Turn(program.human);
		        
                message = program.CheckEnding();
	        }

	        //_getch();
            Console.ReadKey(true);
        }
    }
}
