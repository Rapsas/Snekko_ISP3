using Snakey.Adapter;

namespace Snakey.Observer
{
    class SnackObserver : IObserver
    {
        public void Update(ISnackTarget snack)
        {
            snack.TriggerEffect();
            snack.WasConsumed = true;
        }
    }
}
