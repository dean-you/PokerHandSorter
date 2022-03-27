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
            if (ComparePair())
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
            if (_player1.HighCard1 > _player2.HighCard1)
                Player1Win = true;
            else if (_player1.HighCard1 < _player2.HighCard1)
                Player2Win = true;
            return Player1Win || Player2Win;
        }

        private bool CompareHighCard2()
        {
            if (_player1.HighCard2 > _player2.HighCard2)
                Player1Win = true;
            else if (_player1.HighCard2 < _player2.HighCard2)
                Player2Win = true;
            return Player1Win || Player2Win;
        }

        private bool CompareHighCard3()
        {
            if (_player1.HighCard3 > _player2.HighCard3)
                Player1Win = true;
            else if (_player1.HighCard3 < _player2.HighCard3)
                Player2Win = true;
            return Player1Win || Player2Win;
        }

        private bool CompareHighCard4()
        {
            if (_player1.HighCard4 > _player2.HighCard4)
                Player1Win = true;
            else if (_player1.HighCard4 < _player2.HighCard4)
                Player2Win = true;
            return Player1Win || Player2Win;
        }

        private bool CompareHighCard5()
        {
            if (_player1.HighCard5 > _player2.HighCard5)
                Player1Win = true;
            else if (_player1.HighCard5 < _player2.HighCard5)
                Player2Win = true;
            return Player1Win || Player2Win;
        }



        private bool CompareTwoPairs()
        {
            if (_player1.Pair1 > 0 && _player1.Pair2 >0 && _player2.Pair1 > 0 && _player2.Pair2 > 0)
            {
                if (_player1.Pair1 > _player2.Pair1)
                    Player1Win = true;
                else if (_player1.Pair1 < _player2.Pair1)
                    Player2Win = true;
                else
                {
                    if (_player1.Pair2 > _player2.Pair2)
                        Player1Win = true;
                    else if (_player1.Pair2 < _player2.Pair2)
                        Player2Win = true;
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

        private bool ComparePair()
        {
            if (_player1.Pair1 > _player2.Pair1)
                Player1Win = true;
            else if (_player1.Pair1 < _player2.Pair1)
                Player2Win = true;
            return Player1Win || Player2Win;
        }

        private bool CompareThreeKind()
        {
            if (_player1.ThreeKind > _player2.ThreeKind)
                Player1Win = true;
            else if (_player1.ThreeKind < _player2.ThreeKind)
                Player2Win = true;
            return Player1Win || Player1Win;
        }

        private bool ComapreFourKind()
        {
            if (_player1.FourKind > _player2.FourKind)
                Player1Win = true;
            else if (_player1.FourKind < _player2.FourKind)
                Player2Win = true;
            return Player1Win || Player1Win;
        }

        private bool CompareStraightFlush()
        {
            if (_player1.StraightFlush() > _player2.StraightFlush())
                Player1Win = true;
            else if (_player1.StraightFlush() < _player2.StraightFlush())
                Player2Win = true;
            return Player1Win || Player1Win;
        }
    }
}
