using System.Collections.Generic;

namespace Bowling
{
    public class Frame
    {
        public Frame()
        {
            Rolls = new List<int>();
        }

        public List<int> Rolls { get; private set; }

        public void roll(int i)
        {
            Rolls.Add(i);
        }
    }
}