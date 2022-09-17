namespace Snakey.Iterator;

using Common.Utility;
using System.Collections.Generic;
using System.Windows.Shapes;

public class ObsticleCollection : IIterableCollection
{
    List<(Vector2D, Rectangle)> Obsticles;

    public ObsticleCollection()
    {
        Obsticles = new();
    }
    public IIterator CreateIterator()
    {
        return new ObsticleIterator(Obsticles);
    }

    public void Add((Vector2D, Rectangle) line)
    {
        Obsticles.Add(line);
    }

    public int Count() => Obsticles.Count;
}
