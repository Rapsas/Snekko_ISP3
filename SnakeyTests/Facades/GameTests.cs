using Common.Enums;
using Snakey.Managers;
using Snakey.Maps;
using SnakeyTests.Mocks;
using System.Windows.Input;
using Xunit;

namespace Snakey.Facades.Tests
{
    public class GameTests
    {
        [StaFact]
        public void InitTest()
        {
            GameState gameState = null;
            while (gameState == null)
            {
                gameState = Mocks.GetGameState();
            }

            Game game = new();
            MainWindow window = new();
            game.Init(window);
            try
            {
                Assert.True(game.Publisher != null);
                Assert.True(game.Server != null);
                Assert.True(game.Window != null);
                Assert.True(game.GameState != null);
            }
            finally
            {
                Mocks.ReleaseGameState();
            }

        }

        [StaFact]
        public void SwitchToLevelTest()
        {
            GameState gameState = null;
            while (gameState == null)
            {
                gameState = Mocks.GetGameState();
            }

            Game game = new Game();
            MainWindow window = new();
            game.Init(window);

            try
            {
                game.SwitchToLevel(MapTypes.Expert);
                Assert.IsType<ExpertMap>(game.GameState.GameMap);
                game.SwitchToLevel(MapTypes.Expert);

                game.SwitchToLevel(MapTypes.Advance);
                Assert.IsType<AdvanceMap>(game.GameState.GameMap);
                game.SwitchToLevel(MapTypes.Expert);

                game.SwitchToLevel(MapTypes.Basic);
                Assert.IsType<BasicMap>(game.GameState.GameMap);
                game.SwitchToLevel(MapTypes.Expert);
            }
            finally
            {
                Mocks.ReleaseGameState();
            }
        }

        [StaFact]
        public void HandleKeyboardTest()
        {
            GameState gameState = null;
            while (gameState == null)
            {
                gameState = Mocks.GetGameState();
            }

            Game game = new Game();
            MainWindow window = new();
            game.Init(window);

            try
            {
                game.HandleKeyboard(Key.S);
                Assert.True(game.GameState.Player.CurrentMovementDirection == MovementDirection.Down);
                game.GameState.Player.Move();

                game.HandleKeyboard(Key.A);
                Assert.True(game.GameState.Player.CurrentMovementDirection == MovementDirection.Left);
                game.GameState.Player.Move();


                game.HandleKeyboard(Key.W);
                Assert.True(game.GameState.Player.CurrentMovementDirection == MovementDirection.Up);
                game.GameState.Player.Move();

                game.HandleKeyboard(Key.D);
                Assert.True(game.GameState.Player.CurrentMovementDirection == MovementDirection.Right);
            }
            finally
            {
                Mocks.ReleaseGameState();
            }
        }
    }
}