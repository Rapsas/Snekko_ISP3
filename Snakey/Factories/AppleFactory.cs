using Snakey.Snacks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey.Factories
{
    class AppleFactory : ISnackFactory
    {
        public BadSnack CreateBadSnack()
        {
            return new BadApple();
        }

        public GoodSnack CreateGoodSnack()
        {
            return new GoodApple();
        }

        public MysterySnack CreateMysterySnack()
        {
            return new MysteryApple();
        }
    }
}
