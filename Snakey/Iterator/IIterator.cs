using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey.Iterator
{
    public interface IIterator
    {
        object GetNext();
        bool HasMore();
    }
}
