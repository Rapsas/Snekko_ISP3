using Snakey;
using Snakey.Factories;
using Snakey.Managers;
using Snakey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Snakey.Config;

namespace SnakeyTests.Mocks
{
    static class Mocks
    {
        static GameState gameState = GameState.Instance;
        static object _lock = new();
        static bool IsCurrenttlyUsed = false;
        static public GameState GetGameState()
        {
            lock (_lock)
            {
                if (IsCurrenttlyUsed)
                    return null;

                gameState.MultiplayerManager = GetMultiplayerManager();
                gameState.ScoreLabel = SetScoreLabel();
                gameState.GameArea = SetCanvas();
                gameState.GameArea.Width = Settings.WindowWidth;
                gameState.GameArea.Height = Settings.WindowHeight;

                // Setup snek player
                gameState.Player = new();
                gameState.Snacks = new();
                IsCurrenttlyUsed = true;

                return gameState;
            }
        }

        static public void ReleaseGameState()
        {
            lock (_lock)
            {
                IsCurrenttlyUsed = false;
            }
        }
        static public Canvas SetCanvas()
        {
            MainWindow window = new();
            return window.GetGameArea;
        }
        static public Label SetScoreLabel()
        {
            MainWindow window = new();
            return window.GetScoreLabel;
        }
        static public MultiplayerManager GetMultiplayerManager()
        {
            return new MultiplayerManager("http://158.129.23.210:5003/gameHub");
        }
    }
}
