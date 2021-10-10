using Common.Utility;
using System.Collections.Generic;
using System.Windows.Shapes;

namespace Snakey.Models
{
    public abstract class Map
    {
        public List<Line> GridLines { get; set; } = new();
        public List<(Vector2D, Rectangle)> Obsticles { get; set; } = new List<(Vector2D location, Rectangle body)>();

        public abstract void MapCollisionCheck();
    }
}
