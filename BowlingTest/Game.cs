using System.Collections.Generic;
using System.Linq;

namespace BowlingTest
{
    public class Game
    {
        private int _finalScore = 0;

        public void roll(int i)
        {

            var applyRules = _frameRules.Where(r => r.match(_frames));
            foreach (var rule in applyRules)
            {
                _frames = rule.compute(_frames);
            }

            _frames.Last().roll(i);

            var score = CalcScore(0, _frames);
            _finalScore = score;
        }
        
        private int CalcScore(int lastScore, IEnumerable<Frame> frames)
        {
            if (frames.Any())
            {
                var newScore =  _rules.First(r => r.match(frames))
                    .compute(frames, lastScore);
            
                return CalcScore(newScore, frames.Skip(1));
            }
            return  lastScore;
        }
       
    
        private IRule[] _rules;

        private IEnumerable<Frame> _frames;
        private List<IFrameRule> _frameRules;

        public Game()
        {   
            _rules = new IRule[]
            {
                new SpareRule(), 
                new BasicRoll()
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