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
            GameState gameState = null;
            while (gameState == null)
                gameState = Mocks.GetGameState();

            gameState.Player.Expand();
            var expected = gameState.Player.BodyParts.Count - 1;
            var snack = new BadApple();
            var shrinkSnakeTriggerEffectDecorator = new ShrinkSnakeTriggerEffectDecorator(snack);

            shrinkSnakeTriggerEffectDecorator.TriggerEffect();
            var actual = gameState.Player.BodyParts.Count;

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