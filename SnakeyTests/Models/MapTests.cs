using Xunit;
using Snakey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using SnakeyTests.Mocks;
using Common.Utility;
using System.Windows.Shapes;
using Snakey.Maps;
using Snakey.Bridge;

namespace Snakey.Models.Tests
{
    public class MapTests
    {
        [Theory]
        [InlineData()]
        public void MapCollisionCheckTest()
        {
            var thread = new Thread(() => {
                var gameState = Mocks.GetGameState();

                gameState.Player.HeadLocation = new(0, 0);
                List<(Vector2D, Rectangle)> obsticles = new();
                obsticles.Add((new Vector2D(0, 0), new Rectangle()));
                Map testingObject = new ExpertMap(new ExpertCollision());
                testingObject.Obsticles = obsticles;

                testingObject.MapCollisionCheck();
                Assert.True(gameState.Player.IsDead);
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }
    }
}