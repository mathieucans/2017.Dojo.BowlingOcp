using System.Collections.Generic;

namespace Bowling
{
    interface IFrameRule
    {
        IEnumerable<Frame> compute(IEnumerable<Frame> frames);
        bool match(IEnumerable<Frame> frames);
    }
}