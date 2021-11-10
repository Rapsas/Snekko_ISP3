using Common.Utility;
using Snakey.Bridge;
using Snakey.Maps;
using SnakeyTests.Mocks;
using System.Collections.Generic;
using System.Windows.Shapes;
using Xunit;

namespace Snakey.Models.Tests
{
    public class MapTests
    {
        [StaFact]
        public void MapCollisionCheckTest()
        {
            using var mock = new Mocks();
            var gameState = mock.GetGameState();

            gameState.Player.HeadLocation = new(0, 0);
            List<(Vector2D, Rectangle)> obsticles = new();
            obsticles.Add((new Vector2D(0, 0), new Rectangle()));
            Map testingObject = new ExpertMap(new ExpertCollision());
            testingObject.Obsticles = obsticles;

            testingObject.MapCollisionCheck();
            Assert.True(gameState.Player.IsDead);
        }
    }
}