﻿using Snakey.Maps;
using Xunit;

namespace Snakey.Builders.Tests
{
    public class ExpertMapConfigurationTests
    {
        [StaFact]
        public void AddObstaclesTest()
        {
            MapBuilder builder = new ExpertMapConfiguration();

            var map = builder.StartNew().AddObstacles().Build();

            Assert.True(map.Obsticles.Count != 0);
        }

        [StaFact]
        public void AddWallsTest()
        {
            MapBuilder builder = new ExpertMapConfiguration();

            var map = builder.StartNew().AddWalls().Build();

            Assert.True(map.Obsticles.Count != 0);
        }

        [StaFact]
        public void StartNewTest()
        {
            MapBuilder builder = new ExpertMapConfiguration();

            var map = builder.StartNew().Build();

            Assert.IsType<ExpertMap>(map);
        }
    }
}