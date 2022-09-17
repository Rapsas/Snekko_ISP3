namespace Snakey.Mediator;

using Common.Enums;
using Snakey.Decorators;
using Snakey.Models;
using Snakey.Snacks;

public class SnackMediator : IMediator
{
    public Snack Send(FoodType foodType, EffectType effectType)
    {
        return foodType switch
        {
            FoodType.Apple => CreateApple(effectType),
            FoodType.Lemon => CreateLemon(effectType),
            _ => null,
        };
    }

    private Snack CreateApple(EffectType effectType)
    {
        Snack snack;
        TriggerEffectDecorator snackScoreDecorator;
        switch (effectType)
        {
            case EffectType.Good:
                snack = new GoodApple();
                snackScoreDecorator = new IncreaseScoreTriggerEffectDecorator(snack);
                snack.SetTypesForServer(EffectType.Good, FoodType.Apple);
                return snackScoreDecorator;

            case EffectType.Bad:
                snack = new BadApple();
                snackScoreDecorator = new DecreaseScoreTriggerEffectDecorator(snack);
                var snackSizeDecorator = new ShrinkSnakeTriggerEffectDecorator(snackScoreDecorator);
                snack.SetTypesForServer(EffectType.Bad, FoodType.Apple);
                return snackSizeDecorator;

            case EffectType.Mystery:
                snack = new MysteryApple();
                snack.SetTypesForServer(EffectType.Mystery, FoodType.Apple);
                return snack;

            default:
                return null;
        }
    }

    private Snack CreateLemon(EffectType effectType)
    {
        Snack snack;
        TriggerEffectDecorator snackScoreDecorator;

        switch (effectType)
        {
            case EffectType.Good:
                snack = new BadLemon();
                snackScoreDecorator = new DecreaseScoreTriggerEffectDecorator(snack);
                snack.SetTypesForServer(EffectType.Bad, FoodType.Lemon);
                return snackScoreDecorator;

            case EffectType.Bad:
                snack = new GoodLemon();
                snackScoreDecorator = new IncreaseScoreTriggerEffectDecorator(snack);
                snack.SetTypesForServer(EffectType.Good, FoodType.Lemon);
                return snackScoreDecorator;

            case EffectType.Mystery:
                snack = new MysteryLemon();
                snack.SetTypesForServer(EffectType.Mystery, FoodType.Lemon);
                return snack;

            default:
                return null;
        }
    }
}
