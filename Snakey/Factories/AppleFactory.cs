using Common.Enums;
using Snakey.Snacks;

namespace Snakey.Factories
{
    class AppleFactory : ISnackFactory
    {
        private MysteryApple _mysteryApple;
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
            var clonedApple = _mysteryApple.Clone();
            var a = clonedApple.ToString();
            var b = _mysteryApple.ToString();
            return _mysteryApple;
        }
        public AppleFactory()
        {
            _mysteryApple = new MysteryApple();
            _mysteryApple.SetTypesForServer(EffectType.Mystery, FoodType.Apple);
        }
    }
}
