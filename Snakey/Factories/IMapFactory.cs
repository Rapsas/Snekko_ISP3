namespace Snakey.Factories;

using Common.Enums;
using Snakey.Models;

interface IMapFactory
{
    Map CreateMap(MapTypes map);
}
