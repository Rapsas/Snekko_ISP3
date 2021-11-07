using Snakey.Adapter;

namespace Snakey.Observer
{
    public class SnackObserver : IObserver
    {
        public void Update(ISnackTarget snack)
        {
            snack.TriggerEffect();
            snack.WasConsumed = true;
        }
    }
}
