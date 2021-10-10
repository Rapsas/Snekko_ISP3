using Common.Enums;
using Snakey.Builders;
using Snakey.Maps;
using Snakey.Models;

namespace Snakey.Factories
{
    class MapFactory : IMapFactory
    {
        public Map CreateMap(MapTypes map)
        {
            MapBuilder builder = new MapConfiguration();
            return map switch
            {
                MapTypes.Basic => builder.StartNew(new BasicMap()).AddGridLines().Build(),
                MapTypes.Advance => builder.StartNew(new AdvanceMap()).AddGridLines().AddObstacles().Build(),
                MapTypes.Expert => builder.StartNew(new ExpertMap()).AddGridLines().AddWalls().AddObstacles().Build(),
                _ => null,
            };
        }
    }
}
