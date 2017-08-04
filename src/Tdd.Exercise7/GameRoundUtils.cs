using System.Collections.Generic;

namespace Tdd.Exercise7
{
    public class GameRoundUtils
    {
        private static readonly Dictionary<Hand, Hand> WinningHand = new Dictionary<Hand, Hand>
        {
            {Hand.Scissors, Hand.Paper},
            {Hand.Paper, Hand.Rock},
            {Hand.Rock, Hand.Scissors},
        };

        public static bool IsWinningHand(Hand you, Hand competition)
        {
            return WinningHand[you] == competition;
        }
    }
}