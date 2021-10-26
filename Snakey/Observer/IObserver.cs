using Snakey.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Snakey.Adapter;

namespace Snakey.Observer
{
    interface IObserver
    {
        void Update(SnackAdapter snack);
    }
}
