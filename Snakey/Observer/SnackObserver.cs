using Snakey.Adapter;

namespace Snakey.Observer
{
    class SnackObserver : IObserver
    {
        public void Update(SnackAdapter snack)
        {
            snack.TriggerEffect();
            snack.WasConsumed = true;
        }
    }
}
