using Common.Utility;
using Snakey.Bridge;
using Snakey.Composite;
using Snakey.Managers;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Snakey.Models
{
    public abstract class Map : IDrawableComponenet
    {
        public List<Line> GridLines { get; set; } = new();
        public List<(Vector2D, Rectangle)> Obsticles { get; set; } = new List<(Vector2D location, Rectangle body)>();
        [SuppressMessage("NDepend", "ND1400:AvoidNamespacesMutuallyDependent", Justification = "...")]
        public ICollision collisionImp { get; set; }

        protected Map(ICollision collisionImp)
        {
            this.collisionImp = collisionImp;
        }

        public abstract void MapCollisionCheck();

        public void Draw()
        {
            foreach (var line in GridLines)
            {
                GameState.Instance.GameArea.Children.Add(line);
            }

            foreach (var (location, body) in Obsticles)
            {
                GameState.Instance.GameArea.Children.Add(body);
                Canvas.SetLeft(body, location.X);
                Canvas.SetTop(body, location.Y);
            }
        }
    }
}
