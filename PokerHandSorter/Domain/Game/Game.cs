using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandSorter.Domain.Game
{
    public class Game: GameBase, IGame
    {
        public Game()
        {

        }

        public void Play(string cards)
        {
            Init(cards);

            if (CompareStraightFlush())
                return;
            if (ComapreFourKind())
                return;
            if (CompareFullHouse())
                return;
            if (CompareFlush())
                return;
            if (CompareStraight())
                return;
            if (CompareThreeKind())
                return;
            if (CompareTwoPairs())
                return;
            if (ComparePair1())
                return;
            CompareHighCard();
        }

    }
}
