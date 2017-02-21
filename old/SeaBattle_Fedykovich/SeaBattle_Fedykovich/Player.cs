using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle_Fedykovich
{
    class Player
    {
        bool defeat_flag = false;

        public int[,] hits = new int[Settings.CELL_SIZE, Settings.CELL_SIZE];
        public int[,] ships = new int[Settings.CELL_SIZE, Settings.CELL_SIZE];

        Random random = new Random();

        public void ShipsInit()
        {
            // èíèöèàëèçàöèÿ ìàññèâîâ hits è ships
            for (int i = 0; i < Settings.CELL_SIZE; i++)
            {
                for (int j = 0; j < Settings.CELL_SIZE; j++)
                {
                    ships[i, j] = 1;
                    hits[i, j] = 0;
                }
            }

            Set(4);
            Set(3);
            Set(3);
            Set(2);
            Set(2);
            Set(2);
            Set(1);
            Set(1);
            Set(1);
            Set(1);
        }

        void Set(int deck)
        {
            int my = deck - 1;
            bool isSet = false;
            int s, c;
            Settings.direction dir;

            while (!isSet)
            {
                int enumLenght = Enum.GetNames(typeof(Settings.direction)).Length;
                dir = (Settings.direction)random.Next(enumLenght);//static_cast<direction>(rand() % 2); // âûáèðàåì íàïðàâëåíèå

                s = random.Next(10);//rand() % 10; // ñëó÷àéíûì îáðàçîì îïðåäåëÿþòñÿ êîîðäèíàòû
                c = random.Next(10);//rand() % 10;

                int e = 0;

                switch (dir)
                {
                    case Settings.direction.HORIZONTAL:

                        if (ships[s, c + deck - 1] == 1)
                        {
                            e = PlaceShip(s, c, dir, deck); // ïðîâåðêà ñìåæíûõ êëåòîê

                            if (e == 0)
                            {
                                for (int i = 0; i < deck; i++)
                                {
                                    ships[s, c + i] = 2; // ðàçìåùàåì êîðàáëü â ìàññèâå ships
                                }

                                isSet = true;
                            }
                        }
                        break;

                    case Settings.direction.VERTICAL:
                        if (ships[s + deck - 1, c] == 1)
                        {
                            e = PlaceShip(s, c, dir, deck);

                            if (e == 0)
                            {
                                for (int i = 0; i < deck; i++)
                                {
                                    ships[s + i, c] = 2;
                                }

                                isSet = true;
                            }
                        }
                        break;
                }
            }
        }

        /*
        Ôóíêöèÿ ïðîâåðÿåò, ìîæíî ëè â äàííîé êîîðäèíàòå [s][c]
        ðàçìåñòèòü êîðàáëü ñ ïàëóáàìè deck.
        Â êîììåíòàðèÿõ ïîêàçàíî êàêèå êëåòêè ïðîâåðÿþòñÿ ïðè óñòàíîâêå
        ÷åòûð¸õïàëóáíîãî êîðàáëÿ â [4][3]
        */
        public int PlaceShip(int s, int c, Settings.direction dir, int deck)
        {
            int e = 0;

            switch (dir)
            {
                case Settings.direction.HORIZONTAL:
                    if (ships[s - 1, c - 1] == 2)
                    {
                        e = 1;
                        /*
                          345678
                         #-------
                        2|X      
                        3| 2222    
                        4|      
                        */
                    }
                    if (ships[s - 1, c + deck] == 2)
                    {
                        e = 1;
                        /*
                          345678
                         #-------
                        2|     X 
                        3| 2222    
                        4|      
                        */
                    }
                    if (ships[s + 1, c - 1] == 2)
                    {
                        e = 1;
                        /*
                          345678
                         #-------
                        2|      
                        3| 2222    
                        4|X     
                        */
                    }
                    if (ships[s + 1, c + deck] == 2)
                    {
                        e = 1;
                        /*
                          345678
                         #-------
                        2|      
                        3| 2222    
                        4|     X 
                        */
                    }

                    if (ships[s, c - 1] == 2)
                    {
                        e = 1;
                        /*
                          345678
                         #-------
                        2|      
                        3|X2222    
                        4|      
                        */
                    }
                    if (ships[s, c + deck] == 2)
                    {
                        e = 1;
                        /*
                          345678
                         #-------
                        2|      
                        3| 2222X    
                        4|      
                        */
                    }
                    for (int i = 0; i < deck; i++)
                    {
                        if (ships[s - 1, c + i] == 2)
                        {
                            e = 1;
                            /*
                              345678
                             #-------
                            2| XXXX     
                            3| 2222    
                            4|      
                            */
                        }
                        if (ships[s + 1, c + i] == 2)
                        {
                            e = 1;
                            /*
                              345678
                             #-------
                            2|      
                            3| 2222    
                            4| XXXX     
                            */
                        }
                    }
                    break;
                case Settings.direction.VERTICAL:
                    if (ships[s - 1, c - 1] == 2)
                    {
                        e = 1;
                        /*
                          345678
                         #-------
                        2|X      
                        3| 2    
                        4| 2   
                        5| 2     
                        6| 2    
                        7|     
                        */
                    }
                    if (ships[s - 1, c + 1] == 2)
                    {
                        e = 1;
                        /*
                          345678
                         #-------
                        2|  X    
                        3| 2    
                        4| 2   
                        5| 2     
                        6| 2    
                        7| X    
                        */
                    }
                    if (ships[s + deck, c - 1] == 2)
                    {
                        e = 1;
                        /*
                          345678
                         #-------
                        2|      
                        3| 2    
                        4| 2   
                        5| 2     
                        6| 2    
                        7|X     
                        */
                    }
                    if (ships[s + deck, c + 1] == 2)
                    {
                        e = 1;
                        /*
                          345678
                         #-------
                        2|      
                        3| 2    
                        4| 2   
                        5| 2     
                        6| 2    
                        7|  X   
                        */
                    }

                    if (ships[s - 1, c] == 2)
                    {
                        e = 1;
                        /*
                          345678
                         #-------
                        2| X     
                        3| 2    
                        4| 2   
                        5| 2     
                        6| 2    
                        7|     
                        */
                    }
                    if (ships[s + deck, c] == 2)
                    {
                        e = 1;
                        /*
                          345678
                         #-------
                        2|      
                        3| 2    
                        4| 2   
                        5| 2     
                        6| 2    
                        7| X    
                        */
                    }
                    for (int i = 0; i < deck; i++)
                    {
                        if (ships[s + i, c - 1] == 2)
                        {
                            e = 1;
                            /*
                              345678
                             #-------
                            2|      
                            3|X2    
                            4|X2   
                            5|X2     
                            6|X2    
                            7|     
                            */
                        }
                        if (ships[s + i, c + 1] == 2)
                        {
                            e = 1;
                            /*
                              345678
                             #-------
                            2|      
                            3| 2X    
                            4| 2X   
                            5| 2X     
                            6| 2X    
                            7|     
                            */
                        }
                    }
                    break;
            }
            return e;
        }

        // Õîä êîìïüþòåðà: âíîñèì èçìåíåíèÿ â ìàññèâû human.ships è computer.hits
        public void Turn(Player enemy)
        {
            bool flag = false;

            while (!flag)
            {
                int character = random.Next(Settings.CELL_SIZE);//rand() % Settings.CELL_SIZE; // Êîîðäèíàòû ïî êîòîðûì áóäåò ñòðåëÿòü êîìïüþòåð
                int digit = random.Next(Settings.CELL_SIZE);//rand() % Settings.CELL_SIZE;     // âûáèðàþòñÿ ñëó÷àéíî

                if (hits[character, digit] != 1) // ïðîâåðêà: âûáèðàë ëè óæå êîìïüþòåð ýòè êîîðäèíàòû
                {
                    hits[character, digit] = 1;

                    flag = true;

                    if (enemy.ships[character, digit] == 2)
                    {
                        enemy.ships[character, digit] = 3;
                    }
                }
            }
        }

        // Õîä èãðîêà: âíîñèì èçìåíåíèÿ â ìàññèâû computer.ships è human.hits
        public void Turn(Player enemy, int character, int digit)
        {
            hits[character, digit] = 1;

            if (enemy.ships[character, digit] == 2)
            {
                enemy.ships[character, digit] = 3;
            }
        }

    }
}
