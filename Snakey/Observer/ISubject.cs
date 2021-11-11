using Snakey.Models;

namespace Snakey.Observer
{
    public interface ISubject
    {
        IObserver RegisterObserver(IObserver observer);
        IObserver RemoveObserver(IObserver observer);
        int NotifyObservers(Snack snack);
    }
}
