namespace Snakey.Decorators;

using Snakey.Managers;
using Snakey.Models;

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
