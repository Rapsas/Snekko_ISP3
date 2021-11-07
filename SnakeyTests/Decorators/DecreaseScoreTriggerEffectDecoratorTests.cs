﻿using Xunit;
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
            GameState gameState = null;
            while (gameState == null)
                gameState = Mocks.GetGameState();

            Mocks.ResetGameState();
            var expected = gameState.Score - 1;
            var snack = new BadApple();
            var decreaseScoreTriggerEffectDecorator = new DecreaseScoreTriggerEffectDecorator(snack);

            decreaseScoreTriggerEffectDecorator.TriggerEffect();
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
        public void TriggerEffectBadLemonTest()
        {
            GameState gameState = null;
            while (gameState == null)
                gameState = Mocks.GetGameState();

            Mocks.ResetGameState();
            var expected = gameState.Score - 1;
            var snack = new BadLemon();
            var decreaseScoreTriggerEffectDecorator = new DecreaseScoreTriggerEffectDecorator(snack);

            decreaseScoreTriggerEffectDecorator.TriggerEffect();
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