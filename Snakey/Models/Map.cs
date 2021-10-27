using Common.Utility;
using Snakey.Bridge;
using System.Collections.Generic;
using System.Windows.Shapes;

namespace Snakey.Models
{
    public abstract class Map
    {
        public List<Line> GridLines { get; set; } = new();
        public List<(Vector2D, Rectangle)> Obsticles { get; set; } = new List<(Vector2D location, Rectangle body)>();
        public ICollision collisionImp { get; set; }

        protected Map(ICollision collisionImp)
        {
            this.collisionImp = collisionImp;
        }

        public abstract void MapCollisionCheck();
    }
}
