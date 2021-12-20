using Common.Utility;
using Snakey.Iterator;
using Snakey.Managers;
using System.Windows.Shapes;

namespace Snakey.Bridge
{
    public class AdvancedCollision : ICollision
    {
        GameState _gameState = GameState.Instance;

        public void MapCollision(ObsticleCollection Obsticles)
        {
            var player = _gameState.Player;

            if (_gameState.Player.HeadLocation.X < 0)
            {
                player.HeadLocation = new((int)_gameState.GameArea.Width, player.HeadLocation.Y);
            }
            else if (player.HeadLocation.Y < 0)
            {
                player.HeadLocation = new(player.HeadLocation.X, (int)_gameState.GameArea.Height);
            }
            else if (player.HeadLocation.X >= _gameState.GameArea.Width
                || player.HeadLocation.Y >= _gameState.GameArea.Height)
            {

                // Wrap around map
                player.HeadLocation = new(
                    player.HeadLocation.X % (int)_gameState.GameArea.Width,
                    player.HeadLocation.Y % (int)_gameState.GameArea.Height);
            }

            IIterator obsticlesIterator = Obsticles.CreateIterator();
            while (obsticlesIterator.HasMore())
            {
                var (location, _) = ((Vector2D, Rectangle))obsticlesIterator.GetNext();
                if (location.IsOverlaping(player.HeadLocation))
                {
                    player.IsDead = true;
                    return;
                }
            }
        }
    }
}
