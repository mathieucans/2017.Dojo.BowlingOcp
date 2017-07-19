using System.Collections.Generic;

namespace Bowling.ScoreRules
{
    public interface IScoreRule
    {
        bool Match(IEnumerable<Frame> frames);
        int Compute(IEnumerable<Frame> frames, int previousScore);
    }
}