using Xunit;
using Snakey.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Common.Enums;
using Snakey.Maps;
using System.Windows.Input;

namespace Snakey.Facades.Tests
{
    public class GameTests
    {
        [StaFact]
        public void InitTest()
        {
            Game game = new();
            MainWindow window = new();
            game.Init(window);
            Assert.True(game.Publisher != null);
            Assert.True(game.Server != null);
            Assert.True(game.Window != null);
            Assert.True(game.GameState != null);

        }

        [StaFact]
        public void SwitchToLevelTest()
        {
            Game game = new Game();
            MainWindow window = new();
            game.Init(window);

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

        [StaFact]
        public void HandleKeyboardTest()
        {
            Game game = new Game();
            MainWindow window = new();
            game.Init(window);

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
    }
}