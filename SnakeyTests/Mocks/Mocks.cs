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

        static public GameState GetGameState()
        {
            GameState gameState = GameState.Instance;
            gameState.MultiplayerManager = GetMultiplayerManager();
            gameState.ScoreLabel = SetScoreLabel();
            gameState.GameArea = SetCanvas();
            gameState.GameArea.Width = Settings.WindowWidth;
            gameState.GameArea.Height = Settings.WindowHeight;

            // Setup snek player
            gameState.Player = new();
            gameState.Snacks = new();

            return gameState;
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

        static public void ResetGameState()
        {
            gameState.MultiplayerManager = GetMultiplayerManager();
            gameState.ScoreLabel = SetScoreLabel();
            gameState.GameArea = SetCanvas();
            gameState.GameArea.Width = Settings.WindowWidth;
            gameState.GameArea.Height = Settings.WindowHeight;

            // Setup snek player
            gameState.Player = new();
            gameState.Snacks = new();
        }
    }
}
