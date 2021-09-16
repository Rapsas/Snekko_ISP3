using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Snakey.Maps
{
    public abstract class Map
    {
        public List<Line> GridLines { get; set; } = new();
    }
}
