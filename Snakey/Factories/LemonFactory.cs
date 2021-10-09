using Snakey.Snacks;

namespace Snakey.Factories
{
    class LemonFactory : ISnackFactory
    {
        public BadSnack CreateBadSnack()
        {
            return new BadLemon();
        }

        public GoodSnack CreateGoodSnack()
        {
            return new GoodLemon();
        }

        public MysterySnack CreateMysterySnack()
        {
            return new MysteryLemon();
        }
    }
}
