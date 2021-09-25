using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Utility
{
    public struct Package
    {
        public string SendersID { get; set; }

        public Vector2D SnakeHeadLocation{ get; set; }
        public Queue<Vector2D> BodyLocation{ get; set; }
    }
}
