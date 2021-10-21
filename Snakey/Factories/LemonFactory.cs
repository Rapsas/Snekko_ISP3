using Common.Enums;
using Snakey.Snacks;
using Snakey.Decorators;
using Snakey.Models;

namespace Snakey.Factories
{
    class LemonFactory : ISnackFactory
    {

        private MysteryLemon _mysteryLemon;
        public BadSnack CreateBadSnack()
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

            var clonedLemon = _mysteryLemon.DeepClone();
            return clonedLemon;
            var snackScoreDecorator = new IncreaseScoreTriggerEffectDecorator(clonedLemon);
            return snackScoreDecorator;
        }
        public LemonFactory()
        {
            _mysteryLemon = new MysteryLemon();
            _mysteryLemon.SetTypesForServer(EffectType.Mystery, FoodType.Lemon);
        }
    }
}
