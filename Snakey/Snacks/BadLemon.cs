using Snakey.Config;
using Snakey.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snakey.Snacks
{
    class BadLemon : BadSnack
    {
        protected Ellipse _body { get; set; }
        public override void TriggerEffect()
        {
            GameState.Instance.Score++;
        }

        public override void Draw()
        {
            _gameArea.Children.Add(_body);
            Canvas.SetLeft(_body, Location.X);
            Canvas.SetTop(_body, Location.Y);
        }
        public BadLemon() : base()
        {
            _body = new()
            {
                Stroke = this.Stroke,
                StrokeThickness = this.StrokeThickness,
                Width = Settings.CellSize,
                Height = Settings.CellSize,
                Fill = Brushes.Yellow
            };
        }
    }
}
