﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shapes;

namespace Snakey.Iterator
{
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
}
