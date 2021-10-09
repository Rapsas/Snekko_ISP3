using Common.Enums;
using Snakey.Models;

namespace Snakey.Factories
{
    interface IMapFactory
    {
        Map CreateMap(MapTypes map);
    }
}
