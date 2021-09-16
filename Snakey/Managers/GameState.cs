using Common.Models;
using Snakey.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Snakey.Managers
{
    public class GameState
    {
        private static GameState _instance = null;

        public Snake Player { get; set; }
        public List<Snack> Snacks { get; set; }
        public DispatcherTimer GameTimer { get; set; }
        public Canvas GameArea { get; set; }
        public Map GameMap { get; set; }

        private GameState() { }

        public static GameState GetInstance()
        {
            if (_instance is null)
                _instance = new GameState();

            return _instance;
        }
    }
}
