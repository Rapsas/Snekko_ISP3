using Snakey.Managers;
using Snakey.Models;

namespace Snakey.Template_method
{
    public abstract class CollisionChecker
    {
        private Snake player;
        private Snake secondPlayer;

        protected Snake Player { get => player; set => player = value; }
        protected Snake SecondPlayer { get => secondPlayer; set => secondPlayer = value; }

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
}
