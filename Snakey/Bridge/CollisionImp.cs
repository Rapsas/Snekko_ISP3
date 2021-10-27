using Common.Utility;
using Snakey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Snakey.Bridge
{
    public interface ICollision
    {
        public void MapCollision(List<(Vector2D, Rectangle)> Obsticles);
    }
}
