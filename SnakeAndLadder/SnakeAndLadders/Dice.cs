using SnakeAndLadders.Contracts;
using System;

namespace SnakeAndLadders
{
    public class Dice : IDice
    {
        public int Roll()
        {
            Random random = new Random();
            return random.Next(6) + 1;
        }
    }
}
