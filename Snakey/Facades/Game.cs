using Common.Enums;
using Common.Utility;
using Snakey.Adapter;
using Snakey.Config;
using Snakey.Factories;
using Snakey.Managers;
using Snakey.Maps;
using Snakey.Models;
using Snakey.Observer;
using Snakey.Strategies;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snakey.Facades
{
    public class Game
    {
        private GameState GameState;
        private MainWindow Window;
        private Publisher Publisher;
        private ServerFacade Server;

        public void Init(MainWindow window)
        {
            InitializeGameComponents(window);
            RegisterObservers();
            Server.Setup(window);
        }

        public void Run()
        {
            GameState.GameTimer.Start();
        }
        public void SwitchToLevel(MapTypes mapType)
        {
            switch (mapType)
            {
                case MapTypes.Basic:
                    SwitchToLevelOne();
                    break;
                case MapTypes.Advance:
                    SwitchToLevelTwo();
                    break;
                case MapTypes.Expert:
                    SwitchToLevelThree();
                    break;
            }
        }
        public void HandleKeyboard(Key e)
        {
            if (GameState.Player.IsMovementLocked)
                return;
            MovementContext context = new MovementContext();
            switch (e)
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
        public void ConnectToServer()
        {
            Server.ConnectToServer();
            Window.ConnectButton.IsEnabled = false;
            GameState.SecondPlayer = new();
            GameState.SecondPlayer.HeadLocation = new(-100, -100);
        }


        private void SwitchToLevelOne()
        {
            if (GameState.GameMap is BasicMap)
                return;
            var mapFactory = new MapFactory();

            GameState.GameMap = mapFactory.CreateMap(MapTypes.Basic);
            GameState.Player.Reset();
            GameState.Snacks.Clear(); // Clear all snacks
            PlaceSnackIfNeeded(); // Replace all snacks
            Server.ChangeMap(MapTypes.Basic);

        }
        private void SwitchToLevelTwo()
        {
            if (GameState.GameMap is AdvanceMap)
                return;
            var mapFactory = new MapFactory();

            GameState.GameMap = mapFactory.CreateMap(MapTypes.Advance);
            GameState.Player.Reset();
            GameState.Snacks.Clear(); // Clear all snacks
            PlaceSnackIfNeeded(); // Replace all snacks

            Server.ChangeMap(MapTypes.Advance);
        }
        private void SwitchToLevelThree()
        {
            if (GameState.GameMap is ExpertMap)
                return;
            var mapFactory = new MapFactory();

            GameState.GameMap = mapFactory.CreateMap(MapTypes.Expert);
            GameState.Player.Reset();
            GameState.Snacks.Clear(); // Clear all snacks
            PlaceSnackIfNeeded(); // Replace all snacks

            Server.ChangeMap(MapTypes.Expert);
        }

        private void InitializeGameComponents(MainWindow window)
        {
            Window = window;
            GameState = GameState.Instance;
            var mapFactory = new MapFactory();

            Server = new();
            // Setup snek player
            GameState.Player = new();
            GameState.Snacks = new();
            // Setup gameloop
            GameState.GameTimer = new();
            GameState.GameTimer.Tick += GameLoop;
            GameState.GameTimer.Interval = TimeSpan.FromMilliseconds(Settings.UpdateTimer);

            GameState.GameArea = window.GameArea;
            GameState.ScoreLabel = Window.ScoreLabel;

            GameState.GameMap = mapFactory.CreateMap(MapTypes.Basic);
        }

        private void RegisterObservers()
        {
            Publisher = new();
            SnackObserver snackObserver = new();
            AudioPlayer audioOBserver = new();

            Publisher.RegisterObserver(snackObserver);
            Publisher.RegisterObserver(audioOBserver);
        }

        private void GameLoop(object sender, EventArgs e)
        {
            // Update with the server 
            Server.SendPlayerPositions();

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

            GameState.GameMap.MapCollisionCheck();

            var player = GameState.Player;
            var secondPlayer = GameState.SecondPlayer;

            if (!player.IgnoreBodyCollisionWithHead)
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
            if (secondPlayer != null)
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
                Server.SendMessage("PlayerDied");
                GameState.GameTimer.Stop();
                MessageBox.Show($"Skill issue :/. Ur final score: {GameState.Score}");
                Window.Close();
            }
        }

        private void CheckSnackCollision()
        {
            foreach (var snack in GameState.Snacks)
            {
                if (snack.Location.IsOverlaping(GameState.Player.HeadLocation))
                {
                    Publisher.NotifyObservers(snack);
                }
            }

            Server.SendEatenSnacks(GameState.Snacks);
            GameState.Snacks.RemoveAll(x => x.WasConsumed);
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
        private void PlaceSnackIfNeeded()
        {
            if (GameState.Snacks.Count >= Settings.MaximumSnackCount)
                return;

            Random rnd = new();

            for (int i = 0; i < 100; i++) // 100 tries to place a snack randomly
            {
                if (GameState.Snacks.Count >= Settings.MaximumSnackCount)
                    return;

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

                int rndX = rnd.Next(0, (int)Window.GameArea.ActualWidth / Settings.CellSize) * Settings.CellSize;
                int rndY = rnd.Next(0, (int)Window.GameArea.ActualHeight / Settings.CellSize) * Settings.CellSize;

                var snackLocation = new Vector2D(rndX, rndY);

                if (IsNewSnackColliding(snackLocation))
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
                ISnackTarget snackAdapter = new SnackAdapter(snack);
                GameState.Snacks.Add(snackAdapter);

                Server.SendSnackPosition(snack);

            }
        }
        private bool IsNewSnackColliding(Vector2D newSnack)
        {
            // Dont't place on player 1
            if (GameState.Player.HeadLocation.IsOverlaping(newSnack))
                return true; // Try again
            foreach (var bodySegment in GameState.Player.BodyParts)
            {
                if (bodySegment.IsOverlaping(newSnack))
                    return true;
            }
            // Check if overlaps player 2
            if (Server.IsConnected())
            {
                if (GameState.SecondPlayer.HeadLocation.IsOverlaping(newSnack))
                    return true;

                foreach (var bodySegment in GameState.SecondPlayer.BodyParts)
                {
                    if (bodySegment.IsOverlaping(newSnack))
                        return true;
                }
            }
            // Check if overlaps map obstacles
            foreach (var (location, _) in GameState.GameMap.Obsticles)
            {
                if (newSnack.IsOverlaping(location))
                    return true;
            }
            // Check if overlaps other snacks
            foreach (var snacks in GameState.Snacks)
            {
                if (snacks.Location.IsOverlaping(newSnack))
                    return true;
            }

            return false;
        }
        public void DrawSnake(Snake player)
        {
            if (player is null)
                return;

            DrawSquare(player.HeadLocation, player.HeadColor);


            foreach (var partLocation in player.BodyParts)
            {
                DrawSquare(partLocation, player.BodyColor);
            }
            DrawSquare(player.TailLocation, player.TailColor);

            // Draw text as the last layer
            if (!string.IsNullOrEmpty(player.SnakeText.Content as string))
            {
                GameState.GameArea.Children.Add(player.SnakeText);
                Canvas.SetLeft(player.SnakeText, player.HeadLocation.X);
                Canvas.SetTop(player.SnakeText, player.HeadLocation.Y - Settings.CellSize);
            }
        }
        public void ClearScreen()
        {
            GameState.GameArea.Children.Clear();
        }
        private void DrawGameGrid()
        {
            foreach (var line in GameState.GameMap.GridLines)
            {
                GameState.GameArea.Children.Add(line);
            }

            foreach (var (location, body) in GameState.GameMap.Obsticles)
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

            GameState.GameArea.Children.Add(r);
            Canvas.SetLeft(r, location.X + 4);
            Canvas.SetTop(r, location.Y + 4);

        }
    }
}
