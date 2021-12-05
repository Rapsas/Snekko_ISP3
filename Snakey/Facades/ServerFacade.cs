using Common.Enums;
using Common.Utility;
using Microsoft.AspNetCore.SignalR.Client;
using Snakey.Composite;
using Snakey.Config;
using Snakey.Factories;
using Snakey.Managers;
using Snakey.Models;
using Snakey.Proxy;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Media;

namespace Snakey.Facades
{
    [SuppressMessage("NDepend", "ND1400:AvoidNamespacesMutuallyDependent", Justification = "...")]
    public class ServerFacade
    {
        public MultiplayerManager MultiplayerManager { get; set; }
        private GameState GameState;
        private ComponentDrawer ComponentDrawer;
        [SuppressMessage("NDepend", "ND1400:AvoidNamespacesMutuallyDependent", Justification = "...")]
        public MainWindow Window;

        public void Setup(MainWindow window, ComponentDrawer componentDrawer, ConnectionManager connectionManager)
        {
            // MultiplayerManager = new("http://localhost:5000/gameHub"); // new("http://158.129.23.210:5003/gameHub");
            MultiplayerManager = connectionManager.MultiplayerManager;
            // GameState.Instance.MultiplayerManager = MultiplayerManager;

            GameState = GameState.Instance;
            Window = window;
            ComponentDrawer = componentDrawer;
        }

        public void SendPlayerPositions()
        {
            if (MultiplayerManager.Connection.State == HubConnectionState.Connected)
                MultiplayerManager.Connection.SendAsync("SendPositions", GameState.Player.MakeServerPackage()).Wait();
        }
        public void SendMessage(string methodName)
        {
            if (MultiplayerManager.Connection.State == HubConnectionState.Connected)
                MultiplayerManager.Connection.SendAsync(methodName).Wait();
        }

        public void BindMethods()
        {
            //yeah this works
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
            RecieveEatenSnackPosition();
            
            MultiplayerManager.Connection.On<List<SnackPackage>>("RecieveSnackList", (snacks) =>
            {
                GameState.Snacks.ForEach(x => ComponentDrawer.Remove(x));
                GameState.Snacks.Clear(); // Clear current snacks
                // Build Snacks
                foreach (var item in snacks)
                {
                    ISnackFactory factory = item.FoodType switch//yeah this works
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
                    GameState.Snacks.Add(snack);//yeah this works
                    ComponentDrawer.Add(snack);
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
                };//yeah this works

                Snack snack = s.EffectType switch
                {
                    EffectType.Good => factory.CreateGoodSnack(),
                    EffectType.Bad => factory.CreateBadSnack(),
                    EffectType.Mystery => factory.CreateMysterySnack(),
                    _ => null
                };
                //yeah this works
                snack.Location = s.Location;
                GameState.Snacks.Add(snack);
                ComponentDrawer.Add(snack);
            });
            MultiplayerManager.Connection.On<MapTypes>("ChangeMap", (map) =>
            {//yeah this works
                var mapFactory = new MapFactory();

                ComponentDrawer.Remove(GameState.GameMap);
                GameState.GameMap = mapFactory.CreateMap(map);//yeah this works
                ComponentDrawer.Add(GameState.GameMap);

                GameState.Player.Reset();
                GameState.Player.HeadLocation += (0, Settings.CellSize);
            });

            shortenSecondPLayer();
            doSomeOtherstuffIDK();
            
        }
        private void doSomeOtherstuffIDK()
        {
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
                MessageBox.Show("You win (⌐■_■)");//yeah this works
                Window.Close();
            });
        }
        private void RecieveEatenSnackPosition()
        {
            MultiplayerManager.Connection.On<SnackPackage>("RecieveEatenSnackPosition", (snack) =>
            {
                GameState.Snacks.RemoveAll((s) =>
                {
                    if (s.Location.IsOverlaping(snack.Location))//yeah this works
                    {
                        ComponentDrawer.Remove(s);
                        return true;
                    }
                    return false;
                });
            });
        }
        private void shortenSecondPLayer()
        {
            MultiplayerManager.Connection.On<int>("ShortenSecondPlayer", (n) =>
            {
                if (n < 0)
                {
                    n *= -1;//yeah this works
                    for (int i = 0; i < n; i++)
                        GameState.Player.Shrink();
                }
                else
                {
                    for (int i = 0; i < n; i++)
                        GameState.Player.Expand();
                }
                GameState.Player.IgnoreBodyCollisionWithHead = true;
            });//yeah this works
        }

        public void ChangeMap(MapTypes mapType)
        {
            if (MultiplayerManager.Connection.State == HubConnectionState.Connected)
            {
                MultiplayerManager.Connection?.SendAsync("ChangeMap", mapType);
                SendSnackList();
            }
        }

        private void SendSnackList()
        {
            if (MultiplayerManager.Connection.State == HubConnectionState.Connected)
            {
                var snacks = GameState.Snacks.Select((snack) => snack.SnackPackage()).ToList();
                MultiplayerManager.Connection.SendAsync("SendSnackList", snacks).Wait();
            }
        }

        public void SendEatenSnacks(List<Snack> Snacks)
        {
            if (MultiplayerManager.Connection.State == HubConnectionState.Connected)
                Snacks.ForEach(snack =>
                {
                    if (snack.WasConsumed)
                    {
                        MultiplayerManager.Connection.SendAsync("SendEatenSnackPosition", snack.SnackPackage()).Wait();
                    }
                });
        }

        public void SendSnackPosition(Snack snack)
        {
            if (MultiplayerManager.Connection.State == HubConnectionState.Connected)
                MultiplayerManager.Connection?.SendAsync("AddNewSnack", snack.SnackPackage()).Wait();
        }
    }
}
