using System;

namespace DurakGame
{
    struct CardDeck
    {
        public const int CARDS_NUM = 52; 
        public Card[] _cards;  // 36 or 50 cards
        int _countCardsLeft;

        //Card GiveAwayCard();
        //void Shuffle();
        //void AddCard(Card card);
        //bool IsEmpty();
        /*
        Card DealCard()
        {
            Card card = null;

            if (deck.size() > 0)
            {
                card = deck.remove(deck.size() - 1);
            }

            return card;
        }
        */

        public void InitCardDeck()
        {
            _cards = GenerateCards();
            _countCardsLeft = _cards.Length;
        }

        public Card[] GenerateCards()
        {
            Card[] cards = new Card[CARDS_NUM];
            int[] cardValues = (int[])Enum.GetValues(typeof(Card.CardValue));
            int[] suitValues = (int[])Enum.GetValues(typeof(Card.Suit));

            int counter = 0;

            while (counter < 52)
            {                
                for (int j = 0; j < cardValues.Length; j++)
                {
                    for (int k = 0; k < suitValues.Length; k++)
                    {
                        Card currentCard = new Card();
                        currentCard._cardValue = (Card.CardValue)cardValues[j];
                        currentCard._cardSuite = (Card.Suit)suitValues[k];

                        cards[counter] = currentCard;
                        ++counter;
                    }
                }                
            }

            return cards;
        }


        public void ShowCards()
        {
            Console.WriteLine("All cards:");
            for (int i = 0; i < _cards.Length; i++)
            {
                Console.WriteLine("Card num {0}, value {1}, suit {2}", i+1, _cards[i]._cardValue.ToString(), _cards[i]._cardSuite.ToString());
            }
            Console.WriteLine("End of cards.");
        }
    }
}
