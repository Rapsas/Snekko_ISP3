using Snakey.Models;

namespace Snakey.Observer
{
    public class SnackObserver : IObserver
    {
        public void Update(Snack snack)
        {
            snack.TriggerEffect();
            snack.WasConsumed = true;
        }
    }
}
