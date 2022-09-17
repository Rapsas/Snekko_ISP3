namespace Snakey.Observer;

using Snakey.Models;

public interface IObserver
{
    void Update(Snack snack);
}
