using System.Collections.Generic;
using System.Linq;

namespace Bowling.FrameRules
{
    class AnewFrameIsCreatedWhenTheLastFrameIsFull : IFrameRule
    {
        public bool match(IEnumerable<Frame> frames)
        {
            return frames.Last().Rolls.Count == 2 || frames.Last().Rolls.Sum() == 10;
        }

        public IEnumerable<Frame> compute(IEnumerable<Frame> frames )
        {
            var list = new List<Frame>(frames);
            list.Add(new Frame());
            return list;
        }
    }
}