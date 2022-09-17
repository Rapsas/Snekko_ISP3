namespace Snakey.Iterator;

using System.Collections.Generic;
using System.Windows.Shapes;

class GridlineIterator : IIterator
{
    List<Line> GridLines;
    int pos = 0;
    public GridlineIterator(List<Line> gridLines)
    {
        this.GridLines = gridLines;
    }
    public object GetNext()
    {
        var line = GridLines[pos];
        pos++;
        return line;
    }

    public bool HasMore()
    {
        return pos < GridLines.Count;
    }
}
