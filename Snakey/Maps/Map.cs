using System.Collections.Generic;
using System.Windows.Shapes;

namespace Snakey.Maps
{
    public abstract class Map
    {
        public List<Line> GridLines { get; set; } = new();
    }
}
