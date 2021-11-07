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
    public class BasicCollisionTests
    {
        [Theory]
        [InlineData(1, 2, 1, 2)]
        [InlineData(1, 0, 1, 0)]
        [InlineData(123, 0, 123, 0)]
        [InlineData(0, 0, 0, 0)]
        public void MapCollisionTest(int playerX, int playerY, int objX, int objY)
        {
            var thread = new Thread(() => {
                var gameState = Mocks.GetGameState();

                gameState.Player.HeadLocation = new(playerX, playerY);
                List<(Vector2D, Rectangle)> obsticles = new();
                obsticles.Add((new Vector2D(objX, objY), new Rectangle()));

                BasicCollision collision = new();
                collision.MapCollision(obsticles);
                Assert.True(gameState.Player.IsDead);
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}