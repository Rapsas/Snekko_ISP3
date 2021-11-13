using System.Collections.Generic;

namespace Snakey.Composite
{
    public class ComponentDrawer : IDrawableComponenet
    {
        readonly List<IDrawableComponenet> _children = new();

        public void Add(IDrawableComponenet component) => _children.Add(component);
        public void Remove(IDrawableComponenet componentToRemove) => _children.Remove(componentToRemove);
        public void Draw() => _children.ForEach(c => c.Draw());
    }
}
