namespace Snakey.Bridge;

using Common.Utility;
using Snakey.Iterator;
using Snakey.Managers;
using System.Windows.Shapes;

public class ExpertCollision : ICollision
{
    GameState _gameState = GameState.Instance;

    public void MapCollision(ObsticleCollection Obsticles)
    {
        var player = _gameState.Player;
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
