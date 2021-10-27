﻿using Common.Enums;
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

namespace Snakey.Facades
{
    public class Game
    {
        private MultiplayerManager MultiplayerManager { get; set; }
        private GameState GameState { get; set; }
        private Map GameMap { get; set; }
        private MainWindow Window { get; set; }
        private Publisher Publisher;

        public void Init(MainWindow window)
        {
            InitializeGameComponents(window);
            RegisterObservers();
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
        public void HandleKeyboard(KeyEventArgs e)
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
        public async void ConnectToServer()
        {
            await MultiplayerManager.ConnectToServer();
            BindMethods();
            Window.ConnectButton.IsEnabled = false;
            GameState.SecondPlayer = new();
            GameState.SecondPlayer.HeadLocation = new(-100, -100);
        }


        private void SwitchToLevelOne()
        {
            if (GameMap is BasicMap)
                return;
            var mapFactory = new MapFactory();

            GameMap = mapFactory.CreateMap(MapTypes.Basic);
            GameState.Player.Reset();
            GameState.Snacks.Clear(); // Clear all snacks
            PlaceSnackIfNeeded(); // Replace all snacks

            if (MultiplayerManager.Connection.State == HubConnectionState.Connected)
            {
                MultiplayerManager.Connection?.SendAsync("ChangeMap", MapTypes.Basic);
                SendSnackList();
            }
        }
        private void SwitchToLevelTwo()
        {
            if (GameMap is AdvanceMap)
                return;
            var mapFactory = new MapFactory();

            GameMap = mapFactory.CreateMap(MapTypes.Advance);
            GameState.Player.Reset();
            GameState.Snacks.Clear(); // Clear all snacks
            PlaceSnackIfNeeded(); // Replace all snacks

            if (MultiplayerManager.Connection.State == HubConnectionState.Connected)
            {
                MultiplayerManager.Connection?.SendAsync("ChangeMap", MapTypes.Advance);
                SendSnackList();
            }
        }
        private void SwitchToLevelThree()
        {
            if (GameMap is ExpertMap)
                return;
            var mapFactory = new MapFactory();

            GameMap = mapFactory.CreateMap(MapTypes.Expert);
            GameState.Player.Reset();
            GameState.Snacks.Clear(); // Clear all snacks
            PlaceSnackIfNeeded(); // Replace all snacks

            if (MultiplayerManager.Connection.State == HubConnectionState.Connected)
            {
                MultiplayerManager.Connection?.SendAsync("ChangeMap", MapTypes.Expert);
                SendSnackList();
            }
        }

        private void InitializeGameComponents(MainWindow window)
        {
            Window = window;
            GameState = GameState.Instance;
            var mapFactory = new MapFactory();

            // Setup snek player
            GameState.Player = new();
            GameState.Snacks = new();
            // Setup gameloop
            GameState.GameTimer = new();
            GameState.GameTimer.Tick += GameLoop;
            GameState.GameTimer.Interval = TimeSpan.FromMilliseconds(Settings.UpdateTimer);

            GameState.GameArea = window.GameArea;
            GameState.ScoreLabel = Window.ScoreLabel;

            GameMap = mapFactory.CreateMap(MapTypes.Basic);

            MultiplayerManager = /*new("http://localhost:5000/gameHub");*/  new("http://158.129.23.210:5003/gameHub");
            GameState.MultiplayerManager = MultiplayerManager;
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
                if (MultiplayerManager.Connection.State == HubConnectionState.Connected)
                    MultiplayerManager.Connection.SendAsync("PlayerDied").Wait();
                GameState.GameTimer.Stop();
                MessageBox.Show($"Skill issue :/. Ur final score: {GameState.Score}");
                Window.Close();
            }
        }

        private void BindMethods()
        {
            MultiplayerManager.Connection.On<PlayerPackage>("RecievePositions", (package) =>
            {
                GameState.SecondPlayer.HeadLocation = package.SnakeHeadLocation;
                GameState.SecondPlayer.BodyParts = package.SnakeBodyLocation;
                GameState.SecondPlayer.CurrentMovementDirection = package.SnakeMovementDirection;
                GameState.SecondPlayer.TailLocation = package.SnakeTailLocation;
                GameState.SecondPlayer.TailLocation = package.SnakeTailLocation;
                GameState.SecondPlayer.TailLocation = package.SnakeTailLocation;
                GameState.SecondPlayer.HeadColor.Color = Color.FromRgb(package.HeadColor.R, package.HeadColor.G, package.HeadColor.B);
                GameState.SecondPlayer.BodyColor.Color = Color.FromRgb(package.BodyColor.R, package.BodyColor.G, package.BodyColor.B);
                GameState.SecondPlayer.TailColor.Color = Color.FromRgb(package.TailColor.R, package.TailColor.G, package.TailColor.B);
            });
            MultiplayerManager.Connection.On<SnackPackage>("RecieveEatenSnackPosition", (snack) =>
            {
                GameState.Snacks.RemoveAll((s) => s.Location.IsOverlaping(snack.Location));
            });
            MultiplayerManager.Connection.On<List<SnackPackage>>("RecieveSnackList", (snacks) =>
            {
                GameState.Snacks.Clear(); // Clear current snacks

                // Build Snacks
                foreach (var item in snacks)
                {
                    ISnackFactory factory = item.FoodType switch
                    {
                        FoodType.Apple => new AppleFactory(),
                        FoodType.Lemon => new LemonFactory(),
                        _ => null
                    };

                    Snack snack = item.EffectType switch
                    {
                        EffectType.Good => factory.CreateGoodSnack(),
                        EffectType.Bad => factory.CreateBadSnack(),
                        EffectType.Mystery => factory.CreateMysterySnack(),
                        _ => null
                    };

                    snack.Location = item.Location;
                    SnackAdapter snackAdapter = new(snack);
                    GameState.Snacks.Add(snackAdapter);
                }
            });
            MultiplayerManager.Connection.On("AskForSnackList", () =>
            {
                SendSnackList();
            });
            MultiplayerManager.Connection.On<SnackPackage>("AddSnack", (s) =>
            {
                ISnackFactory factory = s.FoodType switch
                {
                    FoodType.Apple => new AppleFactory(),
                    FoodType.Lemon => new LemonFactory(),
                    _ => null
                };

                Snack snack = s.EffectType switch
                {
                    EffectType.Good => factory.CreateGoodSnack(),
                    EffectType.Bad => factory.CreateBadSnack(),
                    EffectType.Mystery => factory.CreateMysterySnack(),
                    _ => null
                };

                snack.Location = s.Location;
                SnackAdapter snackAdapter = new(snack);
                GameState.Snacks.Add(snackAdapter);
            });
            MultiplayerManager.Connection.On<MapTypes>("ChangeMap", (map) =>
            {
                var mapFactory = new MapFactory();

                GameMap = mapFactory.CreateMap(map);
                GameState.Player.Reset();
                GameState.Player.HeadLocation += (0, Settings.CellSize);
            });
            MultiplayerManager.Connection.On<int>("ShortenSecondPlayer", (n) =>
            {
                if (n < 0)
                {
                    n *= -1;
                    for (int i = 0; i < n; i++)
                        GameState.Player.Shrink();
                }
                else
                {
                    for (int i = 0; i < n; i++)
                        GameState.Player.Expand();
                }
                GameState.Player.IgnoreBodyCollisionWithHead = true;
            });
            MultiplayerManager.Connection.On<int>("RecieveScore", (n) =>
            {
                GameState.EnemyScore = n;
            });
            MultiplayerManager.Connection.On("ClearScore", () =>
            {
                GameState.Score = 0;
            });
            MultiplayerManager.Connection.On("PlayerDied", () =>
            {
                GameState.GameTimer.Stop();
                MessageBox.Show("You win (⌐■_■)");
                Window.Close();
            });
        }
        private void SendPositions()
        {
            if (MultiplayerManager.Connection.State == HubConnectionState.Connected)
                MultiplayerManager.Connection.SendAsync("SendPositions", GameState.Player.MakeServerPackage()).Wait();
        }

        private void SendSnackList()
        {
            if (MultiplayerManager.Connection.State == HubConnectionState.Connected)
            {
                var snacks = GameState.Snacks.Select((snack) => snack.SnackPackage()).ToList();
                MultiplayerManager.Connection.SendAsync("SendSnackList", snacks).Wait();
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

            if (MultiplayerManager.Connection.State == HubConnectionState.Connected)
                GameState.Snacks.ForEach(snack =>
                {
                    if (snack.WasConsumed)
                    {
                        MultiplayerManager.Connection.SendAsync("SendEatenSnackPosition", snack.SnackPackage()).Wait();
                    }
                });

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
                if (GameState.Snacks.Count >= Settings.MaximumSnackCount)
                    return;
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
                SnackAdapter snackAdapter = new(snack);
                GameState.Snacks.Add(snackAdapter);

                if (MultiplayerManager.Connection.State == HubConnectionState.Connected)
                    MultiplayerManager.Connection?.SendAsync("AddNewSnack", snack.SnackPackage()).Wait();
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
            if (MultiplayerManager.Connection.State == HubConnectionState.Connected)
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
            foreach (var (location, _) in GameMap.Obsticles)
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

            GameState.GameArea.Children.Add(r);
            Canvas.SetLeft(r, location.X + 4);
            Canvas.SetTop(r, location.Y + 4);

        }

    }
}