using Common.Utility;
using Snakey.Bridge;
using Snakey.Config;
using Snakey.Maps;
using System;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snakey.Builders
{
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

                //if (GameState.Player.HeadLocation.IsOverlaping(obstacleLocation))
                //    continue; // Try again

                bool overlapped = false;
                foreach (var (location, body) in Map.Obsticles)
                {
                    if (location.IsOverlaping(obstacleLocation))
                    {
                        overlapped = true;
                        break;
                    }
                }

                if (overlapped)
                    continue; // Try again

                Map.Obsticles.Add((
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

        public override MapBuilder AddWalls()
        {
            return this;
        }

        public override MapBuilder StartNew()
        {
            Map = new AdvanceMap(new AdvancedCollision());
            return this;
        }
    }
}
