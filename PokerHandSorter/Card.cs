using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandSorter
{
    public class Card
    {

        public char Suit { get; private set; }
        public int Value { get; private set; }


        public Card(string card)
        {
            var valueDic = new Dictionary<char, int>()
            {
                {'2', 2 },
                {'3', 3 },
                {'4', 4 },
                {'5', 5 },
                {'6', 6 },
                {'7', 7 },
                {'8', 8 },
                {'9', 9 },
                {'T', 10 },
                {'J', 11 },
                {'Q', 12 },
                {'K', 13 },
                {'A', 14 }
            };

            Value = valueDic[card[0]];
            Suit = card[1];
        }
    }
}
