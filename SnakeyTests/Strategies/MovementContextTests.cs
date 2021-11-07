using Snakey.Models;
using Xunit;

namespace Snakey.Strategies.Tests
{
    public class MovementContextTests
    {
        [Fact()]
        public void MovementContextTest()
        {
            var result = new MovementContext();
            Assert.IsType<MovementContext>(result);
        }

        [Fact()]
        public void MovementContextTest1()
        {
            var result = new MovementContext(new MovementUpStrategy());
            Assert.IsType<MovementContext>(result);
        }
        [StaFact]
        public void ExecuteStrategyTest()
        {
            var context = new MovementContext();
            var strategy = new MovementUpStrategy();
            context.SetStrategy(strategy);
            Snake player = new Snake();
            context.ExecuteStrategy(player);

            Assert.True(player.CurrentMovementDirection == Common.Enums.MovementDirection.Up);
        }
        [Fact()]
        public void SetStrategyTest()
        {
            var context = new MovementContext();
            var strategy = new MovementLeftStrategy();
            context.SetStrategy(strategy);

            var result = context.GetStrategy();
            Assert.True(result.Equals(strategy));
        }
        [Fact()]
        public void GetStrategyTest()
        {
            var context = new MovementContext();
            var strategy = new MovementLeftStrategy();
            context.SetStrategy(strategy);

            var result = context.GetStrategy();
            Assert.True(result.Equals(strategy));
        }
    }
}