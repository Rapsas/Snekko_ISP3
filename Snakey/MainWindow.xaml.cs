using Common.Enums;
using Common.Utility;
using Microsoft.AspNetCore.SignalR.Client;
using Snakey.Adapter;
using Snakey.Config;
using Snakey.Facades;
using Snakey.Factories;
using Snakey.Managers;
using Snakey.Maps;
using Snakey.Models;
using Snakey.Observer;
using Snakey.Strategies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

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
            _game.Init(this);
            _game.Run();
        }


        private void Sign_to_server(object sender, RoutedEventArgs e)
        {
            _game.ConnectToServer();
        }
        private void Keyboard_pressed(object sender, KeyEventArgs e)
        {
            _game.HandleKeyboard(e);
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
    }
}
