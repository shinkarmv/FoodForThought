using System;

namespace SnakeAndLadders.Models
{
    public class Player
    {
        public string Name { get; set; }
        public Guid Id { get; set; }

        public int Position { get; set; }
    }
}