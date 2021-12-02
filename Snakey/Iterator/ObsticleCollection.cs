using Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Snakey.Iterator
{
    public class ObsticleCollection : IIterableCollection
    {
        List<(Vector2D, Rectangle)> Obsticles;

        public ObsticleCollection()
        {
            this.Obsticles = new();
        }
        public IIterator CreateIterator()
        {
            return new ObsticleIterator(Obsticles);
        }

        public void Add((Vector2D, Rectangle) line)
        {
            this.Obsticles.Add(line);
        }

        public int Count()
        {
            return Obsticles.Count;
        }
    }
}
