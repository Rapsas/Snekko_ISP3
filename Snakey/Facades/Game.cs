﻿namespace Snakey.Facades;

using Common.Enums;
using Common.Utility;
using Snakey.Chain_of_Responsibility;
using Snakey.Composite;
using Snakey.Config;
using Snakey.Factories;
using Snakey.Interpreter;
using Snakey.Iterator;
using Snakey.Managers;
using Snakey.Maps;
using Snakey.Mediator;
using Snakey.Models;
using Snakey.Observer;
using Snakey.Proxy;
using Snakey.Strategies;
using Snakey.Template_method;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;
using System.Windows.Shapes;

public class Game
{
    public GameState GameState { get; private set; }
    public MainWindow Window { get; private set; }
    public Publisher Publisher { get; private set; }
    public ServerFacade Server { get; private set; }
    public ComponentDrawer ComponentDrawer { get; private set; }
    public CollisionChecker CollisionChecker { get; private set; }

    private ComponentDrawer PlayerDrawer { get; set; }
    public IConnectionManager ConnectionManagerProxy { get; set; }

    public void Init(MainWindow window)
    {
        InitializeGameComponents(window);
        RegisterObservers();
        ConnectionManager connectionManager = new();
        ConnectionManagerProxy = new ConnectionManagerProxy(connectionManager, window);
        Server.Setup(window, ComponentDrawer, connectionManager);
    }

    public void Run()
    {
        GameState.Logger.Log(MessageType.Default, "Gameloop started!");
        GameState.GameTimer.Start();
    }
    public void SwitchToLevel(MapTypes mapType)
    {
        switch (mapType)
        {
            case MapTypes.Basic:
                GameState.Logger.Log(MessageType.Default, "Switching map to basic");
                SwitchToLevelOne();
                break;
            case MapTypes.Advance:
                GameState.Logger.Log(MessageType.Default, "Switching map to advanced");
                SwitchToLevelTwo();
                break;
            case MapTypes.Expert:
                GameState.Logger.Log(MessageType.Default, "Switching map to expert");
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
        ConnectionManagerProxy.ConnectToServer();
        Server.BindMethods();
        Window.ConnectButton.IsEnabled = false;
        GameState.SecondPlayer = new();
        GameState.SecondPlayer.HeadLocation = new(-100, -100);
        PlayerDrawer.Add(GameState.SecondPlayer);
        CollisionChecker = new MultiplayerCollision();
    }

    private void SwitchToLevelOne()
    {
        if (GameState.GameMap is BasicMap)
            return;

        ComponentDrawer.Remove(GameState.GameMap);
        GameState.Snacks.ForEach(x => ComponentDrawer.Remove(x));
        var mapFactory = new MapFactory();

        GameState.GameMap = mapFactory.CreateMap(MapTypes.Basic);
        ComponentDrawer.Add(GameState.GameMap);

        GameState.Player.Reset();
        GameState.Snacks.Clear(); // Clear all snacks
        PlaceSnackIfNeeded(); // Replace all snacks
        Server.ChangeMap(MapTypes.Basic);

    }
    private void SwitchToLevelTwo()
    {
        if (GameState.GameMap is AdvanceMap)
            return;

        ComponentDrawer.Remove(GameState.GameMap);
        GameState.Snacks.ForEach(x => ComponentDrawer.Remove(x));
        var mapFactory = new MapFactory();

        GameState.GameMap = mapFactory.CreateMap(MapTypes.Advance);
        ComponentDrawer.Add(GameState.GameMap);

        GameState.Player.Reset();
        GameState.Snacks.Clear(); // Clear all snacks
        PlaceSnackIfNeeded(); // Replace all snacks

        Server.ChangeMap(MapTypes.Advance);
    }
    private void SwitchToLevelThree()
    {
        if (GameState.GameMap is ExpertMap)
            return;
        ComponentDrawer.Remove(GameState.GameMap);
        GameState.Snacks.ForEach(x => ComponentDrawer.Remove(x));
        var mapFactory = new MapFactory();

        GameState.GameMap = mapFactory.CreateMap(MapTypes.Expert);
        ComponentDrawer.Add(GameState.GameMap);

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




        ComponentDrawer = new();
        PlayerDrawer = new();
        ComponentDrawer.Add(GameState.GameMap);
        ComponentDrawer.Add(PlayerDrawer);
        PlayerDrawer.Add(GameState.Player);

        CollisionChecker = new SinglePlayerCollision();

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

        CheckPlayerCollision();
        CheckSnackCollision();
        PlaceSnackIfNeeded();
        ComponentDrawer.Draw();
        GameState.Player.Move();
    }
    private void CheckPlayerCollision()
    {
        GameState.GameMap.MapCollisionCheck();
        CollisionChecker.CheckCollision();

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
        IIterator iterator = GameState.Snacks.CreateIterator();
        while (iterator.HasMore())
        {
            var snack = (Snack)iterator.GetNext();
            if (snack.Location.IsOverlaping(GameState.Player.HeadLocation))
            {
                Publisher.NotifyObservers(snack);
            }
        }

        Server.SendEatenSnacks(GameState.Snacks);
        GameState.Snacks.RemoveAll(x =>
        {
            if (x.WasConsumed)
                ComponentDrawer.Remove(x);
            return x.WasConsumed;
        });
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
                factory = new AppleFactory(new SnackMediator());
            }
            else
            {
                factory = new LemonFactory(new SnackMediator());
            }

            int rndX = rnd.Next(0, Settings.WindowWidth / Settings.CellSize) * Settings.CellSize;
            int rndY = rnd.Next(0, Settings.WindowHeight / Settings.CellSize) * Settings.CellSize;

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

            GameState.Snacks.Add(snack);
            ComponentDrawer.Add(snack);

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
        if (ConnectionManagerProxy.IsConnected())
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
        IIterator obsticlesIterator = GameState.GameMap.Obsticles.CreateIterator();
        while (obsticlesIterator.HasMore())
        {
            var (location, _) = ((Vector2D, Rectangle))obsticlesIterator.GetNext();
            if (newSnack.IsOverlaping(location))
                return true;
        }
        // Check if overlaps other snacks
        IIterator snackIterator = GameState.Snacks.CreateIterator();
        while (snackIterator.HasMore())
        {
            var snacks = (Snack)snackIterator.GetNext();
            if (snacks.Location.IsOverlaping(newSnack))
                return true;
        }

        return false;
    }
    private void ClearScreen()
    {
        GameState.GameArea.Children.Clear();
    }

    public void ExecuteCommand(string text)
    {
        var tokens = text.Split();
        if (tokens.Length != 3)
        {
            MessageBox.Show("Invalid syntax");
            return;
        }
        var commandExpression = ParseCommand(tokens);

        if (commandExpression is null)
        {
            MessageBox.Show("Invalid command");
            return;
        }
        commandExpression.Execute();
    }

    private IExpression ParseCommand(string[] tokens)
    {
        var commandName = tokens[0];
        var commandParams = ParseArguments(tokens[1..]);
        IExpression command = new CommandExpression(commandName, commandParams);

        return command;
    }

    private List<IExpression> ParseArguments(string[] token)
    {
        List<IExpression> expressions = new();

        var targetExpression = new ObjectExpression(token[0]);
        var ok = int.TryParse(token[1], out int result);
        if (!ok)
            result = int.MinValue;

        var numberExpression = new NumberExpression(result);

        expressions.Add(targetExpression);
        expressions.Add(numberExpression);
        return expressions;
    }
}
