using Snakey.Models;

namespace Snakey.Factories
{
    public interface ISnackFactory
    {
        Snack CreateGoodSnack();
        Snack CreateBadSnack();
        Snack CreateMysterySnack();
    }
}
