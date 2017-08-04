using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace Tdd.Exercise7.Tests
{
    [TestFixture]
    public class RockPaperScissorsShould
    {
        private GameRound gameRound;
        private RockPaperScissors game;
        private IPlayer player1;
        private IPlayer player2;

        [SetUp]
        public void SetUp()
        {
            gameRound = new GameRound();
            game = new RockPaperScissors(gameRound);

            player1 = Substitute.For<IPlayer>();
            player2 = Substitute.For<IPlayer>();
        }

        [Test]
        public void Decide_the_winner_based_on_round_results()
        {
            player1.RevealHand().Returns(Hand.Paper);
            player2.RevealHand().Returns(Hand.Scissors);

            GameResult result = game.Play(player1, player2);
            result.WinningPlayer.ShouldBe(player2);
        }

        [Test]
        public void Decide_the_winner_after_at_least_three_rounds()
        {
            player1.RevealHand().Returns(Hand.Paper, Hand.Paper, Hand.Paper);
            player2.RevealHand().Returns(Hand.Scissors, Hand.Rock, Hand.Rock);

            GameResult result = game.Play(player1, player2);
            result.RoundCount.ShouldBe(3);
            result.WinningPlayer.ShouldBe(player1);
        }

        [Test]
        public void Continue_until_there_is_a_clear_winner()
        {
            player1.RevealHand().Returns(Hand.Paper, Hand.Paper, Hand.Paper, Hand.Paper);
            player2.RevealHand().Returns(Hand.Rock, Hand.Scissors, Hand.Paper, Hand.Rock);

            GameResult result = game.Play(player1, player2);
            result.RoundCount.ShouldBe(4);
            result.WinningPlayer.ShouldBe(player1);
        }

        [Test]
        public void Continue_until_the_first_winner_after_three_draws()
        {
            player1.RevealHand().Returns(Hand.Paper, Hand.Paper, Hand.Paper, Hand.Paper);
            player2.RevealHand().Returns(Hand.Paper, Hand.Paper, Hand.Paper, Hand.Rock);

            GameResult result = game.Play(player1, player2);
            result.RoundCount.ShouldBe(4);
            result.WinningPlayer.ShouldBe(player1);
        }
    }
}