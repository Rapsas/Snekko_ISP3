using Common.Enums;
using Snakey.Models;
using Xunit;

namespace Snakey.Strategies.Tests
{
    public class MovementUpStrategyTests
    {
        [StaFact]
        public void ChangeMovementDirectionTest()
        {
            var player = new Snake();
            var strategy = new MovementDownStrategy();
            strategy.ChangeMovementDirection(player);
            Assert.True(player.CurrentMovementDirection == MovementDirection.Down);
        }
    }
}