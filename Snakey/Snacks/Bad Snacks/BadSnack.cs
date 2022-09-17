namespace Snakey.Snacks;

using Snakey.Models;
using Snakey.Visitor;
using System.Windows.Media;

public class BadSnack : Snack
{
    protected SolidColorBrush Stroke = Brushes.Red;
    protected double StrokeThickness = 5;
    public BadSnack()
    {
        WasConsumed = false;
    }

    public override void Accept(IVisitor visitor) { }

    public override void TriggerEffect() { }
}
