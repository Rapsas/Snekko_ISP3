﻿using Common.Utility;
using System.Collections.Generic;
using System.Windows.Shapes;

namespace Snakey.Models
{
    public abstract class Map
    {
        public List<Line> GridLines { get; set; } = new();
        public List<Vector2D> Obsticles { get; set; } // Only initialize when needed
        public abstract void MapCollisionCheck();
    }
}