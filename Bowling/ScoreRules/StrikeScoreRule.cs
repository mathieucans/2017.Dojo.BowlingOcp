using System.Collections.Generic;
using System.Linq;

namespace Bowling.ScoreRules
{
    public class StrikeScoreRule : IScoreRule
    {
        
        public bool Match(IEnumerable<Frame> frames)
        {
            return frames.First().Rolls.Count == 1 && frames.First().Rolls[0] == 10;
        }

        public int Compute(IEnumerable<Frame> frames, int previousScore)
        {
            var allRoll = CreateAllRoll(frames).Take(3);

            return previousScore + allRoll.Sum();
        }

        private static List<int> CreateAllRoll(IEnumerable<Frame> frames)
        {
            var allRoll = new List<int>();
            foreach (var frame in frames)
            {
                allRoll.AddRange(frame.Rolls);
            }
            return allRoll;
        }
    }
}