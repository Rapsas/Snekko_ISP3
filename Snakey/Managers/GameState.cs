using Microsoft.AspNetCore.SignalR.Client;
using Snakey.Chain_of_Responsibility;
using Snakey.Config;
using Snakey.Iterator;
using Snakey.Models;
using System;
using System.IO;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Snakey.Managers
{
    public class GameState
    {
        private static readonly GameState _instance = new();
        private int _gameScore = 0;
        private int _gameScoreEnemy = 0;

        public Snake Player { get; set; }
        public Snake SecondPlayer { get; set; }
        public SnackCollection Snacks { get; set; }
        public DispatcherTimer GameTimer { get; set; }
        public Canvas GameArea { get; set; }
        public Label ScoreLabel { get; set; }
        public MultiplayerManager MultiplayerManager { get; set; }
        public Map GameMap { get; set; }
        public Logger Logger { get; private set; }
        public int Score
        {
            get => _gameScore;
            set
            {
                _gameScore = value;
                ScoreLabel.Content = $"Score: {_gameScore} - {_gameScoreEnemy}";
                if (MultiplayerManager.Connection.State == HubConnectionState.Connected) // Update second player 
                    MultiplayerManager.Connection.SendAsync("SendScore", _gameScore).Wait();
            }
        }
        public int EnemyScore
        {
            get => _gameScoreEnemy;
            set
            {
                _gameScoreEnemy = value;
                ScoreLabel.Content = $"Score: {_gameScore} - {_gameScoreEnemy}";
            }
        }

        static GameState() { }
        private GameState()
        {
            if (!Directory.Exists(Settings.LogFolder))
                Directory.CreateDirectory(Settings.LogFolder);
            var logPath = Path.Combine(Settings.LogFolder, $"{DateTime.Now.Ticks}_log.txt");
            var logger = new StreamWriter(logPath, true);
            Logger = new DefaultLogger(logger);
            Logger.SetNext(new WarningLogger(logger))
                  .SetNext(new FileLogger(logger))
                  .SetNext(new ErrorLogger(logger))
                  .SetNext(new NetworkLogger(logger));
        }

        public static GameState Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
