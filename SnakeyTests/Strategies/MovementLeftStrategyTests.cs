using Xunit;
using Snakey.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Snakey.Models;
using Common.Enums;

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