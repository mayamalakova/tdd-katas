namespace Tdd.Exercise7
{
    public class GameRound
    {
        public Winner Play(IPlayer player1, IPlayer player2)
        {
            var hand1 = player1.RevealHand();
            var hand2 = player2.RevealHand();
            
            switch (hand1)
            {
                case Hand.Paper:
                    return hand2 == Hand.Scissors ? Winner.Player2 : hand2 == Hand.Rock ? Winner.Player1 : Winner.None;
                case Hand.Rock:
                    return hand2 == Hand.Paper ? Winner.Player2 : hand2 == Hand.Scissors ? Winner.Player1 : Winner.None;
                case Hand.Scissors:
                    return hand2 == Hand.Rock ? Winner.Player2 : hand2 == Hand.Paper ? Winner.Player1 : Winner.None;
            }
            return Winner.None;
        }
    }
}