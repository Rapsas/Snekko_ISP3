using Snakey.Models;

namespace Snakey.Factories
{
    interface ISnackFactory
    {
        Snack CreateGoodSnack();
        Snack CreateBadSnack();
        Snack CreateMysterySnack();
    }
}
