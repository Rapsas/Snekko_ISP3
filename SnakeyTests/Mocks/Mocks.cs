using Snakey;
using Snakey.Config;
using Snakey.Managers;
using System;
using System.Windows.Controls;

namespace SnakeyTests.Mocks
{
    public class Mocks : IDisposable
    {
        static readonly GameState _gameState = GameState.Instance;
        static readonly object _lock = new();
        static bool _isCurrenttlyUsed = false;
        public Mocks() { }

        /// <summary>
        /// <list type="bullet">
        ///     <item>
        ///         Sets and gets a GameState Singleton instance 
        ///     </item>
        ///     <item>
        ///         DO NOT CALL IT MULTIPLE TIMES IN THE SAME TEST
        ///     </item>
        /// </list>
        /// </summary>
        /// <returns>GameState when it's not used by any other tests</returns>
        public GameState GetGameState()
        {
            // Dont call it multiple times from the same test
            // or it will deadlock :^)
            lock (_lock)
            {
                while (_isCurrenttlyUsed) ;

                _gameState.MultiplayerManager = GetMultiplayerManager();
                _gameState.ScoreLabel = SetScoreLabel();
                _gameState.GameArea = SetCanvas();
                _gameState.GameArea.Width = Settings.WindowWidth;
                _gameState.GameArea.Height = Settings.WindowHeight;

                // Setup snek player
                _gameState.Player = new();
                _gameState.Snacks = new();
                _isCurrenttlyUsed = true;

                return _gameState;
            }
        }

        public void ReleaseGameState()
        {
            _isCurrenttlyUsed = false;
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
