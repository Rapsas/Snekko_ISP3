namespace Snakey.Template_method
{
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
                }//asdfghjkl
        }
        protected override void CheckIfPlayerCollidesWithTail()
        {
            if (player.HeadLocation.IsOverlaping(player.TailLocation))
            {
                player.IsDead = true;
            }
        }
        protected override void CheckIfCollidesWithSecondPlayerBodyParts()
        {
            return;
        }
        protected override void CheckIfCollidesWithSecondPlayerHead()
        {
            return;
        }
        protected override void CheckIfCollidesWithSecondPlayerTail()
        {
            return;
        }


    }
}
