using System.Collections.Generic;
using System.Linq;

namespace Bowling.ScoreRules
{
    public class SpareScoreRule : IScoreRule
    {
        public bool Match(IEnumerable<Frame> frames)
        {
            return AllPinsShoudBeDown(frames)  
                && WithAtLeastTwoRoll(frames) 
                && TheFollowingFrameShoudBeStarted(frames)
                && AtLeastOneRollOfTheFollowingFrameShoudBeDone(frames);
        }

        public int Compute(IEnumerable<Frame> frames, int previousScore)
        {
            var followingFrame = frames.ElementAt(1);
            var nextScore = followingFrame.Rolls[0];
            
            return previousScore + frames.First().Rolls.Sum() + nextScore;
        }

        private bool AtLeastOneRollOfTheFollowingFrameShoudBeDone(IEnumerable<Frame> frames)
        {
            return frames.ElementAt(1).Rolls.Count > 0;
        }

        private static bool TheFollowingFrameShoudBeStarted(IEnumerable<Frame> frames)
        {
            return frames.Count() > 1;
        }

        private static bool WithAtLeastTwoRoll(IEnumerable<Frame> frames)
        {
            return frames.First().Rolls.Count > 1;
        }

        private static bool AllPinsShoudBeDown(IEnumerable<Frame> frames)
        {
            return frames.First().Rolls.Sum() == 10;
        }
    }
}