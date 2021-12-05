using Snakey.Config;
using Snakey.Models;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snakey.Builders
{
    public abstract class MapBuilder
    {
        private Map map;

        protected Map Map { get => map; set => map = value; }

        public Map Build()
        {
            return Map;
        }
        public abstract MapBuilder StartNew();
        public MapBuilder AddGridLines()
        {
            for (int row = 0; row < Settings.WindowHeight; row += Settings.CellSize)
            {
                Line line = new()
                {
                    X1 = 0,
                    Y1 = row,
                    X2 = Settings.WindowWidth,
                    Y2 = row,
                    StrokeThickness = 1,
                    Stroke = Brushes.Black
                };
                Map.GridLines.Add(line);
            }
            // Draw vertical lines
            for (int column = 0; column < Settings.WindowWidth; column += Settings.CellSize)
            {
                Line line2 = new()
                {
                    X1 = column,
                    Y1 = 0,
                    X2 = column,
                    Y2 = Settings.WindowHeight,
                    StrokeThickness = 1,
                    Stroke = Brushes.Black
                };
                Map.GridLines.Add(line2);
            }

            return this;
        }
        public abstract MapBuilder AddWalls();
        public abstract MapBuilder AddObstacles();
    }
}
