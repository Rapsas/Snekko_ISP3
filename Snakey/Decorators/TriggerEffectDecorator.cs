namespace Snakey.Decorators;

using Common.Enums;
using Common.Utility;
using Snakey.Models;

public abstract class TriggerEffectDecorator : Snack
{
    public override Vector2D Location { get => Snack.Location; set => Snack.Location = value; }
    public override bool WasConsumed { get => Snack.WasConsumed; set => Snack.WasConsumed = value; }
    protected Snack Snack;

    public TriggerEffectDecorator(Snack snack)
    {
        Snack = snack;
    }
    public override Snack GetBaseType()
    {
        return Snack.GetBaseType();
    }

    public override void TriggerEffect()
    {
        Snack.TriggerEffect();
    }

    public override void SetTypesForServer(EffectType effectType, FoodType foodType)
    {
        Snack.SetTypesForServer(effectType, foodType);
    }
    public override void Draw()
    {
        Snack.Draw();
    }
    public override SnackPackage SnackPackage()
    {
        return Snack.SnackPackage();
    }
}
