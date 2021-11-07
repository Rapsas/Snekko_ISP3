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