using Snakey.Bridge;
using Snakey.Maps;

namespace Snakey.Builders
{
    public class BasicMapConfiguration : MapBuilder
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
            _map = new BasicMap(new BasicCollision());
            return this;
        }
    }
}
