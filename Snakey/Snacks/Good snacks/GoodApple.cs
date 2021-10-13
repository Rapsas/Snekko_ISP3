using Common.Enums;
using Snakey.Config;
using Snakey.Managers;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snakey.Snacks
{
    class GoodApple : GoodSnack
    {
        public override void TriggerEffect()
        {
            GameState.Instance.Score++;
            GameState.Instance.Player.Expand();
        }
        public GoodApple() : base()
        {
            _foodType = FoodType.Apple;
            _body = new Rectangle()
            {
                Stroke = this.Stroke,
                StrokeThickness = this.StrokeThickness,
                Width = Settings.CellSize,
                Height = Settings.CellSize,
                Fill = Brushes.IndianRed
            };
        }
    }
}
