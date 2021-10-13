using Common.Enums;
using Snakey.Config;
using Snakey.Managers;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snakey.Snacks
{
    class MysteryLemon : MysterySnack
    {
        public override void TriggerEffect()
        {
            GameState.Instance.Score++;
        }
        public MysteryLemon() : base()
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
