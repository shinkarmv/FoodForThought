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

        public void SetSize(Size size)
        {
            Size = size;
        }
        public void SetLadders(List<Ladder> ladders)
        {
            Ladders = ladders;
        }

        public void SetPlayer(Player player)
        {
            Player = player;
        }

        public void SetSnakes(List<Snake> snakes)
        {
            Snakes = snakes;
        }
    }
}
