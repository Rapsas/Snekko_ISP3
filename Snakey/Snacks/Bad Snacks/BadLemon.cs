using Common.Enums;
using Snakey.Config;
using Snakey.Managers;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snakey.Snacks
{
    class BadLemon : BadSnack
    {
        public override void TriggerEffect()
        {
            GameState.Instance.Score--;
            GameState.Instance.Player.Shrink();
        }

        public BadLemon() : base()
        {
            _foodType = FoodType.Lemon;
            _body = new Ellipse()
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
