using System.Collections.Generic;
using System.Linq;

namespace BowlingTest
{
    class GameStartWithOneFrame : IFrameRule
    {
        public IEnumerable<Frame> compute(IEnumerable<Frame> frames)
        {
            return new[]
            {
                new Frame()
            };
        }

        public bool match(IEnumerable<Frame> frames)
        {
            return frames.Count() == 0;
        }
    }

    class WhenFrameIsNotFinishedNoFrameIsAdded : IFrameRule
    {
        public bool match(IEnumerable<Frame> frames)
        {
            return frames.Last().Rolls.Count != 2;
        }

        public IEnumerable<Frame> compute(IEnumerable<Frame> frames)
        {
            return frames;
        }
    }
}