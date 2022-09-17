namespace Snakey.Builders;

using Snakey.Bridge;
using Snakey.Maps;

public class BasicMapConfiguration : MapBuilder
{

    public override MapBuilder AddObstacles() => this;

    public override MapBuilder AddWalls() => this;

    public override MapBuilder StartNew()
    {
        _map = new BasicMap(new BasicCollision());
        return this;
    }
}
