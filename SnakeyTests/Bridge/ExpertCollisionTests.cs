using Xunit;
using Snakey.Bridge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SnakeyTests.Mocks;
using Common.Utility;
using System.Windows.Shapes;
using System.Threading;
using Snakey.Managers;

namespace Snakey.Bridge.Tests
{
    [Collection("Bridge collection")]
    public class ExpertCollisionTests
    {
        [StaTheory]
        [InlineData(80, 80, 80, 80)]
        [InlineData(40, 80, 40, 80)]
        [InlineData(0, 80, 40, 0)]
        public void MapCollisionTest(int playerX, int playerY, int objX, int objY)
        {
            GameState gameState = null;
            while(gameState == null)
            {
                gameState = Mocks.GetGameState();
            }
            gameState.Player.HeadLocation = new(playerX, playerY);
            List<(Vector2D, Rectangle)> obsticles = new();
            obsticles.Add((new Vector2D(objX, objY), new Rectangle()));

            ExpertCollision collision = new();
            collision.MapCollision(obsticles);
            Assert.True(gameState.Player.IsDead);
            Mocks.ReleaseGameState();
        }
    }
}