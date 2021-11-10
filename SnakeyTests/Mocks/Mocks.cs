using Snakey;
using Snakey.Config;
using Snakey.Managers;
using System;
using System.Windows.Controls;

namespace SnakeyTests.Mocks
{
    public class Mocks : IDisposable
    {
        static GameState gameState = GameState.Instance;
        static object _lock = new();
        static bool IsCurrenttlyUsed = false;
        public Mocks() { }
        public GameState GetGameState()
        {
            // Dont call it multiple times from the same test
            // or it will deadlock :^)
            lock (_lock)
            {
                while (IsCurrenttlyUsed);

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

        public void ReleaseGameState()
        {
            IsCurrenttlyUsed = false;
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

        public void Dispose()
        {
            ReleaseGameState();
        }
    }
}
