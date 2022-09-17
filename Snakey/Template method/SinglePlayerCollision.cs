namespace Snakey.Template_method;

public sealed class SinglePlayerCollision : CollisionChecker
{
    protected override void CheckIfPlayerCollidesWithBodyParts()
    {
        if (!player.IgnoreBodyCollisionWithHead)
            foreach (var bodyPart in player.BodyParts)
            {
                if (player.HeadLocation.IsOverlaping(bodyPart))
                {
                    player.IsDead = true;
                    break;
                }
            }
    }
    protected override void CheckIfPlayerCollidesWithTail()
    {
        if (player.HeadLocation.IsOverlaping(player.TailLocation))
            player.IsDead = true;
    }
    protected override void CheckIfCollidesWithSecondPlayerBodyParts() { }
    protected override void CheckIfCollidesWithSecondPlayerHead() { }
    protected override void CheckIfCollidesWithSecondPlayerTail() { }
}
