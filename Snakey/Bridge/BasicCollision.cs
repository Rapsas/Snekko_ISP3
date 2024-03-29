﻿namespace Snakey.Bridge;

using Snakey.Iterator;
using Snakey.Managers;

public class BasicCollision : ICollision
{
    readonly GameState _gameState = GameState.Instance;

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
    }
}
