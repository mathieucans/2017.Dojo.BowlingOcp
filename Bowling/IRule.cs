using System.Collections.Generic;

namespace Bowling
{
    public interface IRule
    {
        bool Match(IEnumerable<Frame> frames);
        int Compute(IEnumerable<Frame> frames, int finalScore);
    }
}