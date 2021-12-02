using Common.Utility;
using Snakey.Iterator;
using System.Collections.Generic;
using System.Windows.Shapes;

namespace Snakey.Bridge
{
    public interface ICollision
    {
        public void MapCollision(ObsticleCollection Obsticles);
    }
}
