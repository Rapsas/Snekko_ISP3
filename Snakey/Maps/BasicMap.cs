using Snakey.Bridge;
using Snakey.Models;

namespace Snakey.Maps
{
    public class BasicMap : Map
    {
        public BasicMap(ICollision collisionImp) : base(collisionImp)
        {
        }

        public override void MapCollisionCheck()
        {
            collisionImp.MapCollision(Obsticles);
        }
    }
}
