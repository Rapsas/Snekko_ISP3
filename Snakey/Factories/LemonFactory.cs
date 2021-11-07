using Common.Enums;
using Snakey.Decorators;
using Snakey.Models;
using Snakey.Snacks;

namespace Snakey.Factories
{
    public class LemonFactory : ISnackFactory
    {

        private MysteryLemon _mysteryLemon;
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
            var clonedLemon = _mysteryLemon.DeepClone();
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
