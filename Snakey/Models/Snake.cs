using Common.Enums;
using Common.Utility;
using Snakey.Config;
using System.Collections.Generic;

namespace Snakey.Models
{
    public class Snake
    {
        public Vector2D HeadLocation { get; set; }
        public Vector2D TailLocation { get; set; }
        public Queue<Vector2D> BodyParts { get; set; }
        public MovementDirection CurrentMovementDirection { get; set; }
        public bool IsDead { get; set; }
        public Snake()
        {
            HeadLocation = new Vector2D(0, 0);
            TailLocation = new Vector2D(-50, -50);
            BodyParts = new();
            CurrentMovementDirection = MovementDirection.Right;
            IsDead = false;
        }

        public PlayerPackage MakeServerPackage()
        {
            return new()
            {
                SnakeHeadLocation = HeadLocation,
                SnakeBodyLocation = BodyParts,
                SnakeMovementDirection = CurrentMovementDirection
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
        }
        public void Expand()
        {
            BodyParts.Enqueue(HeadLocation);
        }
        public void Die()
        {
        }
    }
}