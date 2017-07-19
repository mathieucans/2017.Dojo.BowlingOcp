using System.Collections.Generic;

namespace Bowling.FrameRules
{
    interface IFrameRule
    {
        IEnumerable<Frame> compute(IEnumerable<Frame> frames);
        bool match(IEnumerable<Frame> frames);
    }
}