﻿namespace Snakey.Iterator;

using Common.Utility;
using System.Collections.Generic;
using System.Windows.Shapes;

class ObsticleIterator : IIterator
{
    List<(Vector2D, Rectangle)> Obsticles;
    int pos = 0;
    public ObsticleIterator(List<(Vector2D, Rectangle)> obsticle)
    {
        this.Obsticles = obsticle;
    }
    public object GetNext()
    {
        var obj = Obsticles[pos];
        pos++;
        return obj;
    }

    public bool HasMore()
    {
        return pos < Obsticles.Count;
    }
}
