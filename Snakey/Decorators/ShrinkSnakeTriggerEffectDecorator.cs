using Snakey.Command;
using Snakey.Managers;
using Snakey.Models;

namespace Snakey.Decorators
{
    class ShrinkSnakeTriggerEffectDecorator : TriggerEffectDecorator
    {
        private CommandInvoker shrinker;
        public ShrinkSnakeTriggerEffectDecorator(Snack snack)
            : base(snack)
        {
            shrinker = new CommandInvoker();
            shrinker.SetCommand(new SnakeShrinkCommand(GameState.Instance.Player));
        }

        public override void TriggerEffect()
        {
            shrinker.ExecuteCommand();
            base.TriggerEffect();
        }
    }
}
