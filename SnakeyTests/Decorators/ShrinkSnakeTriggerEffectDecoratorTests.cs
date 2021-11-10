using Snakey.Snacks;
using SnakeyTests.Mocks;
using Xunit;

namespace Snakey.Decorators.Tests
{
    [Collection("Decorator collection")]
    public class ShrinkSnakeTriggerEffectDecoratorTests
    {
        [StaFact]
        public void ShrinkSnakeTriggerEffectDecoratorTest()
        {
            var snack = new BadApple();
            var shrinkSnakeTriggerEffectDecorator = new ShrinkSnakeTriggerEffectDecorator(snack);

            Assert.IsType<ShrinkSnakeTriggerEffectDecorator>(shrinkSnakeTriggerEffectDecorator);
        }

        [StaFact]
        public void TriggerEffectBadAppleTest()
        {
            using var mock = new Mocks();
            var gameState = mock.GetGameState();

            gameState.Player.Expand();
            var expected = gameState.Player.BodyParts.Count - 1;
            var snack = new BadApple();
            var shrinkSnakeTriggerEffectDecorator = new ShrinkSnakeTriggerEffectDecorator(snack);

            shrinkSnakeTriggerEffectDecorator.TriggerEffect();
            var actual = gameState.Player.BodyParts.Count;

            Assert.Equal(expected, actual);
        }
    }
}