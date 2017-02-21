using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle_Fedykovich
{
    class Map
    {
        private Player human;
        private Player computer;

        public void SetPlayers(Player human, Player computer)
        {
            this.human = human;
            this.computer = computer;
        }

        public const int s = 13, c = 29;

        public static string[] map = new string[s]
        {
            "  0123456789     0123456789 ",
            " #----------#   #----------#",
            "0|          |  0|          |",
            "1|          |  1|          |",
            "2|          |  2|          |",
            "3|          |  3|          |",
            "4|          |  4|          |",
            "5|          |  5|          |",
            "6|          |  6|          |",
            "7|          |  7|          |",
            "8|          |  8|          |",
            "9|          |  9|          |",
            " #----------#   #----------#",
        };
        

        /*
        public char[,] map = new char[s, c] {
		{"  0123456789     0123456789 "},
		{" #----------#   #----------#"},
		{"0|          |  0|          |"},
		{"1|          |  1|          |"},
		{"2|          |  2|          |"},
		{"3|          |  3|          |"},
		{"4|          |  4|          |"},
		{"5|          |  5|          |"},
		{"6|          |  6|          |"},
		{"7|          |  7|          |"},
		{"8|          |  8|          |"},
		{"9|          |  9|          |"},
		{" #----------#   #----------#"}
        
        };
         * */

        /*
        Äîáàâëåíèå â ìàññèâ map èíôîðìàöèè èç human.ships.
        */
        public void MapInit()
        {
            for (int i = 0; i < Settings.CELL_SIZE; i++)
            {
                for (int j = 0; j < Settings.CELL_SIZE; j++)
                {
                    if (human.ships[i, j] == 2)
                        map[i + 2, j + 2] = 'Ê';
                }
            }
        }

        /*
        Ñíà÷àëà â ìàññèâ maps çàíîñèòñÿ èíôîðìàöèÿ î âûñòðåëàõ ñäåëàííûõ
        ïðîòèâíèêàìè.
        Çàòåì ïðîèñõîäèò âûâîä íà ýêðàí map. ïðè ýòîì èñïîëüçóþòñÿ
        ìàññèâû ships è hits êëàññà player.
        */
        public void ShowMap()
        {
            for (int i = 0; i < Settings.CELL_SIZE; i++)
            {
                for (int j = 0; j < Settings.CELL_SIZE; j++)
                {
                    if (computer.hits[i, j] == 1 && human.ships[i, j] == 3)
                    {
                        map[i + 2, j + 2] = 'Õ';
                    }
                    else if (computer.hits[i, j] == 1 && human.ships[i, j] != 3)
                    {
                        map[i + 2, j + 2] = 'Î';
                    }

                    if (computer.ships[i, j] == 3 && human.hits[i, j] == 1)
                    {
                        map[i + 2, j + 2 + 15] = 'Õ';
                    }
                    else if (computer.ships[i, j] != 3 && human.hits[i, j] == 1)
                    {
                        map[i + 2, j + 2 + 15] = 'O';
                    }
                }
            }

            for (int i = 0; i < s; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    Console.WriteLine(map[i, j]);
                }

                Console.WriteLine(); // \n
            }
        }
    }
}
