namespace Snakey.Mediator;

using Common.Enums;
using Snakey.Models;

public interface IMediator
{
    Snack Send(FoodType foodType, EffectType effectType);
}
