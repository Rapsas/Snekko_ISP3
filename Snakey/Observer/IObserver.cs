using Snakey.Adapter;

namespace Snakey.Observer
{
    public interface IObserver
    {
        void Update(ISnackTarget snack);
    }
}
