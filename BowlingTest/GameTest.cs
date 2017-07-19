using Bowling;
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
            Assert.Equal(score, game.Score());
        }

        [Theory]
        [InlineData("1,9,6,0", 16 + 6)]
        [InlineData("1,9,6,1", 16 + 7)]
        [InlineData("1,4,1,9,1,4,1,4,0,0,1,4,1,4,1,4,1,4,0,6", 52)]
        public void calculate_spare_score(string rolls, int score)
        {
            var game = new Game();

            foreach (var roll in rolls.Split(','))
            {
                game.Roll(int.Parse(roll));
            }
            Assert.Equal(score, game.Score());
        }


        [Theory]
        [InlineData("X,6,1", 17 + 7)]
        [InlineData("X,6,1", 17 + 7)]
        [InlineData("X,X,X", 30 + 20 + 10)]
        [InlineData("X,9,1,X,1,2", 20 + 20 + 13 + 3)]
        [InlineData("X,X,X,1,4,0,0,1,4,1,4,X,1,4,0,6", 30 + 21 + 15 + 5 + 0 + 5 + 5 + 15 + 5 + 6  )]
        public void calculate_strike_score(string rolls, int score)
        {
            var game = new Game();

            foreach (var roll in rolls.Split(','))
            {
                if (roll == "X")
                {
                    game.Roll(10);
                }
                else
                {
                        game.Roll(int.Parse(roll));
                }
            }
            Assert.Equal(score, game.Score());
        }
    }
}
