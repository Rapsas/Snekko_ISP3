using Common.Enums;
using Common.Utility;
using Snakey.Config;
using Snakey.Managers;
using System.Collections.Generic;
using System.Windows;

namespace Snakey.Models
{
    public class Snake
    {
        public Vector2D HeadLocation { get; set; }
        public Queue<Vector2D> BodyParts { get; set; }
        public MovementDirection CurrentMovementDirection { get; set; }

        public Snake()
        {
            HeadLocation = new Vector2D(0, 0);
            BodyParts = new();
            CurrentMovementDirection = MovementDirection.Right;
        }

        public Package MakeServerPackage(string senderID)
        {
            return new()
            {
                SnakeHeadLocation = HeadLocation,
                BodyLocation = BodyParts,
                SendersID = senderID,
            };
        }
        public void Move()
        {
            switch (CurrentMovementDirection)
            {
                case MovementDirection.Up:
                    HeadLocation += (0, Settings.CellSize);
                    break;
                case MovementDirection.Down:
                    HeadLocation -= (0, Settings.CellSize);
                    break;
                case MovementDirection.Left:
                    HeadLocation -= (Settings.CellSize, 0);
                    break;
                case MovementDirection.Right:
                    HeadLocation += (Settings.CellSize, 0);
                    break;
            }
        }
        public void Expand()
        {
            BodyParts.Enqueue(HeadLocation);
        }
        public void Die()
        {
            MessageBox.Show("Game over");
        }
    }
}