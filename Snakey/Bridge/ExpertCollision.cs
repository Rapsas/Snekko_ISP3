using Common.Utility;
using Snakey.Managers;
using System.Collections.Generic;
using System.Windows.Shapes;

namespace Snakey.Bridge
{
    class ExpertCollision : ICollision
    {
        GameState _gameState = GameState.Instance;

        public void MapCollision(List<(Vector2D, Rectangle)> Obsticles)
        {
            var player = _gameState.Player;
            foreach (var (location, _) in Obsticles)
            {
                if (location.IsOverlaping(player.HeadLocation))
                {
                    player.IsDead = true;
                    return;
                }
            }
        }
    }
}
