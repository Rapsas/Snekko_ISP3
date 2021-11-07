using Common.Enums;
using Snakey.Models;
using Xunit;

namespace Snakey.Strategies.Tests
{
    public class MovementRightStrategyTests
    {
        [StaFact]
        public void ChangeMovementDirectionTest()
        {
            var player = new Snake();
            var strategy = new MovementRightStrategy();
            strategy.ChangeMovementDirection(player);
            Assert.True(player.CurrentMovementDirection == MovementDirection.Right);
        }
    }
}