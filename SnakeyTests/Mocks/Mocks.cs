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

namespace SnakeyTests.Mocks
{
    static class Mocks
    {
        static GameState gameState = GameState.Instance;
        static public GameState GetGameState()
        {
            gameState.MultiplayerManager = GetMultiplayerManager();
            gameState.ScoreLabel = SetScoreLabel();

            // Setup snek player
            gameState.Player = new();
            gameState.Snacks = new();

            return gameState;
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

            // Setup snek player
            gameState.Player = new();
            gameState.Snacks = new();
        }
    }
}
