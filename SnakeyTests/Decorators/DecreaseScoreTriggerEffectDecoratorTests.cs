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
            Mocks.ResetGameState();
            var gameState = Mocks.GetGameState();
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
            Mocks.ResetGameState();
            var gameState = Mocks.GetGameState();
            var expected = gameState.Score - 1;
            var snack = new BadLemon();
            var decreaseScoreTriggerEffectDecorator = new DecreaseScoreTriggerEffectDecorator(snack);

            decreaseScoreTriggerEffectDecorator.TriggerEffect();
            var actual = gameState.Score;

            Assert.Equal(expected, actual);
        }
    }
}