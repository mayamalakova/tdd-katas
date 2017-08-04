
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

        [Test]
        public void Decide_scissors_beats_paper()
        {
            player1.RevealHand().Returns(Hand.Paper);
            player2.RevealHand().Returns(Hand.Scissors);
            var winner = gameRound.Play(player1, player2);
            winner.ShouldBe(Winner.Player2);
        }
        [Test]
        public void Decide_paper_beats_rock()
        {
            player1.RevealHand().Returns(Hand.Paper);
            player2.RevealHand().Returns(Hand.Rock);
            var winner = gameRound.Play(player1, player2);
            winner.ShouldBe(Winner.Player1);
        }

        [Test]
        public void Decide_rock_beats_scissors()
        {
            player1.RevealHand().Returns(Hand.Rock);
            player2.RevealHand().Returns(Hand.Scissors);
            var winner = gameRound.Play(player1, player2);
            winner.ShouldBe(Winner.Player1);
        }

        [Test]
        public void Decide_same_hands_are_a_draw()
        {
            player1.RevealHand().Returns(Hand.Rock);
            player2.RevealHand().Returns(Hand.Rock);
            var winner = gameRound.Play(player1, player2);
            winner.ShouldBe(Winner.None);
        }
    }

}