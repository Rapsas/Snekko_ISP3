using Xunit;
using Snakey.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SnakeyTests.Mocks;
using Common.Utility;
using System.Windows.Shapes;

namespace Snakey.Bridge.Tests
{
    [Collection("Bridge collection")]
    public class BasicCollisionTests
    {
        [StaFact]
        public void MapCollisionTestUpper()
        {
            var gameState = Mocks.GetGameState();

            gameState.Player.HeadLocation = new(-40, 0);
            List<(Vector2D, Rectangle)> obsticles = new();
            obsticles.Add((new Vector2D(0, 0), new Rectangle()));

            BasicCollision collision = new();
            collision.MapCollision(obsticles);
            Assert.False(gameState.Player.IsDead);
        }

        [StaFact]
        public void MapCollisionTestLeft()
        {
            var gameState = Mocks.GetGameState();

            gameState.Player.HeadLocation = new(0, -40);
            List<(Vector2D, Rectangle)> obsticles = new();
            obsticles.Add((new Vector2D(0, 0), new Rectangle()));

            BasicCollision collision = new();
            collision.MapCollision(obsticles);
            Assert.False(gameState.Player.IsDead);
        }

        [StaFact]
        public void MapCollisionTestBottomAndRight()
        {
            var gameState = Mocks.GetGameState();

            gameState.Player.HeadLocation = new(int.MaxValue, 0);
            List<(Vector2D, Rectangle)> obsticles = new();
            obsticles.Add((new Vector2D(0, 0), new Rectangle()));

            BasicCollision collision = new();
            collision.MapCollision(obsticles);
            Assert.False(gameState.Player.IsDead);
        }
    }
}