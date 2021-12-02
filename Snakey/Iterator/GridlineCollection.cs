using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Snakey.Iterator
{
    public class GridlineCollection : IIterableCollection
    {
        List<Line> GridLines;

        public GridlineCollection()
        {
            this.GridLines = new();
        }
        public IIterator CreateIterator()
        {
            return new GridlineIterator(GridLines);
        }

        public void Add(Line line)
        {
            this.GridLines.Add(line);
        }

        public int Count()
        {
            return GridLines.Count;
        }
    }
}
