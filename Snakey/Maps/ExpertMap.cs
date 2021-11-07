﻿using Snakey.Bridge;
using Snakey.Models;

namespace Snakey.Maps
{
    public class ExpertMap : Map
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
