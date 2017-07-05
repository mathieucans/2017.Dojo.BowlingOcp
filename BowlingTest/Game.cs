using System.Collections.Generic;
using System.Linq;

namespace BowlingTest
{
    public class Game
    {
        private int _finalScore = 0;

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

        private void CalcScore()
        {
            var frames = _frames;
            var score = 0;

            while (frames.Any())
            {
                var applyRules = _rules.Where(r => r.match(frames));
                foreach (var rule in applyRules)
                {
                    score = rule.compute(frames, score);
                }              

                frames = frames.Skip(1);
            }

            _finalScore = score;
        }


        private IRule[] _rules;

        private IEnumerable<Frame> _frames;
        private List<IFrameRule> _frameRules;

        public Game()
        {
            var spareRule = new SpareRule();
            _rules = new IRule[]
            {
                spareRule, 
                new BasicRollRule(new [] { spareRule})
            };

            _frameRules = new List<IFrameRule>
            {
                new GameStartWithOneFrame(),
                new AnewFrameIsCreatedWhenTheLastFrameIsFull(),  
            };




            _frames = new List<Frame>();

        }

        public int score()
        {
            return _finalScore;
        }
    }
}