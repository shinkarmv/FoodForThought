using SnakeAndLadders.Contracts;
using System;

namespace SnakeAndLadders.Host
{
    public class RollTheDice
    {
        private readonly ISnakeAndLadders _snakeAndLadders;
        private readonly IDice _dice;

        public RollTheDice(ISnakeAndLadders snakeAndLadders, IDice dice)
        {
            _snakeAndLadders = snakeAndLadders;
            _dice = dice;
            _snakeAndLadders.Plot();
        }

        public int NextMove()
        {
            Console.WriteLine("Play the NextMove");
            int nextMove = _dice.Roll();
            Console.WriteLine("Dice outcome " + nextMove);
            Console.WriteLine();
            return _snakeAndLadders.Play(nextMove);
        }
    }
}
