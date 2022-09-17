namespace Snakey.Template_method;

public sealed class MultiplayerCollision : CollisionChecker
{
    protected override void CheckIfPlayerCollidesWithBodyParts()
    {
        if (player.IgnoreBodyCollisionWithHead)
            return;
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
    protected override void CheckIfCollidesWithSecondPlayerHead()
    {
        if (player.HeadLocation.IsOverlaping(secondPlayer.HeadLocation))
            player.IsDead = true;
    }
    protected override void CheckIfCollidesWithSecondPlayerBodyParts()
    {
        foreach (var bodyPart in secondPlayer.BodyParts)
        {
            if (player.HeadLocation.IsOverlaping(bodyPart))
            {
                player.IsDead = true;
                break;
            }
        }
    }
    protected override void CheckIfCollidesWithSecondPlayerTail()
    {
        if (player.HeadLocation.IsOverlaping(secondPlayer.TailLocation))
            player.IsDead = true;
    }
}
