using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utility
{
    public struct Package
    {
        public Vector2D SnakeHeadLocation{ get; set; }
        public Queue<Vector2D> BodyLocation{ get; set; }
        public List<Vector2D> Snacks { get; set; }
    }
}
