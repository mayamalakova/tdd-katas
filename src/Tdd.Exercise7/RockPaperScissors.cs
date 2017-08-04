using System.Collections.Generic;
using System.Linq;

namespace Tdd.Exercise7
{
    public class RockPaperScissors
    {
        private readonly GameRound _gameRound;

        public RockPaperScissors(GameRound gameRound)
        {
            _gameRound = gameRound;
        }

        public GameResult Play(IPlayer player1, IPlayer player2)
        {
            var wins = new Dictionary<IPlayer, int>
            {
                {player1, 0},
                {player2, 0},
            };

            int roundCount = 0;

            while (roundCount < 3 || wins.Values.Distinct().Count() == 1)
            {
                roundCount++;

                var winner = _gameRound.Play(player1, player2);
                if (winner == Winner.Player1)
                    wins[player1]++;
                else if (winner == Winner.Player2)
                    wins[player2]++;
            }

            IPlayer winningPlayer = wins.OrderByDescending(pair => pair.Value).First().Key;

            return new GameResult(roundCount, winningPlayer);
        }
    }
}