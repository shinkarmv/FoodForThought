using SnakeAndLadders.Models;
using System.Collections.Generic;

namespace SnakeAndLadders.Contracts
{
    public interface IBoard
    {
        void Plot();

        List<Ladder> GetLadders();
        List<Snake> GetSnakes();
        Player GetPlayer();

        void SetLadder(List<Ladder> ladders);

        void SetSnakes(List<Snake> snakes);

        void SetPlayers(Player player);
    }
}
