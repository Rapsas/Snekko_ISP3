using Common.Utility;
using Snakey.Managers;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Snakey.Models
{
    // NOTE: this shit wont send through SignalR so we will need some sort of 
    // new package to transfer type and location in rebuild the list it at the other end
    public abstract class Snack
    {
        public Vector2D Location { get; set; }
        public bool WasConsumed { get; set; } = false;

        protected Canvas _gameArea = GameState.Instance.GameArea;
        protected Shape _body { get; set; }

        public void Draw()
        {
            _gameArea.Children.Add(_body);
            Canvas.SetLeft(_body, Location.X);
            Canvas.SetTop(_body, Location.Y);
        }
        public abstract void TriggerEffect();
    }
}
