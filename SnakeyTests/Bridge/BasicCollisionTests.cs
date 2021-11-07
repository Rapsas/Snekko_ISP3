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
using Snakey.Managers;

namespace Snakey.Bridge.Tests
{
    public class BasicCollisionTests
    {
        [StaTheory]
        [InlineData(-40, 0, 0, 0)]
        [InlineData(0, -40, 0, 0)]
        [InlineData(int.MaxValue, 0, 0, 0)]
        public void MapCollisionTestUpper(int playerX, int playerY, int objX, int objY)
        {
            GameState gameState = null;
            while (gameState == null)
            {
                gameState = Mocks.GetGameState();
            }
            gameState.Player.HeadLocation = new(-40, 0);
            List<(Vector2D, Rectangle)> obsticles = new();
            obsticles.Add((new Vector2D(0, 0), new Rectangle()));

            BasicCollision collision = new();
            collision.MapCollision(obsticles);
            try
            {
                Assert.False(gameState.Player.IsDead);
            }
            finally
            {
                Mocks.ReleaseGameState();
            }
        }

        //[StaFact]
        //public void MapCollisionTestLeft()
        //{
        //    var gameState = Mocks.GetGameState();

        //    gameState.Player.HeadLocation = new(0, -40);
        //    List<(Vector2D, Rectangle)> obsticles = new();
        //    obsticles.Add((new Vector2D(0, 0), new Rectangle()));

        //    BasicCollision collision = new();
        //    collision.MapCollision(obsticles);
        //    Assert.False(gameState.Player.IsDead);
        //}

        //[StaFact]
        //public void MapCollisionTestBottomAndRight()
        //{
        //    var gameState = Mocks.GetGameState();

        //    gameState.Player.HeadLocation = new(int.MaxValue, 0);
        //    List<(Vector2D, Rectangle)> obsticles = new();
        //    obsticles.Add((new Vector2D(0, 0), new Rectangle()));

        //    BasicCollision collision = new();
        //    collision.MapCollision(obsticles);
        //    Assert.False(gameState.Player.IsDead);
        //}
    }
}