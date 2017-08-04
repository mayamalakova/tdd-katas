
using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace Tdd.Exercise7.Tests
{
    [TestFixture]
    public class RoundShould
    {
        private GameRound gameRound;
        private IPlayer player1;
        private IPlayer player2;

        [SetUp]
        public void SetUp()
        {
            gameRound = new GameRound();
            player1 = Substitute.For<IPlayer>();
            player2 = Substitute.For<IPlayer>();
        }

        [TestCase(Hand.Paper, Hand.Scissors, Winner.Player2)]
        [TestCase(Hand.Paper, Hand.Rock, Winner.Player1)]
        [TestCase(Hand.Rock, Hand.Scissors, Winner.Player1)]
        public void Decide_winning_hand(Hand hand1, Hand hand2, Winner expectedWinner)
        {
            player1.RevealHand().Returns(hand1);
            player2.RevealHand().Returns(hand2);
            var winner = gameRound.Play(player1, player2);
            winner.ShouldBe(expectedWinner);
        }

        [TestCase(Hand.Scissors)]
        [TestCase(Hand.Rock)]
        [TestCase(Hand.Paper)]
        public void Decide_same_hands_are_a_draw(Hand hand)
        {
            player1.RevealHand().Returns(hand);
            player2.RevealHand().Returns(hand);
            var winner = gameRound.Play(player1, player2);
            winner.ShouldBe(Winner.None);
        }
    }

}