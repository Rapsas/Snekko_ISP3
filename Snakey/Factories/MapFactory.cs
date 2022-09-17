namespace Snakey.Factories;

using Common.Enums;
using Snakey.Builders;
using Snakey.Models;

public class MapFactory : IMapFactory
{
    public Map CreateMap(MapTypes map)
    {
        MapBuilder builder = map switch
        {
            MapTypes.Basic => new BasicMapConfiguration(),
            MapTypes.Advance => new AdvanceMapConfiguration(),
            MapTypes.Expert => new ExpertMapConfiguration(),
            _ => null,
        };
        return builder?.StartNew().AddGridLines().AddObstacles().AddWalls().Build();
    }
}
