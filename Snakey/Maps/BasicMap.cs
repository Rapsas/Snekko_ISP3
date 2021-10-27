using Snakey.Bridge;
using Snakey.Managers;
using Snakey.Models;

namespace Snakey.Maps
{
    class BasicMap : Map
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
