using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PokerHandSorter.Domain.Game;

namespace PokerHandSorter.Application
{
    internal class Match: IMatch
    {
        public int Player1Score { get; private set; }
        public int Player2Score { get; private set; }

        private IGame _game;

        public Match(IGame game)
        {
            Player1Score = 0;
            Player2Score = 0;
            _game = game;
        }

        /// <summary>
        /// Load 500 games from the txt file and calculate the score for each player
        /// </summary>
        public void Play()
        {
            var games = File.ReadLines("poker-hands.txt");
            foreach (var cards in games)
            {
                _game.Play(cards);
                if (_game.Player1Win)
                    Player1Score++;
                if (_game.Player2Win)
                    Player2Score++;
            }
        }
    }
}
