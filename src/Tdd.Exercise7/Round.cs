namespace Tdd.Exercise7
{
    public class Round
    {
        public Winner Play(IPlayer player1, IPlayer player2)
        {
            var hand1 = player1.RevealHand();
            var hand2 = player2.RevealHand();

            switch (hand1)
            {
                case Hand.Paper:
                    if (hand2 == Hand.Scissors)
                        return Winner.Player2;
                    else if (hand2 == Hand.Rock)
                        return Winner.Player1;
                    break;
                case Hand.Rock:
                    if (hand2 == Hand.Paper)
                        return Winner.Player2;
                    else if (hand2 == Hand.Scissors)
                        return Winner.Player1;
                    break;
                case Hand.Scissors:
                    if (hand2 == Hand.Rock)
                        return Winner.Player2;
                    else if (hand2 == Hand.Paper)
                        return Winner.Player1;
                    break;
            }

            return Winner.None;
        }
    }
}