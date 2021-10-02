using Snakey.Managers;

namespace Snakey.Maps
{
    class BasicMap : Map
    {
        GameState _gameState = GameState.Instance;
        public override void PlayerCollisionCheck()
        {
            var player = _gameState.Player;
            
            if (_gameState.Player.HeadLocation.X < 0)
            {
                player.HeadLocation = new((int)_gameState.GameArea.ActualWidth, player.HeadLocation.Y);
            }
            else if (player.HeadLocation.Y < 0)
            {
                player.HeadLocation = new(player.HeadLocation.X, (int)_gameState.GameArea.ActualHeight);
            }
            else if (player.HeadLocation.X >= _gameState.GameArea.ActualWidth 
                || player.HeadLocation.Y >= _gameState.GameArea.ActualHeight)
            {

                // Wrap around map
                player.HeadLocation = new(
                    player.HeadLocation.X % (int)_gameState.GameArea.ActualWidth,
                    player.HeadLocation.Y % (int)_gameState.GameArea.ActualHeight);
            }

            foreach (var bodyPart in player.BodyParts)
            {
                if (player.HeadLocation.IsOverlaping(bodyPart))
                {
                    player.IsDead = true;
                    return;
                }
            }
            if (player.HeadLocation.IsOverlaping(player.TailLocation))
            {
                player.IsDead = true;
                return;
            }
        }
    }
}
