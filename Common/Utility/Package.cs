using Common.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utility
{
    public struct Package
    {
        public Vector2D SnakeHeadLocation{ get; set; }
        public MovementDirection SnakeMovementDirection { get; set; }
        public Queue<Vector2D> SnakeBodyLocation{ get; set; }
    }
}
