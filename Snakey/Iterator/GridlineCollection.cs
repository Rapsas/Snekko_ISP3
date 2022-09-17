namespace Snakey.Iterator;

using System.Collections.Generic;
using System.Windows.Shapes;

public class GridlineCollection : IIterableCollection
{
    List<Line> GridLines;

    public GridlineCollection()
    {
        GridLines = new();
    }
    public IIterator CreateIterator()
    {
        return new GridlineIterator(GridLines);
    }

    public void Add(Line line)
    {
        GridLines.Add(line);
    }

    public int Count() => GridLines.Count;
}
