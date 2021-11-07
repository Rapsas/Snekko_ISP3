using Common.Enums;
using Xunit;

namespace Snakey.Factories.Tests
{
    public class AppleFactoryTests
    {
        [StaFact]
        public void AppleFactoryTest()
        {
            var result = new AppleFactory();
            Assert.IsType<AppleFactory>(result);
        }
        [StaFact]
        public void CreateBadSnackTest()
        {
            var factory = new AppleFactory();

            var result = factory.CreateBadSnack();

            Assert.True(result.SnackPackage().EffectType == EffectType.Bad && result.SnackPackage().FoodType == FoodType.Apple);
        }

        [StaFact]
        public void CreateGoodSnackTest()
        {
            var factory = new AppleFactory();

            var result = factory.CreateGoodSnack();

            Assert.True(result.SnackPackage().EffectType == EffectType.Good && result.SnackPackage().FoodType == FoodType.Apple);
        }

        [StaFact]
        public void CreateMysterySnackTest()
        {
            var factory = new AppleFactory();

            var result = factory.CreateMysterySnack();

            Assert.True(result.SnackPackage().EffectType == EffectType.Mystery && result.SnackPackage().FoodType == FoodType.Apple);
        }


    }
}