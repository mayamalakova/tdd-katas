using NSubstitute;
using NUnit.Framework;
using Shouldly;

namespace Tdd.Exercise7.Tests
{
    [TestFixture]
    public class RockPaperScissorsShould
    {
        private GameRound _gameRound;
        private RockPaperScissors _game;
        private IPlayer _player1;
        private IPlayer _player2;

        [SetUp]
        public void SetUp()
        {
            _gameRound = new GameRound();
            _game = new RockPaperScissors(_gameRound);

            _player1 = Substitute.For<IPlayer>();
            _player2 = Substitute.For<IPlayer>();
        }

        [Test]
        public void Decide_the_winner_based_on_round_results()
        {
            _player1.RevealHand().Returns(Hand.Paper);
            _player2.RevealHand().Returns(Hand.Scissors);

            GameResult result = _game.Play(_player1, _player2);
            result.WinningPlayer.ShouldBe(_player2);
        }

        [Test]
        public void Decide_the_winner_after_at_least_three_rounds()
        {
            _player1.RevealHand().Returns(Hand.Paper, Hand.Paper, Hand.Paper);
            _player2.RevealHand().Returns(Hand.Scissors, Hand.Rock, Hand.Rock);

            GameResult result = _game.Play(_player1, _player2);
            result.RoundCount.ShouldBe(3);
            result.WinningPlayer.ShouldBe(_player1);
        }

        [Test]
        public void Continue_until_there_is_a_clear_winner()
        {
            _player1.RevealHand().Returns(Hand.Paper, Hand.Paper, Hand.Paper, Hand.Paper);
            _player2.RevealHand().Returns(Hand.Rock, Hand.Scissors, Hand.Paper, Hand.Rock);

            GameResult result = _game.Play(_player1, _player2);
            result.RoundCount.ShouldBe(4);
            result.WinningPlayer.ShouldBe(_player1);
        }

        [Test]
        public void Continue_until_the_first_winner_after_three_draws()
        {
            _player1.RevealHand().Returns(Hand.Paper, Hand.Paper, Hand.Paper, Hand.Paper);
            _player2.RevealHand().Returns(Hand.Paper, Hand.Paper, Hand.Paper, Hand.Rock);

            GameResult result = _game.Play(_player1, _player2);
            result.RoundCount.ShouldBe(4);
            result.WinningPlayer.ShouldBe(_player1);
        }
    }
}