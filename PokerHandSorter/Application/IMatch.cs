namespace PokerHandSorter.Application
{
    internal interface IMatch
    {
        public int Player1Score { get; }
        public int Player2Score { get; }
        public void Play();
    }
}