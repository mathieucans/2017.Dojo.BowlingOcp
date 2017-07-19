using System.Collections.Generic;
using System.Linq;

namespace Bowling
{
    public class StrikeRule : IRule
    {
        
        public bool Match(IEnumerable<Frame> frames)
        {
            return frames.First().Rolls.Count == 1 && frames.First().Rolls[0] == 10;
        }

        public int Compute(IEnumerable<Frame> frames, int finalScore)
        {
            var allRoll = CreateAllRoll(frames).Take(3);

            return finalScore + allRoll.Sum();
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