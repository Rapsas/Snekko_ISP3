using Common.Utility;
using System.Collections.Generic;
using System.Windows.Shapes;

namespace Snakey.Bridge
{
    public interface ICollision
    {
        public void MapCollision(List<(Vector2D, Rectangle)> Obsticles);
    }
}
