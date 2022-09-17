namespace Snakey.Visitor;

using Snakey.Models;

public interface IVisitor
{
    public void VisitApple(Snack snack);
    public void VisitLemon(Snack snack);
}
