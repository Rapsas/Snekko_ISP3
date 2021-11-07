using Snakey.Managers;
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
            GameState gameState = null;
            while (gameState == null)
                gameState = Mocks.GetGameState();

            var expected = gameState.Score + 1;
            var snack = new GoodApple();
            var increaseScoreTriggerEffectDecorator = new IncreaseScoreTriggerEffectDecorator(snack);

            increaseScoreTriggerEffectDecorator.TriggerEffect();
            var actual = gameState.Score;

            try
            {
                Assert.Equal(expected, actual);
            }
            finally
            {
                Mocks.ReleaseGameState();
            }
        }

        [StaFact]
        public void TriggerEffectGoodLemonTest()
        {
            GameState gameState = null;
            while (gameState == null)
                gameState = Mocks.GetGameState();

            var expected = gameState.Score + 1;
            var snack = new GoodLemon();
            var increaseScoreTriggerEffectDecorator = new IncreaseScoreTriggerEffectDecorator(snack);

            increaseScoreTriggerEffectDecorator.TriggerEffect();
            var actual = gameState.Score;

            try
            {
                Assert.Equal(expected, actual);
            }
            finally
            {
                Mocks.ReleaseGameState();
            }
        }

        [StaFact]
        public void TriggerEffectMysteryLemonTest()
        {
            GameState gameState = null;
            while (gameState == null)
                gameState = Mocks.GetGameState();

            var expected = gameState.Score + 1;
            var snack = new MysteryLemon();
            var increaseScoreTriggerEffectDecorator = new IncreaseScoreTriggerEffectDecorator(snack);

            increaseScoreTriggerEffectDecorator.TriggerEffect();
            var actual = gameState.Score;

            try
            {
                Assert.Equal(expected, actual);
            }
            finally
            {
                Mocks.ReleaseGameState();
            }
        }
    }
}