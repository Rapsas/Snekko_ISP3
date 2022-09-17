namespace Snakey.Factories;

using Snakey.Models;

public interface ISnackFactory
{
    Snack CreateGoodSnack();
    Snack CreateBadSnack();
    Snack CreateMysterySnack();
}
