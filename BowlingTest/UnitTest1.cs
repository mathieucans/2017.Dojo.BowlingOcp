using Xunit;

namespace BowlingTest
{
    public class GameTest
    {
        [Theory]
        [InlineData("2,2", 4)]
        [InlineData("1,4", 5)]
        [InlineData("1,4,1,4,1,4,1,4,0,0,1,4,1,4,1,4,1,4,0,6", 46)]
        [InlineData("0,1,9,0,0,9,1,4,0,0,1,4,1,4,1,4,1,4,0,6", 50)]
        public void calculate_basic_score(string rolls, int score)
        {
            var game = new Game();

            foreach (var roll in rolls.Split(','))
            {
                game.Roll(int.Parse(roll));
            }
            Assert.Equal(score, game.score());
        }

        [Theory]
        [InlineData("1,9,6", 16 + 6)]
        [InlineData("1,4,1,9,1,4,1,4,0,0,1,4,1,4,1,4,1,4,0,6", 52)]
        public void calculate_spare_score(string rolls, int score)
        {
            var game = new Game();

            foreach (var roll in rolls.Split(','))
            {
                game.Roll(int.Parse(roll));
            }
            Assert.Equal(score, game.score());
        }

    }
}
