namespace Snakey.Template_method;

using Snakey.Managers;
using Snakey.Models;

public abstract class CollisionChecker
{
    protected Snake player;
    protected Snake secondPlayer;
    public void CheckCollision()
    {
        player = GameState.Instance.Player;
        CheckIfPlayerCollidesWithBodyParts();
        CheckIfPlayerCollidesWithTail();

        secondPlayer = GameState.Instance.SecondPlayer;
        CheckIfCollidesWithSecondPlayerHead();
        CheckIfCollidesWithSecondPlayerBodyParts();
        CheckIfCollidesWithSecondPlayerTail();
    }
    protected abstract void CheckIfPlayerCollidesWithBodyParts();
    protected abstract void CheckIfPlayerCollidesWithTail();
    protected abstract void CheckIfCollidesWithSecondPlayerHead();
    protected abstract void CheckIfCollidesWithSecondPlayerBodyParts();
    protected abstract void CheckIfCollidesWithSecondPlayerTail();
}
