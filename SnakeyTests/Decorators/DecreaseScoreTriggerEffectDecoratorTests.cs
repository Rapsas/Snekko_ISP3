using Snakey.Snacks;
using SnakeyTests.Mocks;
using Xunit;

namespace Snakey.Decorators.Tests
{
    [Collection("Decorator collection")]
    public class DecreaseScoreTriggerEffectDecoratorTests
    {
        [StaFact]
        public void DecreaseScoreTriggerEffectDecoratorTest()
        {
            var snack = new BadApple();
            var decreaseScoreTriggerEffectDecorator = new DecreaseScoreTriggerEffectDecorator(snack);

            Assert.IsType<DecreaseScoreTriggerEffectDecorator>(decreaseScoreTriggerEffectDecorator);
        }

        [StaFact]
        public void TriggerEffectBadAppleTest()
        {
            using var mock = new Mocks();
            var gameState = mock.GetGameState();

            var expected = gameState.Score - 1;
            var snack = new BadApple();
            var decreaseScoreTriggerEffectDecorator = new DecreaseScoreTriggerEffectDecorator(snack);

            decreaseScoreTriggerEffectDecorator.TriggerEffect();
            var actual = gameState.Score;

            Assert.Equal(expected, actual);
        }

        [StaFact]
        public void TriggerEffectBadLemonTest()
        {
            using var mock = new Mocks();
            var gameState = mock.GetGameState();

            var expected = gameState.Score - 1;
            var snack = new BadLemon();
            var decreaseScoreTriggerEffectDecorator = new DecreaseScoreTriggerEffectDecorator(snack);

            decreaseScoreTriggerEffectDecorator.TriggerEffect();
            var actual = gameState.Score;

            Assert.Equal(expected, actual);
        }
    }
}