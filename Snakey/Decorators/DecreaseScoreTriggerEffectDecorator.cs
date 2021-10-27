using Snakey.Managers;
using Snakey.Models;

namespace Snakey.Decorators
{
    public class DecreaseScoreTriggerEffectDecorator : TriggerEffectDecorator
    {
        public DecreaseScoreTriggerEffectDecorator(Snack snack)
            : base(snack) { }

        public override void TriggerEffect()
        {
            GameState.Instance.Score--;
            base.TriggerEffect();
        }
    }
}
