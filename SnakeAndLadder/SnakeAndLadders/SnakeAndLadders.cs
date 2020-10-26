using SnakeAndLadders.Contracts;
using SnakeAndLadders.Models;
using System;
using System.Collections.Generic;

namespace SnakeAndLadders
{
    public class SnakeAndLadders : ISnakeAndLadders
    {
        private readonly IBoard _board;

        public SnakeAndLadders(IBoard board)
        {
            _board = board;
        }

        public void Plot()
        {
            _board.SetSize(InitializeBoardSize());
            _board.SetPlayer(InitializePlayers());
            _board.SetLadder(InitializeLadders());
            _board.SetSnakes(InitializeSnakes());
        }

        private Size InitializeBoardSize()
        {
            return new Size
            {
                InitialPosition = 0,
                FinalPosition = 100
            };
        }
        private Player InitializePlayers()
        {
            return new Player
            {

                Name = "TestPlayer",
                Id = Guid.NewGuid(),
                Position = 0

            };
        }
        private List<Snake> InitializeSnakes()
        {
            return new List<Snake>
            {
                new Snake
                {
                    Head = 36,
                    Tail = 19
                },
                new Snake
                {
                    Head = 65,
                    Tail = 35
                },
                new Snake
                {
                    Head = 87,
                    Tail = 32
                },
                new Snake
                {
                    Head = 97,
                    Tail = 21
                }
            };
        }
        private List<Ladder> InitializeLadders()
        {
            return new List<Ladder>
            {
                new Ladder
                {
                    Top = 7,
                    Bottom = 33
                },
                new Ladder
                {
                    Top = 37,
                    Bottom = 85
                },
                new Ladder
                {
                    Top = 51,
                    Bottom = 72
                },
                new Ladder
                {
                    Top = 63,
                    Bottom = 99
                }
            };
        }

        public int Play(int nextMove)
        {
            Player player = _board.GetPlayer();
            nextMove += player.Position;
            nextMove = nextMove > 100 ? player.Position : nextMove;
            nextMove = NextPositionOfPlayer(nextMove);
            player.Position = nextMove;
            _board.SetPlayer(player);
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
