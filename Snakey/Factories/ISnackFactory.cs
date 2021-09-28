using Snakey.Snacks;

namespace Snakey.Factories
{
    interface ISnackFactory
    {
        Snack CreateGoodSnack();
        Snack CreateBadSnack();
        Snack CreateMysterySnack();
    }
}
