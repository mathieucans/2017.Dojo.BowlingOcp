using System.Collections.Generic;
using System.Linq;

namespace BowlingTest
{
    public class BasicRoll : IRule
    {
        private readonly IEnumerable<IRule> _other;

        public BasicRoll(IEnumerable<IRule> other)
        {
            _other = other;
        }
        public bool match(IEnumerable<Frame> frames)
        {   
            return _other.Count(r => r.match(frames)) == 0;
        }

        public int compute(IEnumerable<Frame> frames, int finalScore)
        {
            return finalScore + frames.First().Rolls.Sum();
        }
    }
}