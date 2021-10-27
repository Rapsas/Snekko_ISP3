using Snakey.Maps;

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
