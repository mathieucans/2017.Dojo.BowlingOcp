using System.Collections.Generic;
using System.Linq;

namespace Bowling.ScoreRules
{
    public class BasicScoreRule : IScoreRule
    {
        private readonly IEnumerable<IScoreRule> _other;

        public BasicScoreRule(IEnumerable<IScoreRule> other)
        {
            _other = other;
        }
        public bool Match(IEnumerable<Frame> frames)
        {   
            return _other.Count(r => r.Match(frames)) == 0;
        }

        public int Compute(IEnumerable<Frame> frames, int previousScore)
        {
            return previousScore + frames.First().Rolls.Sum();
        }
    }
}