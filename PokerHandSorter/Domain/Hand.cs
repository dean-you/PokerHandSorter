namespace PokerHandSorter.Domain
{
    public class Hand
    {
        private SortedDictionary<CardValue, int> _cardsValueDuplicate = new SortedDictionary<CardValue,int>();
        private List<CardSuit> _cardsSuit = new List<CardSuit>();

        public CardValue Straight { get; private set; } = CardValue.None;
        public CardValue FourKind { get; private set; } = CardValue.None;
        public CardValue ThreeKind { get; private set; } = CardValue.None;
        public CardValue Pair1 { get; private set; } = CardValue.None;
        public CardValue Pair2 { get; private set; } = CardValue.None;
        public CardValue HighCard1 { get; private set; } = CardValue.None;
        public CardValue HighCard2 { get; private set; } = CardValue.None;
        public CardValue HighCard3 { get; private set; } = CardValue.None;
        public CardValue HighCard4 { get; private set; } = CardValue.None;
        public CardValue HighCard5 { get; private set; } = CardValue.None;
        public bool Flush { get; }

        public Hand(string hand)
        {
            var cards = hand.Split(' ');
            if (cards.Length != 5)
                throw new ArgumentException($"Invalid cards {cards} are dealt to player");
            foreach (var cardStr in cards)
            {
                var card = new Card(cardStr);
                if (_cardsValueDuplicate.Keys.Contains(card.Value))
                    _cardsValueDuplicate[card.Value]++;
                else
                    _cardsValueDuplicate.Add(card.Value, 1);
                _cardsSuit.Add(card.Suit);
            }
            SetHighestCardValueForSameCardValue();
            Flush = IsFlush();
            Straight = FiveCardsConsecutive();
        }

        private void SetHighestCardValueForSameCardValue()
        {
            foreach (var cardValueDuplicate in _cardsValueDuplicate.OrderByDescending(x => x.Key))
            {
                if (cardValueDuplicate.Value == 4)
                    FourKind = cardValueDuplicate.Key;
                else if (cardValueDuplicate.Value == 3)
                    ThreeKind = cardValueDuplicate.Key;
                else if (cardValueDuplicate.Value == 2)
                {
                    if (Pair1 == CardValue.None)
                        Pair1 = cardValueDuplicate.Key;
                    else
                        Pair2 = cardValueDuplicate.Key;
                }
                else
                {
                    if (HighCard1 == CardValue.None)
                        HighCard1 = cardValueDuplicate.Key;
                    else if (HighCard2 == CardValue.None)
                        HighCard2 = cardValueDuplicate.Key;
                    else if (HighCard3 == CardValue.None)
                        HighCard3 = cardValueDuplicate.Key;
                    else if (HighCard4 == CardValue.None)
                        HighCard4 = cardValueDuplicate.Key;
                    else
                        HighCard5 = cardValueDuplicate.Key;
                }
            }
        }

        private CardValue FiveCardsConsecutive()
        {
            if (_cardsValueDuplicate.Count != 5)
                return CardValue.None;
            var firstTime = true;
            CardValue preValue = CardValue.None;
            foreach (var cardValueDuplicate in _cardsValueDuplicate)
            {
                if (firstTime)
                {
                    firstTime = false;
                    preValue = cardValueDuplicate.Key;
                    continue;
                }
                if (cardValueDuplicate.Key != preValue + 1)
                    return CardValue.None;
                preValue = cardValueDuplicate.Key;
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

        public CardValue StraightFlush()
        {
            if (Flush)
                return Straight;
            else
                return CardValue.None;
        }

    }
}