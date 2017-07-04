using System.Collections.Generic;
using System.Linq;

namespace BowlingTest
{
    public class Game
    {
        private int _finalScore = 0;

        public void roll(int i)
        {
            _frames.Last().roll(i);
            if (_frames.Last().Rolls.Count == 2)
            {
                _frames.Add(new Frame());
            }

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

        private List<Frame> _frames;

        public Game()
        {   
            _rules = new IRule[]
            {
                new SpareRule(), 
                new BasicRoll()
            };
            _frames = new List<Frame>()
            {
                new Frame()
            };

        }

        public int score()
        {
            return _finalScore;
        }
    }
}