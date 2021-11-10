using Common.Utility;
using SnakeyTests.Mocks;
using System.Collections.Generic;
using System.Windows.Shapes;
using Xunit;

namespace Snakey.Bridge.Tests
{
    public class AdvancedCollisionTests
    {
        [StaTheory]
        [InlineData(-40, 0, 0, 0)]
        [InlineData(0, -40, 0, 0)]
        [InlineData(int.MaxValue, 0, 0, 0)]
        public void MapCollisionTestUpper(int playerX, int playerY, int objX, int objY)
        {
            using var mock = new Mocks();
            var gameState = mock.GetGameState();

            gameState.Player.HeadLocation = new(playerX, playerY);
            List<(Vector2D, Rectangle)> obsticles = new();
            obsticles.Add((new Vector2D(objX, objY), new Rectangle()));

            AdvancedCollision collision = new();
            collision.MapCollision(obsticles);
            Assert.False(gameState.Player.IsDead);
        }
    }
}