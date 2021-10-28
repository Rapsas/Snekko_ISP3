using Snakey.Adapter;

namespace Snakey.Observer
{
    interface ISubject
    {
        void RegisterObserver(IObserver observer);
        void RemoveObserver(IObserver observer);
        void NotifyObservers(ISnackTarget snack);
    }
}
