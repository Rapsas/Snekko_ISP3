using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey.Memento
{
    public interface IOriginator
    {
        public IMemento Save();
    }
}
