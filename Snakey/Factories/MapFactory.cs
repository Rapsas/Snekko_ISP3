using Common.Enums;
using Snakey.Maps;
using Snakey.Models;

namespace Snakey.Factories
{
    class MapFactory : IMapFactory
    {
        public Map CreateMap(MapTypes map)
        {
            return map switch
            {
                MapTypes.Basic => new BasicMap(),
                MapTypes.Advance => new AdvanceMap(),
                MapTypes.Expert => new ExpertMap(),
                _ => null,
            };
        }
    }
}
