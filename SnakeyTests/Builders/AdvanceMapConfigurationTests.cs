using Snakey.Maps;
using Xunit;

namespace Snakey.Builders.Tests
{
    public class AdvanceMapConfigurationTests
    {
        [StaFact]
        public void AddObstaclesTest()
        {
            MapBuilder builder = new AdvanceMapConfiguration();

            var map = builder.StartNew().AddObstacles().Build();

            Assert.True(map.Obsticles.Count != 0);
        }

        [StaFact]
        public void AddWallsTest()
        {
            MapBuilder builder = new AdvanceMapConfiguration();

            var map = builder.StartNew().AddWalls().Build();

            Assert.True(map.Obsticles.Count == 0);
        }

        [StaFact]
        public void StartNewTest()
        {
            MapBuilder builder = new AdvanceMapConfiguration();

            var map = builder.StartNew().Build();

            Assert.IsType<AdvanceMap>(map);
        }
    }
}