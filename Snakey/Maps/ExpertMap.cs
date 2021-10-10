using Snakey.Managers;
using Snakey.Models;
using System;

namespace Snakey.Maps
{
    class ExpertMap : Map
    {
        GameState _gameState = GameState.Instance;

        public override void MapCollisionCheck()
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
