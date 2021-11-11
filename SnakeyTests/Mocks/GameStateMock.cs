﻿using Microsoft.AspNetCore.SignalR.Client;
using Snakey.Adapter;
using Snakey.Managers;
using Snakey.Models;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Threading;

namespace SnakeyTests.Mocks
{
    class GameStateMock
    {
        private int _gameScore = 0;
        private int _gameScoreEnemy = 0;

        public Snake Player { get; set; }
        public Snake SecondPlayer { get; set; }
        public List<ISnackTarget> Snacks { get; set; }
        public DispatcherTimer GameTimer { get; set; }
        public Canvas GameArea { get; set; }
        public Label ScoreLabel { get; set; }
        public MultiplayerManager MultiplayerManager { get; set; }
        public Map GameMap { get; set; }
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

        public GameStateMock() { }
    }
}