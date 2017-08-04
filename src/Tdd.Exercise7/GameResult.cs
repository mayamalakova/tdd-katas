namespace Tdd.Exercise7
{
    public class GameResult
    {
        public GameResult(int roundCount, IPlayer winningPlayer)
        {
            RoundCount = roundCount;
            WinningPlayer = winningPlayer;
        }

        public IPlayer WinningPlayer { get; }

        public int RoundCount { get; }
    }
}