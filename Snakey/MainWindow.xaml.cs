using Common.Utility;
using Microsoft.AspNetCore.SignalR.Client;
using Snakey.Config;
using Snakey.Managers;
using Snakey.Maps;
using System;
using System.Windows;
using System.Windows.Controls;
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
            GameState = GameState.GetInstance();
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
            MultiplayerManager.ConnectToServer();

            BindMethods();
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
                  // Don't update urself
                  if (package.SendersID != MultiplayerManager.Connection.ConnectionId)
                  {
                      Title = package.SendersID;
                      // TODO: when in multiplayer use hashmap based on connection ID
                      // or smt to quickly set shit

                      // or OR we could just have 2 player classes in gamestate and just update
                      // acordingly
                      GameState.Player.HeadLocation = package.SnakeHeadLocation;
                      GameState.Player.BodyParts = package.BodyLocation;
                  }

              });
        }
        public void SendPositions()
        {
            MultiplayerManager.Connection.SendAsync("SendPositions", GameState.Player.MakeServerPackage()).Wait();
        }
        public void DrawSnake()
        {
            var gameState = GameState.GetInstance();

            var player = gameState.Player;
            DrawSquare(player.HeadLocation);
            foreach (var partLocation in player.BodyParts)
            {
                DrawSquare(partLocation);
            }
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
        private void DrawSquare(Vector2D location)
        {
            Rectangle r = new()
            {
                Fill = Brushes.Black,
                Width = Settings.CellSize,
                Height = Settings.CellSize
            };

            GameState.GetInstance().GameArea.Children.Add(r);
            Canvas.SetLeft(r, location.X);
            Canvas.SetTop(r, location.Y);

        }

    }
}
