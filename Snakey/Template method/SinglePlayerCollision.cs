namespace Snakey.Template_method
{
    public sealed class SinglePlayerCollision : CollisionChecker
    {
        public sealed override bool CheckSecondPlayer()
        {
            return false;
        }
    }
}
