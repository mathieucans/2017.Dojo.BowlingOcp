using System.Collections.Generic;

namespace BowlingTest
{
    public interface IRule
    {
        bool match(IEnumerable<Frame> frame);
        int compute(IEnumerable<Frame> frames, int finalScore);
    }
}