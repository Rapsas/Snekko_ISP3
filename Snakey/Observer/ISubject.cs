using Snakey.Adapter;

namespace Snakey.Observer
{
    public interface ISubject
    {
        IObserver RegisterObserver(IObserver observer);
        IObserver RemoveObserver(IObserver observer);
        int NotifyObservers(ISnackTarget snack);
    }
}
