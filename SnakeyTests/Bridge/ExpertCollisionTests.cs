using Common.Utility;
using Snakey.Managers;
using SnakeyTests.Mocks;
using System.Collections.Generic;
using System.Windows.Shapes;
using Xunit;

namespace Snakey.Bridge.Tests
{
    public class ExpertCollisionTests
    {
        [StaTheory]
        [InlineData(80, 80, 80, 80)]
        [InlineData(40, 80, 40, 80)]
        [InlineData(120, 80, 120, 80)]
        public void MapCollisionTest(int playerX, int playerY, int objX, int objY)
        {
            GameState gameState = null;
            while (gameState == null)
            {
                gameState = Mocks.GetGameState();
            }
            gameState.Player.HeadLocation = new(playerX, playerY);
            List<(Vector2D, Rectangle)> obsticles = new();
            obsticles.Add((new Vector2D(objX, objY), new Rectangle()));

            ExpertCollision collision = new();
            collision.MapCollision(obsticles);
            try
            {
                Assert.True(gameState.Player.IsDead);
            }
            finally
            {
                Mocks.ReleaseGameState();
            }
        }
    }
}