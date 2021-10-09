using Snakey.Maps;
using Snakey.Models;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Snakey.Managers
{
    public sealed class GameState
    {
        private static readonly GameState _instance = new();
        private int _gameScore = 0;

        public Snake Player { get; set; }
        public Snake SecondPlayer { get; set; }
        public List<Snack> Snacks { get; set; }
        public DispatcherTimer GameTimer { get; set; }
        public Canvas GameArea { get; set; }
        public Label ScoreLabel { get; set; }
        public Map GameMap { get; set; }
        public int Score
        {
            get => _gameScore;
            set
            {
                _gameScore = value;
                ScoreLabel.Content = $"Score: {_gameScore}";
            }
        }


        static GameState() { }
        private GameState() { }

        public static GameState Instance
        {
            get
            {
                return _instance;
            }
        }
    }
}
