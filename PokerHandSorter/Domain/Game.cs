using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandSorter
{
    public class Game
    {
        private Hand _player1;
        private Hand _player2;

        public bool Player1Win { get; private set; }
        public bool Player2Win { get; private set; }
        public Game(string cards)
        {
            Player1Win = false;
            Player2Win = false;
            _player1 = new Hand(cards.Substring(0, 14));
            _player2 = new Hand(cards.Substring(15));
        }

        public void Play()
        {
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

        private bool CompareStraight()
        {
            if (_player1.Straight > _player2.Straight)
                Player1Win=true;
            else if (_player1.Straight < _player2.Straight)
                Player2Win=true;
            return Player1Win || Player2Win;
        }

        private bool CompareFlush()
        {
            if (_player1.Flush && _player2.Flush)
                CompareHighCard();
            else if (_player1.Flush)
                Player1Win = true;
            else if (_player2.Flush)
                Player2Win = true;
            return Player1Win || Player2Win;
        }

        private bool CompareFullHouse()
        {
            if (_player1.ThreeKind > 0 && _player1.Pair1 > 0 && _player2.ThreeKind > 0 && _player2.Pair1 > 0)
            {
                if (_player1.ThreeKind > _player2.ThreeKind)
                    Player1Win = true;
                else if (_player1.ThreeKind < _player2.ThreeKind)
                    Player2Win = true;
                else
                {
                    if (_player1.Pair1 > _player2.Pair1)
                        Player1Win = true;
                    else if (_player1.Pair1 < _player2.Pair1)
                        Player2Win = true;
                }
            }
            else if (_player1.ThreeKind > 0 && _player1.Pair1 > 0)
                Player1Win = true;
            else if (_player2.ThreeKind > 0 && _player2.Pair1 > 0)
                Player2Win = true;
            return Player1Win || Player2Win;
        }

        private void CompareHighCard()
        {
            if (CompareHighCard1())
                return;
            if (CompareHighCard2())
                return;
            if (CompareHighCard3())
                return;
            if (CompareHighCard4())
                return;
            if (CompareHighCard5())
                return;
        }

        private bool CompareHighCard1()
        {
            return CompareCardValue(_player1.HighCard1, _player2.HighCard1);
        }

        private bool CompareHighCard2()
        {
            return CompareCardValue(_player1.HighCard2, _player2.HighCard2);
        }

        private bool CompareHighCard3()
        {
            return CompareCardValue(_player1.HighCard3, _player2.HighCard3);
        }

        private bool CompareHighCard4()
        {
            return CompareCardValue(_player1.HighCard4, _player2.HighCard4);
        }

        private bool CompareHighCard5()
        {
            return CompareCardValue(_player1.HighCard5, _player2.HighCard5);
        }



        private bool CompareTwoPairs()
        {
            if (_player1.Pair1 > 0 && _player1.Pair2 >0 && _player2.Pair1 > 0 && _player2.Pair2 > 0)
            {
                if (!ComparePair1())
                {
                    ComparePair2();
                }
            }
            else if (_player1.Pair1 > 0 && _player1.Pair2 > 0)
            {
                Player1Win = true;
            }
            else if (_player2.Pair1 > 0 && _player2.Pair2 > 0)
            {
                Player2Win = true;
            }
            return Player1Win || Player2Win;
        }

        private bool ComparePair1()
        {
            return CompareCardValue(_player1.Pair1, _player2.Pair1);
        }

        private bool ComparePair2()
        {
            return CompareCardValue(_player1.Pair2, _player2.Pair2);
        }

        private bool CompareThreeKind()
        {
            return CompareCardValue(_player1.ThreeKind, _player2.ThreeKind);
        }

        private bool ComapreFourKind()
        {
            return CompareCardValue(_player1.FourKind, _player2.FourKind);
        }

        private bool CompareStraightFlush()
        {
            return CompareCardValue(_player1.StraightFlush(), _player2.StraightFlush());
        }

        private bool CompareCardValue(CardValue cardValue1, CardValue cardValue2 )
        {
            if (cardValue1 > cardValue2)
                Player1Win = true;
            else if (cardValue1 < cardValue2)
                Player2Win = true;
            return Player1Win || Player2Win;
        }
    }
}
