using Snakey.Bridge;
using Snakey.Managers;
using Snakey.Models;

namespace Snakey.Maps
{
    class ExpertMap : Map
    {
        public ExpertMap(ICollision collisionImp) : base(collisionImp)
        {

        }

        public override void MapCollisionCheck()
        {
            collisionImp.MapCollision(Obsticles);
        }
    }
}
