using SnakeAndLadders.Contracts;
using SnakeAndLadders.Models;
using System;
using System.Collections.Generic;

namespace SnakeAndLadders
{
    public class SnakeAndLadders : ISnakeAndLadders
    {
        private readonly IBoard _board;
        private readonly IDice _dice;

        public SnakeAndLadders(IBoard board, IDice dice)
        {
            _board = board;
            _dice = dice;
            _board.Plot();
        }

        public int Play()
        {
            int nextMove = _dice.Roll();
            Console.WriteLine("Dice outcome " + nextMove);
            Console.WriteLine();
            Player player = _board.GetPlayer();
            nextMove += player.Position;
            nextMove = nextMove > 100 ? player.Position : nextMove;
            nextMove = NextPositionOfPlayer(nextMove);
            player.Position = nextMove;
            Console.WriteLine("Player postioned at " + player.Position);
            Console.WriteLine();
            return nextMove;
        }

        private int NextPositionOfPlayer(int nextMove)
        {
            List<Snake> snakes = _board.GetSnakes();
            foreach (Snake snake in snakes)
            {
                if (snake.Head == nextMove)
                {
                    nextMove = snake.Tail;
                    Console.WriteLine("Player eaten by snake");
                    Console.WriteLine();
                }
            }

            List<Ladder> ladders = _board.GetLadders();
            foreach (Ladder ladder in ladders)
            {
                if (ladder.Bottom == nextMove)
                {
                    nextMove = ladder.Top;
                    Console.WriteLine("Player climbed up the ladder");
                    Console.WriteLine();
                }
            }

            return nextMove;
        }
    }
}
