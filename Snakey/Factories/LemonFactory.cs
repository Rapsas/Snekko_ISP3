using Snakey.Snacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey.Factories
{
    class LemonFactory : ISnackFactory
    {
        public BadSnack CreateBadSnack()
        {
            return new BadLemon();
        }

        public GoodSnack CreateGoodSnack()
        {
            return new GoodLemon();
        }

        public MysterySnack CreateMysterySnack()
        {
            return new MysteryLemon();
        }
    }
}
