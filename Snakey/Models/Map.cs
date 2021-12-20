using Common.Utility;
using Snakey.Bridge;
using Snakey.Composite;
using Snakey.Iterator;
using Snakey.Managers;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Snakey.Models
{
    public abstract class Map : IDrawableComponenet
    {
        public GridlineCollection GridLines { get; set; } = new();
        public ObsticleCollection Obsticles { get; set; } = new();
        public ICollision collisionImp { get; set; }

        protected Map(ICollision collisionImp)
        {
            this.collisionImp = collisionImp;
        }

        public abstract void MapCollisionCheck();

        public void Draw()
        {
            IIterator gridLineIterator = GridLines.CreateIterator();
            while (gridLineIterator.HasMore())
            {
                Line line = (Line)gridLineIterator.GetNext();
                GameState.Instance.GameArea.Children.Add(line);
            }

            IIterator obsticlesIterator = Obsticles.CreateIterator();
            while (obsticlesIterator.HasMore())
            {
                var (location, body) = ((Vector2D, Rectangle))obsticlesIterator.GetNext();
                GameState.Instance.GameArea.Children.Add(body);
                Canvas.SetLeft(body, location.X);
                Canvas.SetTop(body, location.Y);
            }
        }
    }
}
