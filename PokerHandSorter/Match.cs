using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokerHandSorter
{
    internal class Match
    {
        public int Player1Score { get; private set; }
        public int Player2Score { get; private set; }

        public Match()
        {
            Player1Score = 0;
            Player2Score = 0;
        }

        public void Play()
        {
            var lines = File.ReadLines("poker-hands.txt");
            foreach (var line in lines)
            {
                var game = new Game(line);
                game.Play();
                if (game.Player1Win)
                    Player1Score++;
                if (game.Player2Win)
                    Player2Score++;
            }
        }
    }
}
