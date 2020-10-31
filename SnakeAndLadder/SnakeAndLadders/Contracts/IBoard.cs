using SnakeAndLadders.Models;
using System.Collections.Generic;

namespace SnakeAndLadders.Contracts
{
    public interface IBoard
    {
        List<Ladder> GetLadders();
        List<Snake> GetSnakes();
        Player GetPlayer();

        void SetLadders(List<Ladder> ladders);

        void SetSnakes(List<Snake> snakes);

        void SetPlayer(Player player);

        void SetSize(Size size);
    }
}
