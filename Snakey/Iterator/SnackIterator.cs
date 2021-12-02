using Snakey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey.Iterator
{
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
}
