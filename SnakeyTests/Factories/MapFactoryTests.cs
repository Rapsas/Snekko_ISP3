﻿using Common.Enums;
using Snakey.Maps;
using Xunit;

namespace Snakey.Factories.Tests
{
    public class MapFactoryTests
    {
        [StaFact]
        public void CreateMapTest()
        {
            var mapFactory = new MapFactory();

            var basicMap = mapFactory.CreateMap(MapTypes.Basic);
            var advanceMap = mapFactory.CreateMap(MapTypes.Advance);
            var expertMap = mapFactory.CreateMap(MapTypes.Expert);

            Assert.IsType<BasicMap>(basicMap);
            Assert.IsType<AdvanceMap>(advanceMap);
            Assert.IsType<ExpertMap>(expertMap);
        }
    }
}