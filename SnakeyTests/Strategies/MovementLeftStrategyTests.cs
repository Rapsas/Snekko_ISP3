using Common.Enums;
using Snakey.Models;
using Xunit;

namespace Snakey.Strategies.Tests
{
    public class MovementLeftStrategyTests
    {
        [StaFact]
        public void ChangeMovementDirectionTest()
        {
            var player = new Snake();
            player.CurrentMovementDirection = MovementDirection.Up;
            var strategy = new MovementLeftStrategy();
            strategy.ChangeMovementDirection(player);
            Assert.True(player.CurrentMovementDirection == MovementDirection.Left);
        }
    }
}