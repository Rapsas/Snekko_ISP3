using Snakey.Snacks;
using SnakeyTests.Mocks;
using Xunit;

namespace Snakey.Decorators.Tests
{
    [Collection("Decorator collection")]
    public class IncreaseScoreTriggerEffectDecoratorTests
    {
        [StaFact]
        public void IncreaseScoreTriggerEffectDecoratorTest()
        {
            var snack = new GoodApple();
            var increaseScoreTriggerEffectDecorator = new IncreaseScoreTriggerEffectDecorator(snack);

            Assert.IsType<IncreaseScoreTriggerEffectDecorator>(increaseScoreTriggerEffectDecorator);
        }

        [StaFact]
        public void TriggerEffectGoodAppleTest()
        {
            using var mock = new Mocks();
            var gameState = mock.GetGameState();

            var expected = gameState.Score + 1;
            var snack = new GoodApple();
            var increaseScoreTriggerEffectDecorator = new IncreaseScoreTriggerEffectDecorator(snack);

            increaseScoreTriggerEffectDecorator.TriggerEffect();
            var actual = gameState.Score;

            Assert.Equal(expected, actual);
        }

        [StaFact]
        public void TriggerEffectGoodLemonTest()
        {
            using var mock = new Mocks();
            var gameState = mock.GetGameState();

            var expected = gameState.Score + 1;
            var snack = new GoodLemon();
            var increaseScoreTriggerEffectDecorator = new IncreaseScoreTriggerEffectDecorator(snack);

            increaseScoreTriggerEffectDecorator.TriggerEffect();
            var actual = gameState.Score;

            Assert.Equal(expected, actual);
        }

        [StaFact]
        public void TriggerEffectMysteryLemonTest()
        {
            using var mock = new Mocks();
            var gameState = mock.GetGameState();

            var expected = gameState.Score + 1;
            var snack = new MysteryLemon();
            var increaseScoreTriggerEffectDecorator = new IncreaseScoreTriggerEffectDecorator(snack);

            increaseScoreTriggerEffectDecorator.TriggerEffect();
            var actual = gameState.Score;

            Assert.Equal(expected, actual);
        }
    }
}