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
    public class ExpertCollisionTests : IDisposable
    {
        private GameState gameState;
        public ExpertCollisionTests()
        {
            gameState = Mocks.GetGameState();
        }

        public void Dispose()
        {
            Mocks.ResetGameState();
        }

        [StaTheory]
        [InlineData(80, 80, 80, 80)]
        public void MapCollisionTest(int playerX, int playerY, int objX, int objY)
        {
            gameState.Player.HeadLocation = new(playerX, playerY);
            List<(Vector2D, Rectangle)> obsticles = new();
            obsticles.Add((new Vector2D(objX, objY), new Rectangle()));

            ExpertCollision collision = new();
            collision.MapCollision(obsticles);
            Assert.True(gameState.Player.IsDead);
        }
    }
}