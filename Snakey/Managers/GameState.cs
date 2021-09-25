using Snakey.Maps;
using Snakey.Models;
using Snakey.Snacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Threading;

namespace Snakey.Managers
{
    public sealed class GameState
    {
        private static readonly GameState _instance = new();

        public Snake Player { get; set; }
        public List<Snack> Snacks { get; set; }
        public DispatcherTimer GameTimer { get; set; }
        public Canvas GameArea { get; set; }
        public Map GameMap { get; set; }

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
