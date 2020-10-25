using SnakeAndLadders.Contracts;
using SnakeAndLadders.Models;
using System;
using System.Collections.Generic;

namespace SnakeAndLadders
{
    public class Board : IBoard
    {
        private Size Size { get; set; }
        private List<Ladder> Ladders { get; set; }
        private List<Snake> Snakes { get; set; }
        private Player Player { get; set; }

        public List<Ladder> GetLadders()
        {
            return Ladders;
        }

        public Player GetPlayer()
        {
            return Player;
        }

        public List<Snake> GetSnakes()
        {
            return Snakes;
        }

        public void Plot()
        {
            InitializeBoardSize();
            InitializeLadders();
            InitializePlayers();
            InitializeSnakes();
        }

        public void SetLadder(List<Ladder> ladders)
        {
            throw new NotImplementedException();
        }

        public void SetPlayers(Player player)
        {
            throw new NotImplementedException();
        }

        public void SetSnakes(List<Snake> snakes)
        {
            throw new NotImplementedException();
        }

        private void InitializeBoardSize()
        {
            Size = new Size
            {
                InitialPosition = 0,
                FinalPosition = 100
            };
        }

        private void InitializeLadders()
        {
            Ladders = new List<Ladder>
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

        private void InitializeSnakes()
        {
            Snakes = new List<Snake>
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

        private void InitializePlayers()
        {
            Player = new Player
            {
                
                    Name = "TestPlayer",
                    Id = Guid.NewGuid(),
                    Position = 0
                
            };
        }
    }
}
