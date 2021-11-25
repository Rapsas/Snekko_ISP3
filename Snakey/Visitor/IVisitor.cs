using Snakey.Models;

namespace Snakey.Visitor
{
    public interface IVisitor
    {
        public void VisitApple(Snack snack);
        public void VisitLemon(Snack snack);
    }
}
