namespace Snakey.Template_method
{
    public sealed class MultiplayerCollision : CollisionChecker
    {
        public sealed override bool CheckSecondPlayer()
        {
            return true;
        }
    }
}
