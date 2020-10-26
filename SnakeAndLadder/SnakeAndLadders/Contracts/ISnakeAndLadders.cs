using SnakeAndLadders.Models;
using System.Collections.Generic;

namespace SnakeAndLadders.Contracts
{
    public interface ISnakeAndLadders
    {
        void Plot();
        int Play(int nextMove);
    }
}
