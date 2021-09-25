using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey.Factories
{
    interface ISnackFactory
    {
        Snack CreateGoodSnack();
        Snack CreateBadSnack();
        Snack CreateMysterySnack();
    }
}
