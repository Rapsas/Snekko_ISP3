using Xunit;
using Snakey.Decorators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using SnakeyTests.Mocks;
using Snakey.Snacks;
using Snakey.Managers;

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

            Mocks.ResetGameState();
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

            Mocks.ResetGameState();
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
    }
}