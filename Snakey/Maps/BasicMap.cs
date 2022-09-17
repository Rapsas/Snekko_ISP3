namespace Snakey.Maps;

using Snakey.Bridge;
using Snakey.Models;

public class BasicMap : Map
{
    public BasicMap(ICollision collisionImp) : base(collisionImp) { }

    public override void MapCollisionCheck()
    {
        collisionImp.MapCollision(Obsticles);
    }
}
