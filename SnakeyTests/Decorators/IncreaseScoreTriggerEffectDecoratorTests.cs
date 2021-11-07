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

namespace Snakey.Decorators.Tests
{
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
            Mocks.ResetGameState();
            var gameState = Mocks.GetGameState();
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
            Mocks.ResetGameState();
            var gameState = Mocks.GetGameState();
            var expected = gameState.Score + 1;
            var snack = new GoodLemon();
            var increaseScoreTriggerEffectDecorator = new IncreaseScoreTriggerEffectDecorator(snack);

            increaseScoreTriggerEffectDecorator.TriggerEffect();
            var actual = gameState.Score;

            Assert.Equal(expected, actual);
        }
    }
}