using Common.Enums;
using Snakey.Snacks;
using Snakey.Decorators;
using Snakey.Models;

namespace Snakey.Factories
{
    class LemonFactory : ISnackFactory
    {
        public Snack CreateBadSnack()
        {
            var snack = new BadLemon();
            var snackScoreDecorator = new DecreaseScoreTriggerEffectDecorator(snack);
            snack.SetTypesForServer(EffectType.Bad, FoodType.Lemon);

            return snackScoreDecorator;
        }

        public Snack CreateGoodSnack()
        {
            var snack = new GoodLemon();
            var snackScoreDecorator = new IncreaseScoreTriggerEffectDecorator(snack);
            snack.SetTypesForServer(EffectType.Good, FoodType.Lemon);

            return snackScoreDecorator;
        }

        public Snack CreateMysterySnack()
        {
            var snack = new MysteryLemon();
            var snackScoreDecorator = new IncreaseScoreTriggerEffectDecorator(snack);
            snack.SetTypesForServer(EffectType.Mystery, FoodType.Lemon);

            return snackScoreDecorator;
        }
    }
}
