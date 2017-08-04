﻿using System.Collections.Generic;

namespace Tdd.Exercise7
{
    public class GameRound
    {
        private static readonly Dictionary<Hand, Hand> WinningHand = new Dictionary<Hand, Hand>
        {
            {Hand.Scissors, Hand.Paper},
            {Hand.Paper, Hand.Rock},
            {Hand.Rock, Hand.Scissors},
        };

        public Winner Play(IPlayer player1, IPlayer player2)
        {
            var hand1 = player1.RevealHand();
            var hand2 = player2.RevealHand();

            if (hand1 == hand2)
            {
                return Winner.None;
            }

            if (IsWinningHand(hand1, hand2))
            {
                return Winner.Player1;
            }

            return Winner.Player2;
        }

        private static bool IsWinningHand(Hand you, Hand competition)
        {
            return WinningHand[you] == competition;
        }
    }
}