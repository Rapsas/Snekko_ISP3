using Common.Enums;
using Xunit;

namespace Snakey.Factories.Tests
{
    public class LemonFactoryTests
    {
        [StaFact]
        public void CreateBadSnackTest()
        {
            var factory = new LemonFactory();

            var result = factory.CreateBadSnack();

            Assert.True(result.SnackPackage().EffectType == EffectType.Bad && result.SnackPackage().FoodType == FoodType.Lemon);
        }

        [StaFact]
        public void CreateGoodSnackTest()
        {
            var factory = new LemonFactory();

            var result = factory.CreateGoodSnack();

            Assert.True(result.SnackPackage().EffectType == EffectType.Good && result.SnackPackage().FoodType == FoodType.Lemon);
        }

        [StaFact]
        public void CreateMysterySnackTest()
        {
            var factory = new LemonFactory();

            var result = factory.CreateMysterySnack();

            Assert.True(result.SnackPackage().EffectType == EffectType.Mystery && result.SnackPackage().FoodType == FoodType.Lemon);
        }

        [StaFact]
        public void LemonFactoryTest()
        {
            var result = new LemonFactory();
            Assert.IsType<LemonFactory>(result);
        }
    }
}