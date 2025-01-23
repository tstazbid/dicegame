using System;

namespace DiceGame
{
    public class Dice
    {
        public int[] Faces { get; }

        public Dice(int[] faces)
        {
            Faces = faces;
        }
    }
}
