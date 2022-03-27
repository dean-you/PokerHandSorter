namespace PokerHandSorter
{
    public class Hand
    {
        private SortedDictionary<int, int> _cardsValueTimes = new SortedDictionary<int,int>();
        private List<char> _cardsSuit = new List<char>();

        public int Straight { get; private set; }
        public int FourKind { get; private set; }
        public int ThreeKind { get; private set; }
        public int Pair1 { get; private set; }
        public int Pair2 { get; private set; }
        public int HighCard1 { get; private set; }
        public int HighCard2 { get; private set; }
        public int HighCard3 { get; private set; }
        public int HighCard4 { get; private set; }
        public int HighCard5 { get; private set; }
        public bool Flush { get; }

        public Hand(string hand)
        {
            FourKind = 0;
            ThreeKind = 0;
            Pair1 = 0;
            Pair2 = 0;
            foreach (var item in hand.Split(' '))
            {
                var card = new Card(item);
                if (_cardsValueTimes.Keys.Contains(card.Value))
                    _cardsValueTimes[card.Value]++;
                else
                    _cardsValueTimes.Add(card.Value, 1);
                _cardsSuit.Add(card.Suit);
            }

            foreach (var valueTimes in _cardsValueTimes.OrderByDescending(x=> x.Key))
            {
                if (valueTimes.Value == 4)
                    FourKind = valueTimes.Key;
                else if (valueTimes.Value == 3)
                    ThreeKind = valueTimes.Key;
                else if (valueTimes.Value == 2)
                {
                    if (Pair1 == 0)
                        Pair1 = valueTimes.Key;
                    else
                        Pair2 = valueTimes.Key;
                }
                else
                {
                    if (HighCard1 == 0)
                        HighCard1 = valueTimes.Key;
                    else if (HighCard2 == 0)
                        HighCard2 = valueTimes.Key;
                    else if (HighCard3 == 0)
                        HighCard3 = valueTimes.Key;
                    else if (HighCard4 == 0)
                        HighCard4 = valueTimes.Key;
                    else
                        HighCard5 = valueTimes.Key;
                }
            }

            Flush = IsFlush();
            Straight = FiveCardsConsecutive();
        }

        private int FiveCardsConsecutive()
        {
            if (_cardsValueTimes.Count != 5)
                return 0;
            var firstTime = true;
            var preValue = 0;
            foreach (var valueTimes in _cardsValueTimes)
            {
                if (firstTime)
                {
                    firstTime = false;
                    preValue = valueTimes.Key;
                    continue;
                }
                if (valueTimes.Key != preValue + 1)
                    return 0;
                preValue = valueTimes.Key;
            }
            return preValue;
        }

        private bool IsFlush()
        {
            for (int i = 1; i < _cardsSuit.Count; i++)
            {
                if (_cardsSuit[i-1]!=_cardsSuit[i])
                    return false;
            }
            return true;
        }

        public int StraightFlush()
        {
            if (Flush)
                return Straight;
            else
                return 0;
        }

    }
}