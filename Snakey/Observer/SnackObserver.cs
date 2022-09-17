namespace Snakey.Observer;

using Snakey.Models;

public class SnackObserver : IObserver
{
    public void Update(Snack snack)
    {
        snack.TriggerEffect();
        snack.WasConsumed = true;
    }
}
