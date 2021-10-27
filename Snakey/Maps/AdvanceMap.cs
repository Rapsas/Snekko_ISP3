using Snakey.Bridge;
using Snakey.Managers;
using Snakey.Models;

namespace Snakey.Maps
{
    class AdvanceMap : Map
    {
        public AdvanceMap(ICollision collisionImp) : base(collisionImp)
        {

        }

        public override void MapCollisionCheck()
        {
            collisionImp.MapCollision(Obsticles);
        }
    }
}
