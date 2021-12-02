using Xunit;

namespace Snakey.Builders.Tests
{
    public class MapBuilderTests
    {
        [StaFact]
        public void AddGridLinesTest()
        {
            MapBuilder builder = new BasicMapConfiguration();

            var map = builder.StartNew().AddGridLines().Build();

            Assert.True(map.GridLines.Count() != 0);
        }
    }
}