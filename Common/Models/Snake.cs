using Common.Utility;
using System.Collections.Generic;

namespace Common.Models
{
    public class Snake
    {
        public Vector2D HeadLocation { get; set; }
        public Queue<Vector2D> BodyParts { get; set; }


        public void Move()
        {
            
        }

        public void Expand()
        {
            BodyParts.Enqueue(HeadLocation);
        }
    }
}