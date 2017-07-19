using System.Collections.Generic;
using System.Linq;
using Bowling.FrameRules;
using Bowling.ScoreRules;

namespace Bowling
{
    public class Game
    {
        private int _finalScore = 0;

        private IScoreRule[] _scoreRules;

        private IEnumerable<Frame> _frames;

        private IEnumerable<IFrameRule> _frameRules;

        public Game()
        {
            var spareRule = new SpareScoreRuleSumAllPinsOfTheFramesAndPinsOfTheNextRoll();
            var strikeBasicRule = new StrikeScoreRuleSumThePinsDownOfTheFrameAndPinsOfTheTwoNextRolls();

            _scoreRules = new IScoreRule[]
            {
                strikeBasicRule,
                spareRule, 
                new BasicScoreRuleSumAllPinsDownOfTheFrame(new IScoreRule[] { spareRule, strikeBasicRule})
            };

            _frameRules = new IFrameRule[]
            {
                new GameStartWithOneFrame(),
                new AnewFrameIsCreatedWhenTheLastFrameIsFull(),
               
            };

            _frames = new List<Frame>();

        }


        public void Roll(int i)
        {
                
            var applyRules = _frameRules.Where(r => r.match(_frames));
            foreach (var rule in applyRules)
            {
                _frames = rule.compute(_frames);
            }

            _frames.Last().roll(i);

    
            CalcScore();
        }

        public int Score()
        {
            return _finalScore;
        }


        private void CalcScore()
        {
            var frames = _frames;
            var score = 0;

            while (frames.Any())
            {
                var applyRules = _scoreRules.Where(r => r.Match(frames));
                foreach (var rule in applyRules)
                {
                    score = rule.Compute(frames, score);
                }              

                frames = frames.Skip(1);
            }

            _finalScore = score;
        }
    }
}