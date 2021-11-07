using Xunit;

namespace Snakey.Snacks.Tests
{
    public class MysteryLemonTests
    {


        [StaFact]
        public void CloneTest()
        {
            var lemon = new MysteryLemon();
            var original = lemon.ToString();
            var clonedLemon = lemon.Clone();
            var cloned = clonedLemon.ToString();
            Assert.True(original == cloned);
        }

        [StaFact]
        public void DeepCloneTest()
        {
            var lemon = new MysteryLemon();
            var original = lemon.ToString();
            var clonedLemon = lemon.DeepClone();
            var cloned = clonedLemon.ToString();
            Assert.False(lemon.Equals(clonedLemon));
        }

        [StaFact]
        public void MysteryLemonTest()
        {
            var lemon = new MysteryLemon();
            Assert.IsType<MysteryLemon>(lemon);
        }
    }
}