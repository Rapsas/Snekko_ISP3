using Common.Enums;
using Common.Models;
using Common.Utility;
using Microsoft.AspNetCore.SignalR.Client;
using Snakey.Config;
using Snakey.Managers;
using Snakey.Maps;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public MultiplayerManager MultiplayerManager { get; set; }
        public GameState GameState { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            InitializeGameComponents();
        }
        public void InitializeGameComponents()
        {
            GameState = GameState.Instance;

            // Setup snek player
            GameState.Player = new();
            GameState.Snacks = new();
            GameState.GameMap = new BasicMap();
            // Setup gameloop
            GameState.GameTimer = new();
            GameState.GameTimer.Tick += GameLoop; ;
            GameState.GameTimer.Interval = TimeSpan.FromMilliseconds(Settings.UpdateTimer);
            GameState.GameTimer.Start();

            GameState.GameArea = GameArea;

            MultiplayerManager = new("http://localhost:5000/gameHub");
        }

        private void GameLoop(object sender, EventArgs e)
        {
            // Update with the server 
            SendPositions();

            // Gaming
            ClearScreen();
            DrawGameGrid();
            DrawSnake();
            GameState.Player.Move();
        }

        public void BindMethods()
        {
            MultiplayerManager.Connection.On<Package>("RecievePositions", (package) =>
              {
                 // we could just have 2 player classes in gamestate and just update acordingly
                 GameState.Player.HeadLocation = package.SnakeHeadLocation;
                 GameState.Player.BodyParts = package.SnakeBodyLocation;
                 GameState.Player.CurrentMovementDirection = package.SnakeMovementDirection;
              });

            MultiplayerManager.Connection.On<List<Snack>>("RecieveSnackPositions", (snacks) =>
            {
                GameState.Snacks = snacks;
            });
        }
        public void UpdateSnackPositions()
        {
            if (MultiplayerManager.Connection.State == HubConnectionState.Connected)
                MultiplayerManager.Connection.SendAsync("SendSnackPositions", GameState.Snacks).Wait();

        }
        public void SendPositions()
        {
            if (MultiplayerManager.Connection.State == HubConnectionState.Connected)
                MultiplayerManager.Connection.SendAsync("SendPositions", GameState.Player.MakeServerPackage()).Wait();
        }
        public void DrawSnake()
        {
            var gameState = GameState.Instance;

            var player = gameState.Player;
            DrawSquare(player.HeadLocation);
            foreach (var partLocation in player.BodyParts)
            {
                DrawSquare(partLocation);
            }
        }
        public void ClearScreen()
        {
            var gameState = GameState.Instance;
            gameState.GameArea.Children.Clear();
        }
        private void DrawGameGrid()
        {
            var gameState = GameState.Instance;
            if (gameState.GameMap.GridLines.Count == 0)
                InitializeGrid();

            foreach (var line in gameState.GameMap.GridLines)
            {
                gameState.GameArea.Children.Add(line);
            }
        }
        private void InitializeGrid()
        {
            var gameState = GameState.Instance;
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
        private void DrawSquare(Vector2D location)
        {
            Rectangle r = new()
            {
                Fill = Brushes.Black,
                Width = Settings.CellSize,
                Height = Settings.CellSize
            };

            GameState.Instance.GameArea.Children.Add(r);
            Canvas.SetLeft(r, location.X);
            Canvas.SetTop(r, location.Y);

        }

        private async void Sign_to_server(object sender, RoutedEventArgs e)
        {
            await MultiplayerManager.ConnectToServer();
            BindMethods();
            ConnectButton.IsEnabled = false;
        }

        private void Keyboard_pressed(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.A:
                    // Dont let snake go into itself
                    if (GameState.Player.CurrentMovementDirection != MovementDirection.Right || GameState.Player.BodyParts.Count == 0)
                        GameState.Player.CurrentMovementDirection = MovementDirection.Left;
                    break;
                case Key.W:
                    if (GameState.Player.CurrentMovementDirection != MovementDirection.Down || GameState.Player.BodyParts.Count == 0)
                        GameState.Player.CurrentMovementDirection = MovementDirection.Up;
                    break;
                case Key.S:
                    if (GameState.Player.CurrentMovementDirection != MovementDirection.Up || GameState.Player.BodyParts.Count == 0)
                        GameState.Player.CurrentMovementDirection = MovementDirection.Down;
                    break;
                case Key.D:
                    if (GameState.Player.CurrentMovementDirection != MovementDirection.Left || GameState.Player.BodyParts.Count == 0)
                        GameState.Player.CurrentMovementDirection = MovementDirection.Right;
                    break;
                default:
                    break;
            }
        }
    }
}
