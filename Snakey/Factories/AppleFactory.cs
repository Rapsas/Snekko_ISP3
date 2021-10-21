using Common.Enums;
using Snakey.Snacks;
using Snakey.Decorators;
using Snakey.Models;

namespace Snakey.Factories
{
    class AppleFactory : ISnackFactory
    {
        private MysteryApple _mysteryApple;
        public BadSnack CreateBadSnack()
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
            var clonedApple = _mysteryApple.DeepClone();
            //var deepClonedApple = _mysteryApple.DeepClone();
            //var a = clonedApple.ToString();
            //var b = _mysteryApple.ToString();
            //var c = deepClonedApple.ToString();
            var snackScoreDecorator = new IncreaseScoreTriggerEffectDecorator(clonedApple);
            return snackScoreDecorator;
        }
        public AppleFactory()
        {
            _mysteryApple = new MysteryApple();
            _mysteryApple.SetTypesForServer(EffectType.Mystery, FoodType.Apple);
        }
    }
}
