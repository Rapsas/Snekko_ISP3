namespace Snakey.Observer;

using Snakey.Models;

public interface ISubject
{
    IObserver RegisterObserver(IObserver observer);
    IObserver RemoveObserver(IObserver observer);
    int NotifyObservers(Snack snack);
}
