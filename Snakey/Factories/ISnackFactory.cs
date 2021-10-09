using Snakey.Snacks;

namespace Snakey.Factories
{
    interface ISnackFactory
    {
        GoodSnack CreateGoodSnack();
        BadSnack CreateBadSnack();
        MysterySnack CreateMysterySnack();
    }
}
