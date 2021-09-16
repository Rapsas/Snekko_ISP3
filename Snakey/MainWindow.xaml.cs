using Microsoft.AspNet.SignalR.Client;
using Snakey.Config;
using Snakey.Managers;
using Snakey.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Snakey
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            InitializeGameComponents();
        }
        public void InitializeGameComponents()
        {
            var gameState = GameState.GetInstance();
            // Setup snek player
            gameState.Player = new();
            gameState.Snacks = new();
            gameState.GameMap = new BasicMap();
            // Setup gameloop
            gameState.GameTimer = new();
            gameState.GameTimer.Tick += GameLoop; ;
            gameState.GameTimer.Interval = TimeSpan.FromMilliseconds(Settings.UpdateTimer);
            gameState.GameTimer.Start();

            gameState.GameArea = GameArea;
        }

        private void GameLoop(object sender, EventArgs e)
        {
            // Gaming
            ClearScreen();
            DrawGameGrid();
        }

        public void ClearScreen()
        {
            var gameState = GameState.GetInstance();
            gameState.GameArea.Children.Clear();
        }
        private void DrawGameGrid()
        {
            var gameState = GameState.GetInstance();
            if (gameState.GameMap.GridLines.Count == 0)
                InitializeGrid();

            foreach (var line in gameState.GameMap.GridLines)
            {
                gameState.GameArea.Children.Add(line);
            }
        }

        private void InitializeGrid()
        {
            var gameState = GameState.GetInstance();
            // Draw horizontal lines
            for (int row = 0; row < gameState.GameArea.ActualHeight; row += Settings.CellSize)
            {
                Line line = new()
                {
                    X1 = 0,
                    Y1 = row,
                    X2 = GameArea.ActualWidth,
                    Y2 = row,
                    StrokeThickness = 1,
                    Stroke = Brushes.Black
                };
                gameState.GameMap.GridLines.Add(line);
            }
            // Draw vertical lines
            for (int column = 0; column < gameState.GameArea.ActualWidth; column += Settings.CellSize)
            {
                Line line2 = new()
                {
                    X1 = column,
                    Y1 = 0,
                    X2 = column,
                    Y2 = GameArea.ActualHeight,
                    StrokeThickness = 1,
                    Stroke = Brushes.Black
                };
                gameState.GameMap.GridLines.Add(line2);
            }
        }
    }
}
