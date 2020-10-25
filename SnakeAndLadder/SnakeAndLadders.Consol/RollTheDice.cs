using SnakeAndLadders.Contracts;
using System;

namespace SnakeAndLadders.Host
{
    public class RollTheDice
    {
        private readonly ISnakeAndLadders _snakeAndLadders;

        public RollTheDice(ISnakeAndLadders snakeAndLadders)
        {
            _snakeAndLadders = snakeAndLadders;
        }

        public int NextMove()
        {
            Console.WriteLine("Play the NextMove");
            return _snakeAndLadders.Play();
        }
    }
}
