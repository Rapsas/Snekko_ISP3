using Snakey.Managers;
using Snakey.Models;

namespace Snakey.Decorators
{
    public class IncreaseScoreTriggerEffectDecorator : TriggerEffectDecorator
    {
        public IncreaseScoreTriggerEffectDecorator(Snack snack)
            : base(snack) { }

        public override void TriggerEffect()
        {
            GameState.Instance.Score++;
            base.TriggerEffect();
        }
    }
}
