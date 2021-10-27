using Snakey.Adapter;

namespace Snakey.Observer
{
    interface IObserver
    {
        void Update(SnackAdapter snack);
    }
}
