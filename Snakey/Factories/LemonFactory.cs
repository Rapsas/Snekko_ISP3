using Common.Enums;
using Snakey.Snacks;

namespace Snakey.Factories
{
    class LemonFactory : ISnackFactory
    {
        private MysteryLemon _mysteryLemon;
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
            return _mysteryLemon;
        }
        public LemonFactory()
        {
            _mysteryLemon = new MysteryLemon();
            _mysteryLemon.SetTypesForServer(EffectType.Mystery, FoodType.Lemon);
        }
    }
}
