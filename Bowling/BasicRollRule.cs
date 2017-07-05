using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class BasicRollRule : IRule
    {
        private readonly IEnumerable<IRule> _other;

        public BasicRollRule(IEnumerable<IRule> other)
        {
            _other = other;
        }
        public bool Match(IEnumerable<Frame> frames)
        {   
            return _other.Count(r => r.Match(frames)) == 0;
        }

        public int Compute(IEnumerable<Frame> frames, int finalScore)
        {
            return finalScore + frames.First().Rolls.Sum();
        }
    }
}