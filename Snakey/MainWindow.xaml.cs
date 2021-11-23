using Common.Enums;
using Snakey.Config;
using Snakey.Facades;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Snakey
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game _game = new();

        public MainWindow()
        {
            InitializeComponent();
            GameArea.Width = Settings.WindowWidth;
            GameArea.Height = Settings.WindowHeight;
            _game.Init(this);
            _game.Run();

        }


        private void Sign_to_server(object sender, RoutedEventArgs e)
        {
            _game.ConnectToServer();
        }
        private void Keyboard_pressed(object sender, KeyEventArgs e)
        {
            _game.HandleKeyboard(e.Key);
        }

        private void Switch_to_level_1(object sender, EventArgs e)
        {
            _game.SwitchToLevel(MapTypes.Basic);
        }
        private void Switch_to_level_2(object sender, EventArgs e)
        {
            _game.SwitchToLevel(MapTypes.Advance);
        }
        private void Switch_to_level_3(object sender, EventArgs e)
        {
            _game.SwitchToLevel(MapTypes.Expert);
        }

        public Label GetScoreLabel => ScoreLabel;
        public Canvas GetGameArea => GameArea;
    }
}
