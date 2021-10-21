using Common.Enums;
using Snakey.Snacks;
using Snakey.Decorators;
using Snakey.Models;

namespace Snakey.Factories
{
    class AppleFactory : ISnackFactory
    {
        public Snack CreateBadSnack()
        {
            var snack = new BadApple();
            var snackScoreDecorator = new DecreaseScoreTriggerEffectDecorator(snack);
            var snackSizeDecorator = new ShrinkSnakeTriggerEffectDecorator(snackScoreDecorator);
            snack.SetTypesForServer(EffectType.Bad, FoodType.Apple);
            
            return snackSizeDecorator;
        }

        public Snack CreateGoodSnack()
        {
            var snack = new GoodApple();
            var snackScoreDecorator = new IncreaseScoreTriggerEffectDecorator(snack);
            snack.SetTypesForServer(EffectType.Good, FoodType.Apple);
            return snackScoreDecorator;
        }

        public Snack CreateMysterySnack()
        {
            var snack = new MysteryApple();
            var snackScoreDecorator = new IncreaseScoreTriggerEffectDecorator(snack);
            snack.SetTypesForServer(EffectType.Mystery, FoodType.Apple);
            return snackScoreDecorator;
        }
    }
}
