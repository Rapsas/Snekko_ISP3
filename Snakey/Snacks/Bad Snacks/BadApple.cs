using Common.Enums;
using Snakey.Config;
using Snakey.Managers;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Snakey.Snacks
{
    class BadApple: BadSnack
    {
        public override void TriggerEffect()
        {
            GameState.Instance.Score--;
            GameState.Instance.Player.Shrink();
        }
        public BadApple() : base()
        {
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
