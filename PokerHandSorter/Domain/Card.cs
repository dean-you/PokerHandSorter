using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandSorter.Domain
{
    public enum CardSuit
    {
        Diamonds = 'D',
        Hearts = 'H',
        Spades = 'S',
        Clubs = 'C'
    }

    public enum CardValue
    {
        None = 0,
        Two = 2,
        Three = 3,
        Four = 4,
        Five = 5,
        Six = 6,
        Seven = 7,
        Eight = 8,
        Nine = 9,
        Ten = 10,
        Jack = 11,
        Queen = 12,
        King = 13,
        Ace = 14
    }


    public class Card
    {
        public CardSuit Suit { get; private set; }
        public CardValue Value { get; private set; }

        public Card(string card)
        {
            Value = GetCardValue(card[0]);
            Suit = GetCardSuit(card[1]);
        }

        private CardSuit GetCardSuit(char c)
        {
            return _ = (c) switch
            {
                'D' => CardSuit.Diamonds,
                'H' => CardSuit.Hearts,
                'S' => CardSuit.Spades,
                'C' => CardSuit.Clubs,
                _ => throw new ArgumentException($"Invalid Card Suit {c}!")
            };
        }

        private CardValue GetCardValue(char c)
        {
            return _ = (c) switch
            {
                '2' => CardValue.Two,
                '3' => CardValue.Three,
                '4' => CardValue.Four,
                '5' => CardValue.Five,
                '6' => CardValue.Six,
                '7' => CardValue.Seven,
                '8' => CardValue.Eight,
                '9' => CardValue.Nine,
                'T' => CardValue.Ten,
                'J' => CardValue.Jack,
                'K' => CardValue.King,
                'Q' => CardValue.Queen,
                'A' => CardValue.Ace,
                _ => throw new ArgumentException($"Invalid Card Value {c}!")
            };
        }
    }
}
