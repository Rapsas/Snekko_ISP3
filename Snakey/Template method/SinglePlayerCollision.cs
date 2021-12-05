namespace Snakey.Template_method
{
    public sealed class SinglePlayerCollision : CollisionChecker
    {
        protected override void CheckIfPlayerCollidesWithBodyParts()
        {
            if (!Player.IgnoreBodyCollisionWithHead)
                foreach (var bodyPart in Player.BodyParts)
                {
                    if (Player.HeadLocation.IsOverlaping(bodyPart))
                    {
                        Player.IsDead = true;
                        break;
                    }
                }
        }
        protected override void CheckIfPlayerCollidesWithTail()
        {
            if (Player.HeadLocation.IsOverlaping(Player.TailLocation))
            {
                Player.IsDead = true;
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
