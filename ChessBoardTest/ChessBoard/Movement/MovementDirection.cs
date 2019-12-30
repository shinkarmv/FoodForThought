[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("ChessBoardTest")]
namespace ChessBoard
{
    internal enum MovementDirection
    {
        Horizantal,
        Vertical,
        Diagonal,
        /// <summary>
        /// Moves in both direction Vertically and Horizantally 
        /// </summary>
        BiDirectional = 4,
        All = 8
    }
}
