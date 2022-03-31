namespace PokerHandSorter.Domain.Game
{
    public interface IGame
    {
        bool Player1Win { get; }
        bool Player2Win { get; }

        public void Play(string cards);
    }
}