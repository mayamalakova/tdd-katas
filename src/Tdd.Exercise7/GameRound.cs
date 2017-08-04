namespace Tdd.Exercise7
{
    public class GameRound
    {
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

        private bool IsWinningHand(Hand you, Hand competition)
        {
            if (you == Hand.Paper && competition == Hand.Rock)
            {
                return true;
            }
            if (you == Hand.Rock && competition == Hand.Scissors)
            {
                return true;
            }
            if (you == Hand.Scissors && competition == Hand.Paper)
            {
                return true;
            }
            return false;
        }
    }
}