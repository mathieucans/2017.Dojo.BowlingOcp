using System.Collections.Generic;

    namespace BowlingTest
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