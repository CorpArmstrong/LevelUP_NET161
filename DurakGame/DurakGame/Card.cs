using System;

namespace DurakGame
{
    struct Card
    {
        public enum Suit
        {
            Hearts,
            Clubs,
            Diamonds,
            Spades
        }

        public enum CardValue
        {
            Two,
            Three,
            Four,
            Five,
            Six,
            Seven,
            Eight,
            Nine,
            Ten,
            Jack,
            Queen,
            King,
            Ace
        }

        public Suit _cardSuite;
        public CardValue _cardValue;
        public bool _isTrump;

        //string GetSuitString() { }
        //string ToString();

        /*
        int compareTo(Card cardToCompare)
        {
            Card c2 = cardToCompare;

            if (_suit < c2._suit)
            {
                return -1;
            }

            if (_suit > c2._suit)
            {
                return 1;
            }
            if (rank > c2.rank)
            {
                return 1;
            }
            if (rank < c2.rank)
            {
                return -1;
            }

            return 0;
        }
        */

        string GetSuitString()
        {
            String str = null;

            switch (_cardSuite)
            {
                case Suit.Hearts:
                    str = "Hearts";
                    break;
                case Suit.Clubs:
                    str = "Clubs";
                    break;
                case Suit.Diamonds:
                    str = "Diamonds";
                    break;
                case Suit.Spades:
                    str = "Spades";
                    break;
                default:
                    str = "Fatal error!!!";
                    break;
            }

            return str;
        }

        /*
        bool CompareTo(Card firstSuit, Card c2)
        {
            return suit == firstSuit && rank > c2.rank;
        }
        */
    }
}
