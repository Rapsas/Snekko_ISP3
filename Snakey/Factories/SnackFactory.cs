using Snakey.Snacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey.Factories
{
    class SnackFactory : ISnackFactory
    {
        public Snack CreateBadSnack()
        {
            return new BadSnack();
        }

        public Snack CreateGoodSnack()
        {
            return new GoodSnack();
        }

        public Snack CreateMysterySnack()
        {
            return new MysterySnack();
        }
    }
}
