using Common.Utility;
using Snakey.Bridge;
using Snakey.Config;
using Snakey.Iterator;
using Snakey.Maps;
using System;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snakey.Builders
{
    public class ExpertMapConfiguration : MapBuilder
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
                IIterator obsticlesIterator = _map.Obsticles.CreateIterator();
                while (obsticlesIterator.HasMore())
                {
                    var (location, body) = ((Vector2D, Rectangle))obsticlesIterator.GetNext();
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

        public override MapBuilder AddWalls()
        {
            // Add top and bottom walls
            for (int i = 0; i < Settings.WindowWidth; i += Settings.CellSize)
            {
                _map.Obsticles.Add((new(i, 0), new Rectangle()
                {
                    Width = Settings.CellSize,
                    Height = Settings.CellSize,
                    Fill = Brushes.Black
                }));
                _map.Obsticles.Add((new(i, Settings.WindowHeight - Settings.CellSize), new Rectangle()
                {
                    Width = Settings.CellSize,
                    Height = Settings.CellSize,
                    Fill = Brushes.Black
                }));
            }
            // Add side walls
            for (int i = Settings.CellSize; i < Settings.WindowHeight - Settings.CellSize; i += Settings.CellSize)
            {
                _map.Obsticles.Add((new(0, i), new Rectangle()
                {
                    Width = Settings.CellSize,
                    Height = Settings.CellSize,
                    Fill = Brushes.Black
                }));
                _map.Obsticles.Add((new(Settings.WindowWidth - Settings.CellSize, i), new Rectangle()
                {
                    Width = Settings.CellSize,
                    Height = Settings.CellSize,
                    Fill = Brushes.Black
                }));
            }
            return this;
        }

        public override MapBuilder StartNew()
        {
            _map = new ExpertMap(new ExpertCollision());
            return this;
        }
    }
}
