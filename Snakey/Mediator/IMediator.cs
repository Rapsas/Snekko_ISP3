using Common.Enums;
using Snakey.Models;

namespace Snakey.Mediator
{
    public interface IMediator
    {
        Snack Send(FoodType foodType, EffectType effectType);
    }
}
