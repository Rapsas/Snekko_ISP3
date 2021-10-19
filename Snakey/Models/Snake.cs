using Common.Enums;
using Common.Utility;
using Snakey.Config;
using System.Collections.Generic;
using System.Windows.Media;

namespace Snakey.Models
{
    public class Snake
    {
        public Vector2D HeadLocation { get; set; }
        public Vector2D TailLocation { get; set; }
        public Queue<Vector2D> BodyParts { get; set; }
        public MovementDirection CurrentMovementDirection { get; set; }
        public SolidColorBrush HeadColor { get; set; }
        public SolidColorBrush BodyColor { get; set; }
        public SolidColorBrush TailColor { get; set; }
        public bool IsDead { get; set; }
        public bool IsMovementLocked { get; set; }
        public bool IgnoreBodyCollisionWithHead { get; set; }

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
            BodyParts.Enqueue(HeadLocation);
            switch (CurrentMovementDirection)
            {
                case MovementDirection.Up:
                    HeadLocation -= (0, Settings.CellSize);
                    break;
                case MovementDirection.Down:
                    HeadLocation += (0, Settings.CellSize);
                    break;
                case MovementDirection.Left:
                    HeadLocation -= (Settings.CellSize, 0);
                    break;
                case MovementDirection.Right:
                    HeadLocation += (Settings.CellSize, 0);
                    break;
            }
            var lastPart = BodyParts.Dequeue();
            TailLocation = lastPart;
            IsMovementLocked = false;
            IgnoreBodyCollisionWithHead = false;
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
        public void Die()
        {
        }
    }
}