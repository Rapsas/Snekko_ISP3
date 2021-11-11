using Snakey.Models;

namespace Snakey.Observer
{
    public interface IObserver
    {
        void Update(Snack snack);
    }
}
