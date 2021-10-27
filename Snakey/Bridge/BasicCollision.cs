﻿using Common.Utility;
using Snakey.Managers;
using System;
using System.Collections.Generic;
using System.Windows.Shapes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey.Bridge
{
    class BasicCollision : ICollision
    {
        GameState _gameState = GameState.Instance;

        public void MapCollision(List<(Vector2D, Rectangle)> Obsticles)
        {
            var player = _gameState.Player;

            if (_gameState.Player.HeadLocation.X < 0)
            {
                player.HeadLocation = new((int)_gameState.GameArea.ActualWidth, player.HeadLocation.Y);
            }
            else if (player.HeadLocation.Y < 0)
            {
                player.HeadLocation = new(player.HeadLocation.X, (int)_gameState.GameArea.ActualHeight);
            }
            else if (player.HeadLocation.X >= _gameState.GameArea.ActualWidth
                || player.HeadLocation.Y >= _gameState.GameArea.ActualHeight)
            {

                // Wrap around map
                player.HeadLocation = new(
                    player.HeadLocation.X % (int)_gameState.GameArea.ActualWidth,
                    player.HeadLocation.Y % (int)_gameState.GameArea.ActualHeight);
            }
        }
    }
}