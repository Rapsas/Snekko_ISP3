using Common.Enums;
using Snakey.Decorators;
using Snakey.Mediator;
using Snakey.Models;
using Snakey.Snacks;

namespace Snakey.Factories
{
    public class AppleFactory : ISnackFactory
    {
        private readonly IMediator _mediator;

        public AppleFactory(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Snack CreateBadSnack()
        {
            return _mediator.Send(FoodType.Apple, EffectType.Bad);
        }

        public Snack CreateGoodSnack()
        {
            return _mediator.Send(FoodType.Apple, EffectType.Good);
        }

        public Snack CreateMysterySnack()
        {
            var clonedApple = (MysteryApple)_mediator.Send(FoodType.Apple, EffectType.Mystery);

            return new IncreaseScoreTriggerEffectDecorator(clonedApple.DeepClone());
        }
    }
}
