namespace Snakey.Maps;

using Snakey.Bridge;
using Snakey.Models;

public class ExpertMap : Map
{
    public ExpertMap(ICollision collisionImp) : base(collisionImp) { }

    public override void MapCollisionCheck()
    {
        collisionImp.MapCollision(Obsticles);
    }
}
