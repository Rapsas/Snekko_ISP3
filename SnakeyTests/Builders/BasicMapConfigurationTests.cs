using Snakey.Maps;
using Xunit;

namespace Snakey.Builders.Tests
{
    public class BasicMapConfigurationTests
    {
        [StaFact]
        public void AddObstaclesTest()
        {
            MapBuilder builder = new BasicMapConfiguration();

            var map = builder.StartNew().AddObstacles().Build();

            Assert.True(map.Obsticles.Count == 0);
        }

        [StaFact]
        public void AddWallsTest()
        {
            MapBuilder builder = new BasicMapConfiguration();

            var map = builder.StartNew().AddWalls().Build();

            Assert.True(map.Obsticles.Count == 0);
        }

        [StaFact]
        public void StartNewTest()
        {
            MapBuilder builder = new BasicMapConfiguration();

            var map = builder.StartNew().Build();

            Assert.IsType<BasicMap>(map);
        }
    }
}