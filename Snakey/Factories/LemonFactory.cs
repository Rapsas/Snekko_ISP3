using Common.Enums;
using Snakey.Snacks;

namespace Snakey.Factories
{
    class LemonFactory : ISnackFactory
    {
        public BadSnack CreateBadSnack()
        {
            var snack = new BadLemon();
            snack.SetTypesForServer(EffectType.Bad, FoodType.Lemon);
            return snack;
        }

        public GoodSnack CreateGoodSnack()
        {
            var snack = new GoodLemon();
            snack.SetTypesForServer(EffectType.Good, FoodType.Lemon);
            return snack;
        }

        public MysterySnack CreateMysterySnack()
        {
            var snack = new MysteryLemon();
            snack.SetTypesForServer(EffectType.Mystery, FoodType.Lemon);
            return snack;
        }
    }
}
