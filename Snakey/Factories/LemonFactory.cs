﻿using Common.Enums;
using Snakey.Decorators;
using Snakey.Models;
using Snakey.Snacks;
using Snakey.Mediator;

namespace Snakey.Factories
{
    public class LemonFactory : ISnackFactory
    {
        private readonly IMediator _mediator;

        public LemonFactory(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Snack CreateBadSnack()
        {
            return _mediator.Send(FoodType.Lemon, EffectType.Bad);
        }

        public Snack CreateGoodSnack()
        {
            return _mediator.Send(FoodType.Lemon, EffectType.Good);
        }

        public Snack CreateMysterySnack()
        {
            var clonedLemon = (MysteryLemon)_mediator.Send(FoodType.Lemon, EffectType.Mystery);

            return new IncreaseScoreTriggerEffectDecorator(clonedLemon.DeepClone());
        }
    }
}
