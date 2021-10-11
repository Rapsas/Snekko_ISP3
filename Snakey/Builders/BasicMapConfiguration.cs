using Snakey.Maps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snakey.Builders
{
    class BasicMapConfiguration : MapBuilder
    {

        public override MapBuilder AddObstacles()
        {
            return this;
        }

        public override MapBuilder AddWalls()
        {
            return this;
        }

        public override MapBuilder StartNew()
        {
            _map = new BasicMap();
            return this;
        }
    }
}
