namespace Snakey.Iterator;

using Snakey.Models;
using System.Collections.Generic;

class SnackIterator : IIterator
{
    List<Snack> Snacks;
    int pos = 0;
    public SnackIterator(List<Snack> gridLines)
    {
        this.Snacks = gridLines;
    }
    public object GetNext()
    {
        var line = Snacks[pos];
        pos++;
        return line;
    }

    public bool HasMore()
    {
        return pos < Snacks.Count;
    }
}
