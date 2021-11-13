using Snakey.Managers;
using Snakey.Models;

namespace Snakey.Template_method
{
    public abstract class CollisionChecker
    {
        private Snake player;
        private Snake secondPlayer;
        public void CheckCollision()
        {
            player = GameState.Instance.Player;
            CheckIfPlayerCollidesWithBodyParts();
            CheckIfPlayerCollidesWithTail();

            if (CheckSecondPlayer())
            {
                secondPlayer = GameState.Instance.SecondPlayer;
                CheckIfCollidesWithSecondPlayerHead();
                CheckIfCollidesWithSecondPlayerBodyParts();
                CheckIfCollidesWithSecondPlayerTail();
            }
        }
        private void CheckIfPlayerCollidesWithBodyParts()
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

        private void CheckIfPlayerCollidesWithTail()
        {
            if (player.HeadLocation.IsOverlaping(player.TailLocation))
            {
                player.IsDead = true;
            }
        }

        private void CheckIfCollidesWithSecondPlayerHead()
        {
            if (player.HeadLocation.IsOverlaping(secondPlayer.HeadLocation))
            {
                player.IsDead = true;
            }
        }

        private void CheckIfCollidesWithSecondPlayerBodyParts()
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

        private void CheckIfCollidesWithSecondPlayerTail()
        {
            if (player.HeadLocation.IsOverlaping(secondPlayer.TailLocation))
            {
                player.IsDead = true;
            }
        }

        // Hook
        public abstract bool CheckSecondPlayer();
    }
}
