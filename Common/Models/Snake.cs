using Common.Enums;
using Common.Utility;
using Snakey.Config;
using System.Collections.Generic;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Common.Models
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


        public void Move()
        {
            
        }

        public void Expand()
        {
            BodyParts.Enqueue(HeadLocation);
        }
    }
}