using Snakey.Config;
using Snakey.Flyweight;
using Snakey.Managers;

namespace Snakey.Snacks
{
    public class GoodApple : GoodSnack
    {
        public override void TriggerEffect()
        {
            GameState.Instance.Player.Expand();
        }
        public GoodApple() : base()
        {
            _body = new();

            _body.Source = ImageFactory.GetImage("good_apple.png");
            _body.Width = _body.Height = Settings.CellSize;
        }
    }
}
