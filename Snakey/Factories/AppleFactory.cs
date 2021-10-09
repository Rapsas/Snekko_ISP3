using Snakey.Snacks;

namespace Snakey.Factories
{
    class AppleFactory : ISnackFactory
    {
        public BadSnack CreateBadSnack()
        {
            return new BadApple();
        }

        public GoodSnack CreateGoodSnack()
        {
            return new GoodApple();
        }

        public MysterySnack CreateMysterySnack()
        {
            return new MysteryApple();
        }
    }
}
