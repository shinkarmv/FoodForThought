using Moq;
using SnakeAndLadders.Contracts;
using SnakeAndLadders.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace SnakeAndLadder.UnitTest
{
    public class SnakeAndLaddersTest
    {
        [Fact]
        public void Play_DiceOutCome_PlayerEatenBySnake()
        {
            // Arrange
            var board = new Mock<IBoard>();

            board.Setup(x => x.SetSize(InitializeSize()));
            board.Setup(x => x.SetLadders(InitializeLadders(33, 7)));
            board.Setup(x => x.SetPlayer(InitializePlayers(30)));
            board.Setup(x => x.SetSnakes(InitializeSnakes(36, 19)));

            board.Setup(x => x.GetLadders()).Returns(InitializeLadders(33, 7));
            board.Setup(x => x.GetPlayer()).Returns(InitializePlayers(30));
            board.Setup(x => x.GetSnakes()).Returns(InitializeSnakes(36, 19));

            // Act
            var snakeAndLadders = new SnakeAndLadders.SnakeAndLadders(board.Object);
            snakeAndLadders.Plot();
            var position = snakeAndLadders.Play(6);

            // Assert
            Assert.Equal(19, position);
        }

        private static Size InitializeSize()
        {
            return new Size
            {
                InitialPosition = 0,
                FinalPosition = 100
            };
        }
        private Player InitializePlayers(int position)
        {
            return new Player
            {

                Name = "TestPlayer",
                Id = Guid.NewGuid(),
                Position = position

            };
        }
        private List<Snake> InitializeSnakes(int head, int tail)
        {
            return new List<Snake>
            {
                new Snake
                {
                    Head = head,
                    Tail = tail
                }
            };
        }
        private List<Ladder> InitializeLadders(int top, int bottom)
        {
            return new List<Ladder>
            {
                new Ladder
                {
                    Top = top,
                    Bottom = bottom
                }
            };
        }

        [Fact]
        public void Play_DiceOutCome_PlayerClimbedLadder()
        {
            // Arrange
            var board = new Mock<IBoard>();

            board.Setup(x => x.SetSize(InitializeSize()));
            board.Setup(x => x.SetLadders(InitializeLadders(85, 33)));
            board.Setup(x => x.SetPlayer(InitializePlayers(30)));
            board.Setup(x => x.SetSnakes(InitializeSnakes(36, 19)));

            board.Setup(x => x.GetLadders()).Returns(InitializeLadders(85, 33));
            board.Setup(x => x.GetPlayer()).Returns(InitializePlayers(30));
            board.Setup(x => x.GetSnakes()).Returns(InitializeSnakes(36, 19));

            // Act
            var snakeAndLadders = new SnakeAndLadders.SnakeAndLadders(board.Object);
            snakeAndLadders.Plot();
            var position = snakeAndLadders.Play(3);

            // Assert
            Assert.Equal(85, position);
        }

        [Fact]
        public void Play_DiceOutCome_PlayerMovedSomePlaces()
        {
            // Arrange
            var board = new Mock<IBoard>();

            board.Setup(x => x.SetSize(InitializeSize()));
            board.Setup(x => x.SetLadders(InitializeLadders(85, 33)));
            board.Setup(x => x.SetPlayer(InitializePlayers(30)));
            board.Setup(x => x.SetSnakes(InitializeSnakes(36, 19)));

            board.Setup(x => x.GetLadders()).Returns(InitializeLadders(85, 33));
            board.Setup(x => x.GetPlayer()).Returns(InitializePlayers(30));
            board.Setup(x => x.GetSnakes()).Returns(InitializeSnakes(36, 19));

            // Act
            var snakeAndLadders = new SnakeAndLadders.SnakeAndLadders(board.Object);
            snakeAndLadders.Plot();
            var position = snakeAndLadders.Play(2);

            // Assert
            Assert.Equal(32, position);
        }

        [Fact]
        public void Play_DiceOutCome_PlayerDoesNotMoved()
        {
            // Arrange
            var board = new Mock<IBoard>();

            board.Setup(x => x.SetSize(InitializeSize()));
            board.Setup(x => x.SetLadders(InitializeLadders(85, 52)));
            board.Setup(x => x.SetPlayer(InitializePlayers(96)));
            board.Setup(x => x.SetSnakes(InitializeSnakes(99, 45)));

            board.Setup(x => x.GetLadders()).Returns(InitializeLadders(85, 52));
            board.Setup(x => x.GetPlayer()).Returns(InitializePlayers(96));
            board.Setup(x => x.GetSnakes()).Returns(InitializeSnakes(99, 45));

            // Act
            var snakeAndLadders = new SnakeAndLadders.SnakeAndLadders(board.Object);
            snakeAndLadders.Plot();
            var position = snakeAndLadders.Play(6);

            // Assert
            Assert.Equal(96, position);
        }

    }
}
