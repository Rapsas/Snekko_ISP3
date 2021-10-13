using Common.Enums;
using Snakey.Snacks;

namespace Snakey.Factories
{
    class AppleFactory : ISnackFactory
    {
        public BadSnack CreateBadSnack()
        {
            var snack = new BadApple();
            snack.SetTypesForServer(EffectType.Bad, FoodType.Apple);
            return snack;
        }

        public GoodSnack CreateGoodSnack()
        {
            var snack = new GoodApple();
            snack.SetTypesForServer(EffectType.Good, FoodType.Apple);
            return snack;
        }

        public MysterySnack CreateMysterySnack()
        {
            var snack = new MysteryApple();
            snack.SetTypesForServer(EffectType.Mystery, FoodType.Apple);
            return snack;
        }
    }
}
