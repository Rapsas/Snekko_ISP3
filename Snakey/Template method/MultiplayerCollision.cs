namespace Snakey.Template_method
{
    public sealed class MultiplayerCollision : CollisionChecker
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
        protected override void CheckIfCollidesWithSecondPlayerHead()
        {
            if (Player.HeadLocation.IsOverlaping(SecondPlayer.HeadLocation))
            {
                Player.IsDead = true;
            }
        }
        protected override void CheckIfCollidesWithSecondPlayerBodyParts()
        {
            foreach (var bodyPart in SecondPlayer.BodyParts)
            {
                if (Player.HeadLocation.IsOverlaping(bodyPart))
                {
                    Player.IsDead = true;
                    break;
                }
            }
        }
        protected override void CheckIfCollidesWithSecondPlayerTail()
        {
            if (Player.HeadLocation.IsOverlaping(SecondPlayer.TailLocation))
            {
                Player.IsDead = true;
            }
        }
    }
}
