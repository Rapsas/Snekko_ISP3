namespace Snakey.Maps;

using Snakey.Bridge;
using Snakey.Models;

public class AdvanceMap : Map
{
    public AdvanceMap(ICollision collisionImp) : base(collisionImp) { }

    public override void MapCollisionCheck()
    {
        collisionImp.MapCollision(Obsticles);
    }
}
