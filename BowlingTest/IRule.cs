using System.Collections.Generic;

namespace BowlingTest
{
    public interface IRule
    {
        bool match(Frame frame);
        int compute(Frame i, IEnumerable<Frame> followingFrames, int finalScore);
    }
}