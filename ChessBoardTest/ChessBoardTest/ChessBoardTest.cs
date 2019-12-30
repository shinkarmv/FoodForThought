using Xunit;
namespace ChessBoardTest
{
    public class ChessBoardTest
    {
        [Theory]
        [InlineData("D5")]
        [InlineData("C3")]
        [InlineData("F6")]
        [InlineData("H8")]
        public void MakeNextMove_KingChessPiece_PossibleCellPositions(string cellPosition)
        {
            // Arrange
            ChessBoard.ChessBoard chessBoard = new ChessBoard.ChessBoard();
            ChessBoard.King king = new ChessBoard.King();

            // Act
            var possibleMoves = chessBoard.MakeNextMove(king, cellPosition);

            // Assert
            Assert.DoesNotContain(cellPosition, possibleMoves);
        }


        [Theory]
        [InlineData("C4")]
        [InlineData("D4")]
        [InlineData("E4")]
        [InlineData("H4")]
        public void MakeNextMove_PawnChessPiece_PossibleCellPositions(string cellPosition)
        {
            // Arrange
            ChessBoard.ChessBoard chessBoard = new ChessBoard.ChessBoard();
            ChessBoard.Pawn pawn = new ChessBoard.Pawn();

            // Act
            var possibleMoves = chessBoard.MakeNextMove(pawn, cellPosition);

            // Assert
            Assert.DoesNotContain(cellPosition, possibleMoves);
        }
    }
}
