using Common.Enums;
using Common.Utility;
using Microsoft.AspNetCore.SignalR.Client;
using Snakey.Config;
using Snakey.Factories;
using Snakey.Managers;
using Snakey.Maps;
using Snakey.Models;
using Snakey.Strategies;
using System;
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
        public Map GameMap { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            InitializeGameComponents();
        }
        public void InitializeGameComponents()
        {
            GameState = GameState.Instance;
            var mapFactory = new MapFactory();

            // Setup snek player
            GameState.Player = new();
            GameState.Snacks = new();
            // Setup gameloop
            GameState.GameTimer = new();
            GameState.GameTimer.Tick += GameLoop; ;
            GameState.GameTimer.Interval = TimeSpan.FromMilliseconds(Settings.UpdateTimer);
            GameState.GameTimer.Start();

            GameState.GameArea = GameArea;
            GameState.ScoreLabel = ScoreLabel; 

            GameMap = mapFactory.CreateMap(MapTypes.Basic);

            MultiplayerManager = new("http://localhost:5000/gameHub");
        }

        private void GameLoop(object sender, EventArgs e)
        {
            // Update with the server 
            SendPositions();

            // Gaming
            ClearScreen();
            DrawGameGrid();
            CheckPlayerCollision();
            CheckSnackCollision();
            DrawSnacks();
            DrawSnake(GameState.Player);
            DrawSnake(GameState.SecondPlayer);
            GameState.Player.Move();
        }

        private void CheckPlayerCollision()
        {
            // This whole collision checking could probably be handeled much nicer
            // but i can't be fucked to do anything about it :^)
            // plz someone make it nice <3

            GameMap.MapCollisionCheck();
            
            var player = GameState.Player;
            var secondPlayer = GameState.SecondPlayer;

            foreach (var bodyPart in player.BodyParts)
            {
                if (player.HeadLocation.IsOverlaping(bodyPart))
                {
                    player.IsDead = true;
                    break;
                }
            }
            if (player.HeadLocation.IsOverlaping(player.TailLocation))
            {
                player.IsDead = true;
            }

            // Check if the retard hit another player
            if(secondPlayer != null)
            {
                foreach (var bodyPart in secondPlayer.BodyParts)
                {
                    if (player.HeadLocation.IsOverlaping(bodyPart))
                    {
                        player.IsDead = true;
                        break;
                    }
                }

                if (player.HeadLocation.IsOverlaping(secondPlayer.TailLocation))
                {
                    player.IsDead = true;
                }

                if (player.HeadLocation.IsOverlaping(secondPlayer.HeadLocation))
                {
                    player.IsDead = true;
                }
            }




            if (GameState.Player.IsDead)
            {
                MessageBox.Show($"Skill issue :/. Ur final score: {GameState.Score}");
                Close();
            }
        }

        public void BindMethods()
        {
            MultiplayerManager.Connection.On<PlayerPackage>("RecievePositions", (package) =>
              {
                 GameState.SecondPlayer.HeadLocation = package.SnakeHeadLocation;
                 GameState.SecondPlayer.BodyParts = package.SnakeBodyLocation;
                 GameState.SecondPlayer.CurrentMovementDirection = package.SnakeMovementDirection;
                 GameState.SecondPlayer.TailLocation = package.SnakeTailLocation;
              });

            MultiplayerManager.Connection.On<string>("RecieveSnackPositions", (snacks) =>
            {
                // XD
                //GameState.Snacks = snacks;
            });
        }
        public void SendSnackPositions()
        {
            if (MultiplayerManager.Connection.State == HubConnectionState.Connected)
            {
                MultiplayerManager.Connection.SendAsync("SendSnackPositions", GameState.Snacks[0]).Wait();
            }
        }
        public void SendPositions()
        {
            if (MultiplayerManager.Connection.State == HubConnectionState.Connected)
                MultiplayerManager.Connection.SendAsync("SendPositions", GameState.Player.MakeServerPackage()).Wait();
        }

        private void CheckSnackCollision()
        {
            bool ateSnack = false;
            foreach (var snack in GameState.Snacks)
            {
                if (snack.Location.IsOverlaping(GameState.Player.HeadLocation))
                {
                    snack.TriggerEffect();
                    snack.WasConsumed = true;
                    tmpCounter--;
                    ateSnack = true;
                }
            }
            GameState.Snacks.RemoveAll(x => x.WasConsumed /*&& x.EffectTimer <= 0*/);
            if (ateSnack)
                SendSnackPositions();
        }
        private void DrawSnacks()
        {
            PlaceSnackIfNeeded();
            foreach (var item in GameState.Snacks)
            {
                if (item.WasConsumed) // Was already eaten
                    continue;
                item.Draw();
            }
        }
        int tmpCounter = 0;
        private void PlaceSnackIfNeeded()
        {
            if (tmpCounter >= Settings.MaximumSnackCount)
                return;

            Random rnd = new();

            int factoryDecider = rnd.Next(2);
            ISnackFactory factory;
            if (factoryDecider > 0)
            {
                factory = new AppleFactory();
            }
            else
            {
                factory = new LemonFactory();
            }

            for (int i = 0; i < 100; i++) // 100 tries to place a snack randomly
            {
                if (tmpCounter >= Settings.MaximumSnackCount)
                    return;
                int rndX = rnd.Next(0, (int)GameArea.ActualWidth / Settings.CellSize) * Settings.CellSize;
                int rndY = rnd.Next(0, (int)GameArea.ActualHeight / Settings.CellSize) * Settings.CellSize;

                var snackLocation = new Vector2D(rndX, rndY);

                if (GameState.Player.HeadLocation.IsOverlaping(snackLocation))
                    continue; // Try again

                bool overlapped = false;
                foreach (var bodySegment in GameState.Player.BodyParts)
                {
                    if (bodySegment.IsOverlaping(snackLocation))
                    {
                        overlapped = true;
                        break;
                    }
                }

                if (overlapped)
                    continue; // Try again

                foreach (var (location, _) in GameMap.Obsticles)
                {
                    if (snackLocation.IsOverlaping(location))
                    {
                        overlapped = true;
                        break;
                    }
                }

                if (overlapped)
                    continue; // Try again

               

                Snack snack;
                int c = rnd.Next(0, 11);
                if (c <= 3)
                    snack = factory.CreateGoodSnack();
                else if (c > 3 && c <= 7)
                {
                    snack = factory.CreateBadSnack();
                }
                else
                    snack = factory.CreateMysterySnack();

                snack.Location = snackLocation;
                GameState.Snacks.Add(snack);
                tmpCounter++;
            }
        }

        public void DrawSnake(Snake player)
        {
            if (player is null)
                return;
            DrawSquare(player.HeadLocation, Brushes.Green);
            foreach (var partLocation in player.BodyParts)
            {
                DrawSquare(partLocation, Brushes.GreenYellow);
            }
            DrawSquare(player.TailLocation, Brushes.Blue);
        }
        public void ClearScreen()
        {
            GameState.GameArea.Children.Clear();
        }
        private void DrawGameGrid()
        {
            foreach (var line in GameMap.GridLines)
            {
                GameState.GameArea.Children.Add(line);
            }

            foreach (var (location, body) in GameMap.Obsticles)
            {
                GameState.GameArea.Children.Add(body);
                Canvas.SetLeft(body, location.X);
                Canvas.SetTop(body, location.Y);
            }

        }
        private void DrawSquare(Vector2D location, Brush color)
        {
            // Since only snake uses this we could store it 
            // and avoid unnecessery object creations
            Rectangle r = new()
            {
                Fill = color,
                Width = Settings.CellSize - 8,
                Height = Settings.CellSize - 8
            };

            GameState.Instance.GameArea.Children.Add(r);
            Canvas.SetLeft(r, location.X + 4);
            Canvas.SetTop(r, location.Y + 4);

        }

        private async void Sign_to_server(object sender, RoutedEventArgs e)
        {
            await MultiplayerManager.ConnectToServer();
            BindMethods();
            ConnectButton.IsEnabled = false;
            GameState.SecondPlayer = new();
            GameState.SecondPlayer.HeadLocation = new(-100, -100);
        }
        private void Keyboard_pressed(object sender, KeyEventArgs e)
        {
            if (GameState.Player.IsMovementLocked)
                return;
            MovementContext context = new MovementContext();
            switch (e.Key)
            {
                case Key.A:
                    context.SetStrategy(new MovementLeftStrategy());
                    break;
                case Key.W:
                    context.SetStrategy(new MovementUpStrategy());
                    break;
                case Key.S:
                    context.SetStrategy(new MovementDownStrategy());
                    break;
                case Key.D:
                    context.SetStrategy(new MovementRightStrategy());
                    break;
                default:
                    break;
            }
            context.ExecuteStrategy(GameState.Player);
            GameState.Player.IsMovementLocked = true;
        }

        private void Switch_to_level_1(object sender, EventArgs e)
        {
            if (GameMap is BasicMap)
                return;
            var mapFactory = new MapFactory();

            GameMap = mapFactory.CreateMap(MapTypes.Basic);
            GameState.Player.Reset();
        }
        private void Switch_to_level_2(object sender, EventArgs e)
        {
            if (GameMap is AdvanceMap)
                return;
            var mapFactory = new MapFactory();

            GameMap = mapFactory.CreateMap(MapTypes.Advance);
            GameState.Player.Reset();
        }
        private void Switch_to_level_3(object sender, EventArgs e)
        {
            if (GameMap is ExpertMap)
                return;
            var mapFactory = new MapFactory();

            GameMap = mapFactory.CreateMap(MapTypes.Expert);
            GameState.Player.Reset();
        }
    }
}
