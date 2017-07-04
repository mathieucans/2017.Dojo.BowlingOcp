using System.Collections.Generic;

namespace BowlingTest
{
    interface IFrameRule
    {
        IEnumerable<Frame> compute(IEnumerable<Frame> frames);
        bool match(IEnumerable<Frame> frames);
    }
}