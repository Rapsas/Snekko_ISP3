using Common.Enums;
using Common.Utility;
using Snakey.Composite;
using Snakey.Config;
using Snakey.Managers;
using Snakey.Memento;
using Snakey.States;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snakey.Models
{
    public class Snake : IDrawableComponenet, IOriginator
    {
        public Vector2D HeadLocation { get; set; }
        public Vector2D TailLocation { get; set; }
        public Queue<Vector2D> BodyParts { get; set; }
        public MovementDirection CurrentMovementDirection { get; set; }
        public SolidColorBrush HeadColor { get; set; }
        public SolidColorBrush BodyColor { get; set; }
        public SolidColorBrush TailColor { get; set; }
        private Label SnakeText { get; }
        private Label HeadText { get; }
        public bool IsDead { get; set; }
        public bool IsMovementLocked { get; set; }
        public bool IgnoreBodyCollisionWithHead { get; set; }
        public State State { get; set; }
        public Snake()
        {
            HeadColor = new();
            BodyColor = new();
            TailColor = new();
            HeadLocation = new Vector2D(80, 80);
            TailLocation = new Vector2D(-50, -50);
            BodyParts = new();
            CurrentMovementDirection = MovementDirection.Right;
            IsDead = false;
            IsMovementLocked = false;
            IgnoreBodyCollisionWithHead = false;
            HeadColor.Color = Color.FromRgb(152, 100, 0);
            BodyColor.Color = Color.FromRgb(152, 200, 255);
            TailColor.Color = Color.FromRgb(50, 100, 120);
            SnakeText = new();
            SnakeText.FontSize = 24;
            SnakeText.FontWeight = FontWeights.Bold;
            HeadText = new();
            HeadText.FontSize = 24;
            HeadText.FontWeight = FontWeights.Bold;
            State = new RightState(this);
        }

        public PlayerPackage MakeServerPackage()
        {
            return new()
            {
                SnakeHeadLocation = HeadLocation,
                SnakeBodyLocation = BodyParts,
                SnakeMovementDirection = CurrentMovementDirection,
                SnakeTailLocation = TailLocation,
                HeadColor = new(HeadColor.Color.R, HeadColor.Color.G, HeadColor.Color.B),
                BodyColor = new(BodyColor.Color.R, BodyColor.Color.G, BodyColor.Color.B),
                TailColor = new(TailColor.Color.R, TailColor.Color.G, TailColor.Color.B)
            };
        }
        public void Move()
        {
            State.Move();
            State.SpeakDirection();
        }
        public void Expand()
        {
            BodyParts.Enqueue(HeadLocation);
        }
        public void Shrink()
        {
            if (BodyParts.Count > 0)
                BodyParts.Dequeue();
        }
        public void Reset()
        {
            HeadLocation = new Vector2D(80, 80);
            TailLocation = new Vector2D(-50, -50);
            BodyParts = new();
            CurrentMovementDirection = MovementDirection.Right;
            IsDead = false;
            IsMovementLocked = false;
        }
        public void HeadSpeak(string text)
        {
            HeadText.Content = text;
        }
        public void HeadShutup()
        {
            HeadText.Content = string.Empty;
        }
        public void Speak(string text)
        {
            SnakeText.Content = text;
        }
        public void Shutup()
        {
            SnakeText.Content = string.Empty;
        }

        public void Draw()
        {
            DrawSquare(HeadLocation, HeadColor);


            foreach (var partLocation in BodyParts)
            {
                DrawSquare(partLocation, BodyColor);
            }
            DrawSquare(TailLocation, TailColor);

            // Draw text as the last layer
            if (!string.IsNullOrEmpty(SnakeText.Content as string))
            {
                GameState.Instance.GameArea.Children.Add(SnakeText);
                Canvas.SetLeft(SnakeText, HeadLocation.X);
                Canvas.SetTop(SnakeText, HeadLocation.Y - Settings.CellSize);
            }
            // Draw head text last
            if (!string.IsNullOrEmpty(HeadText.Content as string))
            {
                GameState.Instance.GameArea.Children.Add(HeadText);
                Canvas.SetLeft(HeadText, HeadLocation.X);
                Canvas.SetTop(HeadText, HeadLocation.Y);
            }
        }
        private void DrawSquare(Vector2D location, Brush color)
        {
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
        public void SwitchState(State state)
        {
            if (this.State is UpState && state is not DownState)
                this.State = state;
            else if (this.State is DownState && state is not UpState)
                this.State = state;
            else if (this.State is LeftState && state is not RightState)
                this.State = state;
            else if (this.State is RightState && state is not LeftState)
                this.State = state;
        }
        public void SetSnakeText(string text)
        {
            SnakeText.Content = text;
        }
        public IMemento Save()
        {
            string text = SnakeText.Content?.ToString() ?? string.Empty;
            return new SnakeMemento(this, text);
        }
    }
}