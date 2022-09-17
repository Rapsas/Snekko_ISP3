namespace Snakey.Builders;

using Common.Utility;
using Snakey.Bridge;
using Snakey.Config;
using Snakey.Iterator;
using Snakey.Maps;
using System;
using System.Windows.Media;
using System.Windows.Shapes;

public class AdvanceMapConfiguration : MapBuilder
{
    public override MapBuilder AddObstacles()
    {
        var placedObstacles = 0;
        var rnd = new Random(69420);
        for (int i = 0; i < 100; i++) // 100 tries to place a snack randomly
        {
            if (placedObstacles >= Settings.ObstacleCount)
                break;
            int rndX = rnd.Next(0, Settings.WindowWidth / Settings.CellSize) * Settings.CellSize;
            int rndY = rnd.Next(0, Settings.WindowHeight / Settings.CellSize) * Settings.CellSize;

            var obstacleLocation = new Vector2D(rndX, rndY);

            bool overlapped = false;
            IIterator obsticlesIterator = _map.Obsticles.CreateIterator();
            while (obsticlesIterator.HasMore())
            {
                var (location, _) = ((Vector2D, Rectangle))obsticlesIterator.GetNext();
                if (location.IsOverlaping(obstacleLocation))
                {
                    overlapped = true;
                    break;
                }
            }

            if (overlapped)
                continue; // Try again

            _map.Obsticles.Add((
                obstacleLocation,
                new Rectangle()
                {
                    Width = Settings.CellSize,
                    Height = Settings.CellSize,
                    Fill = Brushes.Black
                }));
            placedObstacles++;
        }

        return this;
    }

    public override MapBuilder AddWalls() => this;

    public override MapBuilder StartNew()
    {
        _map = new AdvanceMap(new AdvancedCollision());
        return this;
    }
}
